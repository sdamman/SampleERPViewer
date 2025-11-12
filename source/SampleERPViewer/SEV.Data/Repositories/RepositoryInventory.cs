using SEV.Data.Contexts;
using SEV.Domain.Helpers;
using SEV.Domain.Models;
using SEV.Domain.Models.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEV.Data.Repositories
{
  public class RepositoryInventory : IRepositoryInventory
  {
    private readonly ContextInventory _contextInventory;

    public RepositoryInventory(ContextInventory contextInVend)
    {
      _contextInventory = contextInVend;
    }

    public IEnumerable<BomSimple> GetBomOfPart(string partNumber)
    {
      List<BomSimple> bomList = [];
      string currentRev = GetCurrentPartRev(partNumber);
      var query = from bom in _contextInventory.InBoms
                  join x in _contextInventory.Inmastxes
                  on bom.Fcomponent equals x.Fpartno
                  join m in _contextInventory.InMasts
                  on bom.Fcomponent equals m.Fpartno
                  where (bom.Fparent == partNumber) && (bom.Fparentrev == currentRev)
                  select new BomSimple
                  {
                    Parent = bom.Fparent,
                    ParentRevision = bom.Fparentrev,
                    PartNumber = bom.Fcomponent,
                    PartRev = x.Frev,
                    Description = x.Fdescript,
                    Quantity = (double)bom.Fqty,
                    UnitOfMeasure = x.Fmeasure,
                    StandardCost = (double)x.Fstdcost,
                    QuantityOnHand = (double)(m.Fonhand + m.Fproqty - m.Fbook),
                    Location = x.Flocate1
                  };

      var q = from n in query
              group n by n.PartNumber into g
              select g.OrderByDescending(t => t.PartRev).FirstOrDefault();

      return q;

    }

    public Inmastx GetPartByNumber(string partNumber)
    {
      if (!PartNumberExists(partNumber)) return null;

      string currentRev = GetCurrentPartRev(partNumber);
      var q = _contextInventory.Inmastxes.Where(p =>
                        (p.Fpartno == partNumber) && (p.Frev == currentRev));
      if (q.Any())
        return q.First();
      else
        return null;
    }

    public List<BomWhereUsed> GetWhereUsedByPart(string partNumber,
                                                string revision)
    {
      List<BomWhereUsed> bomWhereUseds = new();
      var query = _contextInventory.InBoms.Where(p => p.Fcomponent == partNumber
                                                  && p.Fcomprev == revision)
                  .Select(x => new
                  {
                    x.Fparent,
                    x.Fparentrev
                  }).ToList();
      foreach (var parent in query)
      {
        var bom = _contextInventory.InBoms.FirstOrDefault(d => d.Fparent == parent.Fparent
                                                            && d.Fcomponent == partNumber
                                                            && d.Fparentrev == parent.Fparentrev);

        BomWhereUsed bwu = new()
        {
          ParentPart = bom.Fparent,
          ParentRev = bom.Fparentrev,
          ParentDescription = GetDescriptionByPart(parent.Fparent),
          QuantityPer = (double)bom.Fqty
        };

        bomWhereUseds.Add(bwu);
      }
      return bomWhereUseds;
    }

    public List<JodBomWhereUsed> GetWhereUsedJobByPart(string partNumber, string revision)
    {
      List<JodBomWhereUsed> jodBomWhereUseds = new();
      var query = _contextInventory.JodBoms.Where(p => p.Fbompart == partNumber
                                                  && p.Fbomrev == revision)
                  .Select(x => new
                  {
                    x.Fparent,
                    x.Fparentrev,
                    x.Fjobno,
                    x.FqtyIss
                  }).ToList();
      foreach (var parent in query)
      {
        var jMast = _contextInventory.JoMasts.Where(x => x.Fjobno == parent.Fjobno)
                    .Select(j => new
                    {
                      jobNumber = parent.Fjobno,
                      parent = j.Fpartno,
                      parentrev = j.Fpartrev,
                      salesOrder = j.Fsono,
                      status = j.Fstatus.Trim(),
                      qtyNeeded = j.Fquantity,
                      qtyIssued = parent.FqtyIss
                    });

        foreach (var j in jMast)
        {
          JodBomWhereUsed jbwu = new()
          {
            JobNumber = j.jobNumber,
            ParentPart = j.parent,
            ParentRev = j.parentrev,
            SalesOrder = j.salesOrder,
            JobStatus = j.status,
            QuantityNeeded = (double)j.qtyNeeded,
            QuantityIssued = (double)j.qtyIssued
          };

          jodBomWhereUseds.Add(jbwu);
        }
      }
      return jodBomWhereUseds;

    }

    public InOnhd GetInOnhd(string partNumber)
    {
      InOnhd item = _contextInventory.InOnhds.FirstOrDefault(p => p.Fpartno == partNumber);
      return item;
    }

    public string GetDescriptionByPart(string partNumber)
    {
      return _contextInventory.Inmastxes.FirstOrDefault(p => p.Fpartno == partNumber).Fdescript;
    }

    public ApVend GetApVend(string vendorNumber)
    {
      return _contextInventory.ApVends.FirstOrDefault(v => v.Fvendno == vendorNumber);
    }

    public ItemMaster GetItemMaster(string partNumber, 
                                    ref string message, 
                                    ref MessagePriority priority)
    {
      if (!PartNumberExists(partNumber))
      {
        message = ErrorMessage.PartNotFound.GetDescription();
        priority = MessagePriority.Error;
        return null;
      }
      ItemMaster iMaster = new();

      string currentRev = GetCurrentPartRev(partNumber);
      if (string.IsNullOrWhiteSpace(currentRev))
      {
        message = ErrorMessage.MissingRevision.GetDescription();
        priority = MessagePriority.Warning;
        return null;
      }

      decimal onhand = _contextInventory.InMasts.FirstOrDefault(m =>
                       m.Fpartno == partNumber && m.Frev == currentRev).Fonhand;
      decimal proqty = _contextInventory.InMasts.FirstOrDefault(m =>
                       m.Fpartno == partNumber && m.Frev == currentRev).Fproqty; ;
      decimal book = (decimal)_contextInventory.InMasts.FirstOrDefault(m =>
                       m.Fpartno == partNumber && m.Frev == currentRev).Fbook; ;

      decimal qtyAvailable = onhand + proqty - book;

      var query = _contextInventory.Inmastxes.Where(m =>
                  (m.Fpartno == partNumber) && (m.Frev == currentRev))
                  .Select(x => new ItemMaster
                  {
                    PartNumber = partNumber,
                    Description = x.Fdescript,
                    Revision = currentRev,
                    StandardCost = x.Fstdcost,
                    UnitOfMeasure = x.Fmeasure,
                    Location = x.Fbin1,
                    Memo = x.Fstdmemo,
                    Comment = x.Fcomment,
                    QuantityOnHand = onhand,
                    QuantityAvailable = qtyAvailable,
                    Status = x.Fcstscode == "A" ? "Active" : "Obsolete",
                    UserDefinedMemo = x.Fmusrmemo1
                  }).Take(1);

      var vendno = _contextInventory.InVends.Where(i => i.Fpartno == partNumber)
        .OrderBy(i => i.Fpriority)
        .Select(x => new VendorForPart
        {
          VendorNumber = x.Fvendno,
          PartNumber = x.Fvpartno,
          Description = x.Fvptdes,
          Comments = x.Fvcomment,

          Fpartno = x.Fpartno,
          Fpartrev = x.Fpartrev,
          Fpriority = x.Fpriority,
          Fvendno = x.Fvendno,
          Fvconvfact = x.Fvconvfact,
          Fvlastpc = x.Fvlastpc,
          Fvlastpd = x.Fvlastpd,
          Fvlastpq = x.Fvlastpq,
          Fvleadtime = x.Fvleadtime,
          Fvmeasure = x.Fvmeasure,
          Fvpartno = x.Fpartno,
          Fvptdes = x.Fvptdes,
          Fcjrdict = x.Fcjrdict,
          TimestampColumn = x.TimestampColumn,
          IdentityColumn = x.IdentityColumn,
          Fvcomment = x.Fvcomment,
          Fac = x.Fac,
          Fcudrev = x.Fcudrev,
          Fclastpono = x.Fclastpono,
          Fvlasttxnpc = x.Fvlasttxnpc,
          Fvfactor = x.Fvfactor,
          Fccurid = x.Fccurid,
          Fmulticurr = x.Fmulticurr,
          CreatedDate = x.CreatedDate,
          ModifiedDate = x.ModifiedDate
        }).ToList();

      foreach (var item in vendno)
      {
        item.VendorName = GetVendorNameByAcctNumber(item.VendorNumber);
      }

      foreach (var q in query)
      {
        iMaster = q;
        iMaster.VendorInformation = vendno;
      }

      return iMaster;
    }

    public string GetVendorNameByAcctNumber(string accountNumber)
    {
      return _contextInventory.ApVends.FirstOrDefault(a => a.Fvendno == accountNumber).Fcompany;
    }

    public IEnumerable<PartSimple> SearchByDescriptionStartsWith(string description)
    {
      var query = _contextInventory.Inmastxes.Where(d => d.Fdescript.StartsWith(description))
        .Select(x => new PartSimple
        {
          PartNumber = x.Fpartno,
          Revision = x.Frev,
          Description = x.Fdescript,
          UnitOfMeasure = x.Fmeasure,
          StandardCost = x.Fstdcost
        });
      return query;
    }

    public IEnumerable<PartSimple> SearchByDescriptionEndsWith(string description)
    {
      var query = _contextInventory.Inmastxes.Where(d => d.Fdescript.EndsWith(description))
        .Select(x => new PartSimple
        {
          PartNumber = x.Fpartno,
          Revision = x.Frev,
          Description = x.Fdescript,
          UnitOfMeasure = x.Fmeasure,
          StandardCost = x.Fstdcost
        });
      return query;
    }

    public IEnumerable<PartSimple> SearchByDescriptionContains(string description)
    {
      var query = _contextInventory.Inmastxes.Where(d => d.Fdescript.Contains(description))
        .Select(x => new PartSimple
        {
          PartNumber = x.Fpartno,
          Revision = x.Frev,
          Description = x.Fdescript,
          UnitOfMeasure = x.Fmeasure,
          StandardCost = x.Fstdcost
        });
      return query;
    }

    public IEnumerable<PartSimple> SearchAdvanced(AdvancedSearchParameter searchParameter)
    {
      IQueryable<Inmastx> query;
      if (searchParameter.SearchByFirst == Enums.SearchBy.StartsWith)
        query = _contextInventory.Inmastxes.Where(d => d.Fdescript.StartsWith(searchParameter.SearchTermFirst));
      else if (searchParameter.SearchByFirst == Enums.SearchBy.EndsWith)
        query = _contextInventory.Inmastxes.Where(d => d.Fdescript.EndsWith(searchParameter.SearchTermFirst));
      else
        query = _contextInventory.Inmastxes.Where(d => d.Fdescript.Contains(searchParameter.SearchTermFirst));

      string term = searchParameter.SearchTerms[0];
      if ((searchParameter.IsEnabled0) && !string.IsNullOrWhiteSpace(term))
        query = AddSubQuery(query, searchParameter.SearchBy0, term);

      term = searchParameter.SearchTerms[1];
      if ((searchParameter.IsEnabled1) && !string.IsNullOrWhiteSpace(term))
        query = AddSubQuery(query, searchParameter.SearchBy1, term);

      term = searchParameter.SearchTerms[2];
      if ((searchParameter.IsEnabled2) && !string.IsNullOrWhiteSpace(term))
        query = AddSubQuery(query, searchParameter.SearchBy2, term);

      var q1 = query.Select(x => new PartSimple
      {
        PartNumber = x.Fpartno,
        Revision = x.Frev,
        Description = x.Fdescript,
        UnitOfMeasure = x.Fmeasure,
        StandardCost = x.Fstdcost
      });

      return q1;
    }

    public IEnumerable<PartSimple> SearchByVendorPartNumber(string vendorPartNumber)
    {
      var query = _contextInventory.InVends.Where(v => v.Fvpartno.Contains(vendorPartNumber))
        .Select(x => new PartSimple
        {
          PartNumber = x.Fpartno,
          Revision = x.Fpartrev,
          Description = x.Fvptdes,
          UnitOfMeasure = x.Fvmeasure
        });
      return query;
    }

    public IEnumerable<PartSimple> SearchByPartialPartNumber(string parameter)
    {
      var query = _contextInventory.Inmastxes.Where(m => m.Fpartno.Contains(parameter))
        .Select(x => new PartSimple
        {
          PartNumber = x.Fpartno,
          Revision = x.Frev,
          Description = x.Fdescript,
          UnitOfMeasure = x.Fmeasure,
          StandardCost = x.Fstdcost
        });
      return query;
    }

    private static IQueryable<Inmastx> AddSubQuery(IQueryable<Inmastx> query,
                                                  Enums.SearchBy searchBy,
                                                  string searchTerm)
    {
      if (searchBy == Enums.SearchBy.StartsWith)
        query = query.Where(d => d.Fdescript.StartsWith(searchTerm));
      else if (searchBy == Enums.SearchBy.EndsWith)
        query = query.Where(d => d.Fdescript.EndsWith(searchTerm));
      else
        query = query.Where(d => d.Fdescript.Contains(searchTerm));
      return query;
    }

    public SoMast GetSalesOrder(string salesOrderNumber)
    {
      return _contextInventory.SoMasts.FirstOrDefault(s =>
                  s.Fsono == salesOrderNumber);
    }

    public IEnumerable<SalesOrderItem> GetSalesOrderItems(string salesOrderNumber)
    {
      var query = from item in _contextInventory.SoItems
                  join price in _contextInventory.Sorels
                  on item.Fsono equals price.Fsono
                  where ((item.Fsono == salesOrderNumber)
                  && (item.Finumber == price.Finumber))
                  select new SalesOrderItem
                  {
                    SequenceNumber = item.Fenumber.Trim(),
                    PartNumber = item.Fpartno.Trim(),
                    Revision = item.Fpartrev,
                    Description = item.Fdesc,
                    Quantity = (double)item.FnAltQty,
                    UnitOfMeasure = item.FcAltUm,
                    UnitPrice = price.Funetprice,
                    ItemMemo = item.Fdescmemo
                  };
      return query;
    }

    public JoMast GetJobOrderByNumber(string jobOrderNumber)
    {
      return _contextInventory.JoMasts.FirstOrDefault(m =>
              m.Fjobno == jobOrderNumber);
    }

    public IEnumerable<JobOrderSimple> GetJobOrderByJO(string jobOrderNumber)
    {
      var query = from item in _contextInventory.JoItems
                  join jm in _contextInventory.JoMasts
                  on item.Fjobno equals jm.Fjobno
                  where (jm.Fjobno.StartsWith(jobOrderNumber))
                  select new JobOrderSimple
                  {
                    JobOrderNumber = jm.Fjobno,
                    SalesOrderNumber = jm.Fsono,
                    PartNumber = item.Fpartno,
                    Status = jm.Fstatus,
                    Quantity = (double)jm.Fquantity,
                    DueDate = jm.FddueDate
                  };
      return query;
    }

    public IEnumerable<JobOrderSimple> GetJobOrderBySalesOrder(string salesOrderNumber)
    {
      var query = from item in _contextInventory.JoItems
                  join jm in _contextInventory.JoMasts
                  on item.Fjobno equals jm.Fjobno
                  where (jm.Fsono == salesOrderNumber)
                  select new JobOrderSimple
                  {
                    JobOrderNumber = jm.Fjobno,
                    SalesOrderNumber = jm.Fsono,
                    PartNumber = item.Fpartno,
                    Status = jm.Fstatus,
                    Quantity = (double)jm.Fquantity,
                    DueDate = jm.FddueDate
                  };
      return query;
    }

    public IEnumerable<JobOrderSimple> GetJobOrderByPart(string partNumber)
    {
      var query = from item in _contextInventory.JoItems
                  join jm in _contextInventory.JoMasts
                  on item.Fjobno equals jm.Fjobno
                  where (item.Fpartno == partNumber)
                  select new JobOrderSimple
                  {
                    JobOrderNumber = jm.Fjobno,
                    SalesOrderNumber = jm.Fsono,
                    PartNumber = item.Fpartno,
                    Status = jm.Fstatus,
                    Quantity = (double)jm.Fquantity,
                    DueDate = jm.FddueDate
                  };
      return query;
    }

    public IEnumerable<JobOrderDetail> GetJobOrdersDetail(string jobOrderNumber)
    {
      var query = from rtg in _contextInventory.JodRtgs
                  join m in _contextInventory.JoMasts
                  on rtg.Fjobno equals m.Fjobno
                  where rtg.Fjobno == jobOrderNumber
                  select new JobOrderDetail
                  {
                    OperationID = rtg.Foperno.ToString(),
                    WorkCenter = rtg.FproId,
                    EstimatedHours = (double)m.Fquantity * (double)rtg.Fuprodtime,
                    ActualHours = (double)rtg.FprodTim,
                    LastCompletionDate = rtg.FcompDate,
                    ScheduleStart = rtg.Factschdst,
                    ScheduleFinish = rtg.Factschdfn
                  };
      return query;
    }

    public JoItem GetJobItemByJobNumber(string jobOrderNumber)
    {
      return _contextInventory.JoItems.FirstOrDefault(j =>
                  j.Fjobno == jobOrderNumber);
    }

    private string GetCurrentPartRev(string partNumber)
    {
      return _contextInventory.Invcurs.FirstOrDefault(c =>
                                c.Fcpartno == partNumber).Fcpartrev;
    }

    private bool PartNumberExists(string partNumber)
    {
      return _contextInventory.Inmastxes.Any(m => m.Fpartno == partNumber);
    }

  }
}


