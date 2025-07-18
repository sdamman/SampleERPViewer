using SEV.Domain.Models;
using SEV.Domain.Models.Messaging;
using System.Collections.Generic;

namespace SEV.Data.Repositories
{
  public interface IRepositoryInventory 
  {
    
    Inmastx GetPartByNumber(string partNumber);
    IEnumerable<BomSimple> GetBomOfPart(string partNumber);
    List<BomWhereUsed> GetWhereUsedByPart(string partNumber, string revision);
    List<JodBomWhereUsed> GetWhereUsedJobByPart(string partNumber, string revision);
    InOnhd GetInOnhd(string partNumber);
    string GetDescriptionByPart(string partNumber);
    ApVend GetApVend(string vendorNumber);
    ItemMaster GetItemMaster(string partNumber, ref string message, ref MessagePriority priority);
    string GetVendorNameByAcctNumber(string accountNumber);
    IEnumerable<PartSimple> SearchByDescriptionStartsWith(string description);
    IEnumerable<PartSimple> SearchByDescriptionEndsWith(string description);
    IEnumerable<PartSimple> SearchByDescriptionContains(string description);
    IEnumerable<PartSimple> SearchAdvanced(AdvancedSearchParameter searchParameter);
    IEnumerable<PartSimple> SearchByVendorPartNumber(string vendorPartNumber);
    IEnumerable<PartSimple> SearchByPartialPartNumber(string parameter);
    SoMast GetSalesOrder(string salesOrderNumber);
    IEnumerable<SalesOrderItem> GetSalesOrderItems(string salesOrderNumber);
    JoMast GetJobOrderByNumber(string jobOrderNumber);
    IEnumerable<JobOrderSimple> GetJobOrderByJO(string jobOrderNumber);
    IEnumerable<JobOrderSimple> GetJobOrderByPart(string partNumber);
    IEnumerable<JobOrderSimple> GetJobOrderBySalesOrder(string salesOrderNumber);
    JoItem GetJobItemByJobNumber(string jobOrderNumber);
    IEnumerable<JobOrderDetail> GetJobOrdersDetail(string jobOrderNumber);
  }
}
