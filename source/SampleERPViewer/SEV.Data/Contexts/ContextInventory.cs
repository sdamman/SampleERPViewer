using SEV.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace SEV.Data.Contexts;

public partial class ContextInventory : DbContext
{
  private readonly string connectionString = null;

  public ContextInventory(string connectString)
  {
    connectionString = connectString;
  }

  public ContextInventory(DbContextOptions<ContextInventory> options)
      : base(options)
  {
  }

  public virtual DbSet<InMast> InMasts { get; set; }
  public virtual DbSet<Inmastx> Inmastxes { get; set; }
  public virtual DbSet<InBom> InBoms { get; set; }
  public virtual DbSet<InVend> InVends { get; set; }
  public virtual DbSet<InOnhd> InOnhds { get; set; }
  public virtual DbSet<ApVend> ApVends { get; set; }
  public virtual DbSet<JoItem> JoItems { get; set; }
  public virtual DbSet<JodBom> JodBoms { get; set; }
  public virtual DbSet<JodRtg> JodRtgs { get; set; }
  public virtual DbSet<JoMast> JoMasts { get; set; }
  public virtual DbSet<SoMast> SoMasts { get; set; }
  public virtual DbSet<SoItem> SoItems { get; set; }
  public virtual DbSet<Sorel> Sorels { get; set; }
  public virtual DbSet<Invcur> Invcurs { get; set; }


  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer(connectionString);


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<InBom>(entity =>
    {
      entity
              .HasNoKey()
              .ToTable("inboms", "dbo", tb =>
              {
                tb.HasTrigger("Audit_Trigger_For_inboms_After_Delete");
                tb.HasTrigger("Audit_Trigger_For_inboms_After_Insert");
                tb.HasTrigger("Audit_Trigger_For_inboms_After_Update");
                tb.HasTrigger("td_INBOMS");
                tb.HasTrigger("ti_INBOMS");
                tb.HasTrigger("tu_INBOMS");
              });

      entity.HasIndex(e => new { e.Fcomponent, e.Fcomprev, e.Pfacilityid, e.Fparent, e.Fparentrev, e.Cfacilityid }, "COMPPAR");

      entity.HasIndex(e => new { e.Fparent, e.Fparentrev, e.Cfacilityid, e.Fcomponent, e.Fcomprev, e.Fitem, e.Pfacilityid }, "PARCOMP");

      entity.HasIndex(e => new { e.Fparent, e.Fparentrev, e.Fitem, e.Cfacilityid, e.Fcomponent, e.Pfacilityid }, "PARITEMC");

      entity.HasIndex(e => new { e.Fparent, e.Fparentrev, e.Fnoperno, e.Cfacilityid, e.Fcomponent, e.Fcomprev, e.Pfacilityid }, "byparcomp");

      entity.HasIndex(e => e.IdentityColumn, "identity_column_idx1")
              .IsUnique()
              .IsClustered();

      entity.Property(e => e.Cfacilityid)
              .IsRequired()
              .HasMaxLength(20)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("cfacilityid");
      entity.Property(e => e.CreatedDate).HasColumnType("datetime");
      entity.Property(e => e.FOrigQty)
              .HasColumnType("numeric(15, 5)")
              .HasColumnName("fOrigQty");
      entity.Property(e => e.Fbommemo)
              .IsRequired()
              .IsUnicode(false)
              .HasColumnName("fbommemo");
      entity.Property(e => e.FcSource)
              .IsRequired()
              .HasMaxLength(10)
              .IsUnicode(false)
              .HasColumnName("fcSource");
      entity.Property(e => e.Fcomponent)
              .IsRequired()
              .HasMaxLength(25)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("fcomponent");
      entity.Property(e => e.Fcomprev)
              .IsRequired()
              .HasMaxLength(3)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("fcomprev");
      entity.Property(e => e.Fcompudrev)
              .IsRequired()
              .HasMaxLength(3)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("fcompudrev");
      entity.Property(e => e.Fcparudrev)
              .IsRequired()
              .HasMaxLength(3)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("fcparudrev");
      entity.Property(e => e.FendEfDt)
              .HasColumnType("datetime")
              .HasColumnName("fend_ef_dt");
      entity.Property(e => e.Fitem)
              .IsRequired()
              .HasMaxLength(6)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("fitem");
      entity.Property(e => e.FlFssvc).HasColumnName("flFSSvc");
      entity.Property(e => e.Flextend).HasColumnName("flextend");
      entity.Property(e => e.Fltooling).HasColumnName("fltooling");
      entity.Property(e => e.Fmemoexist)
              .IsRequired()
              .HasMaxLength(1)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("fmemoexist");
      entity.Property(e => e.Fndbrmod).HasColumnName("fndbrmod");
      entity.Property(e => e.Fnoperno).HasColumnName("fnoperno");
      entity.Property(e => e.Fparent)
              .IsRequired()
              .HasMaxLength(25)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("fparent");
      entity.Property(e => e.Fparentrev)
              .IsRequired()
              .HasMaxLength(3)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("fparentrev");
      entity.Property(e => e.Fqty)
              .HasColumnType("numeric(15, 5)")
              .HasColumnName("fqty");
      entity.Property(e => e.Freqd)
              .IsRequired()
              .HasMaxLength(1)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("freqd");
      entity.Property(e => e.FstEfDt)
              .HasColumnType("datetime")
              .HasColumnName("fst_ef_dt");
      entity.Property(e => e.IdentityColumn)
              .ValueGeneratedOnAdd()
              .HasColumnName("identity_column");
      entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
      entity.Property(e => e.Pfacilityid)
              .IsRequired()
              .HasMaxLength(20)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("pfacilityid");
      entity.Property(e => e.TimestampColumn)
              .IsRowVersion()
              .IsConcurrencyToken()
              .HasColumnName("timestamp_column");
    });

    modelBuilder.Entity<InVend>(entity =>
    {
      entity
          .HasNoKey()
          .ToTable("invend", "dbo", tb =>
          {
            tb.HasTrigger("Audit_Trigger_For_invend_After_Delete");
            tb.HasTrigger("Audit_Trigger_For_invend_After_Insert");
            tb.HasTrigger("Audit_Trigger_For_invend_After_Update");
          });

      entity.HasIndex(e => new { e.Fpartno, e.Fpartrev, e.Fpriority, e.Fac }, "PARTPRI");

      entity.HasIndex(e => new { e.Fpartno, e.Fpartrev, e.Fvendno, e.Fac }, "PARTVEND");

      entity.HasIndex(e => new { e.Fvendno, e.Fac, e.Fpartno, e.Fpartrev }, "VENDNO");

      entity.HasIndex(e => new { e.Fvendno, e.Fac, e.Fvpartno }, "VENVPART");

      entity.HasIndex(e => e.IdentityColumn, "identity_column_idx1")
          .IsUnique()
          .IsClustered();

      entity.Property(e => e.CreatedDate).HasColumnType("datetime");
      entity.Property(e => e.Fac)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fac");
      entity.Property(e => e.Fccurid)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fccurid");
      entity.Property(e => e.Fcjrdict)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcjrdict");
      entity.Property(e => e.Fclastpono)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .HasColumnName("fclastpono");
      entity.Property(e => e.Fcudrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcudrev");
      entity.Property(e => e.Fmulticurr).HasColumnName("fmulticurr");
      entity.Property(e => e.Fpartno)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartno");
      entity.Property(e => e.Fpartrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartrev");
      entity.Property(e => e.Fpriority)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpriority");
      entity.Property(e => e.Fvcomment)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fvcomment");
      entity.Property(e => e.Fvconvfact)
          .HasColumnType("numeric(13, 9)")
          .HasColumnName("fvconvfact");
      entity.Property(e => e.Fvendno)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fvendno");
      entity.Property(e => e.Fvfactor)
          .HasColumnType("numeric(22, 10)")
          .HasColumnName("fvfactor");
      entity.Property(e => e.Fvlastapno)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fvlastapno");
      entity.Property(e => e.Fvlastpc)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fvlastpc");
      entity.Property(e => e.Fvlastpd)
          .HasColumnType("datetime")
          .HasColumnName("fvlastpd");
      entity.Property(e => e.Fvlastpq)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fvlastpq");
      entity.Property(e => e.Fvlasttxnpc)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fvlasttxnpc");
      entity.Property(e => e.Fvleadtime)
          .HasColumnType("numeric(7, 1)")
          .HasColumnName("fvleadtime");
      entity.Property(e => e.Fvmeasure)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fvmeasure");
      entity.Property(e => e.Fvpartno)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fvpartno");
      entity.Property(e => e.Fvptdes)
          .IsRequired()
          .HasMaxLength(35)
          .IsUnicode(false)
          .HasColumnName("fvptdes");
      entity.Property(e => e.IdentityColumn)
          .ValueGeneratedOnAdd()
          .HasColumnName("identity_column");
      entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
    });

    modelBuilder.Entity<InMast>(entity =>
    {
      entity
          .HasNoKey()
          .ToView("Inmast", "dbo");

      entity.Property(e => e.CreatedDate).HasColumnType("datetime");
      entity.Property(e => e.F2costcode)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("f2costcode");
      entity.Property(e => e.F2displcst)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2displcst");
      entity.Property(e => e.F2dispmcst)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2dispmcst");
      entity.Property(e => e.F2dispocst)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2dispocst");
      entity.Property(e => e.F2disptcst)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2disptcst");
      entity.Property(e => e.F2labcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2labcost");
      entity.Property(e => e.F2matlcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2matlcost");
      entity.Property(e => e.F2ovhdcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2ovhdcost");
      entity.Property(e => e.F2totcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2totcost");
      entity.Property(e => e.Fabccode)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fabccode");
      entity.Property(e => e.Fac)
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fac");
      entity.Property(e => e.Favgcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("favgcost");
      entity.Property(e => e.Fbin1)
          .IsRequired()
          .HasMaxLength(14)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbin1");
      entity.Property(e => e.Fbinbfdef)
          .IsRequired()
          .HasMaxLength(14)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbinbfdef");
      entity.Property(e => e.Fbook)
          .HasColumnType("numeric(38, 5)")
          .HasColumnName("fbook");
      entity.Property(e => e.Fbulkissue)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbulkissue");
      entity.Property(e => e.Fbuyer)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbuyer");
      entity.Property(e => e.FcSlxprod)
          .IsRequired()
          .HasMaxLength(12)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcSLXProd");
      entity.Property(e => e.FcalcLead)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcalc_lead");
      entity.Property(e => e.Fcbackflsh)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcbackflsh");
      entity.Property(e => e.Fccadfile1)
          .IsRequired()
          .HasMaxLength(250)
          .IsUnicode(false)
          .HasColumnName("fccadfile1");
      entity.Property(e => e.Fccadfile2)
          .IsRequired()
          .HasMaxLength(250)
          .IsUnicode(false)
          .HasColumnName("fccadfile2");
      entity.Property(e => e.Fccadfile3)
          .IsRequired()
          .HasMaxLength(250)
          .IsUnicode(false)
          .HasColumnName("fccadfile3");
      entity.Property(e => e.Fcclass)
          .IsRequired()
          .HasMaxLength(12)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcclass");
      entity.Property(e => e.Fcdncfile)
          .IsRequired()
          .HasMaxLength(80)
          .IsUnicode(false)
          .HasColumnName("fcdncfile");
      entity.Property(e => e.Fcjrdict)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcjrdict");
      entity.Property(e => e.Fclotext)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fclotext");
      entity.Property(e => e.Fcnts).HasColumnName("fcnts");
      entity.Property(e => e.Fcomment)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fcomment");
      entity.Property(e => e.Fcopymemo)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcopymemo");
      entity.Property(e => e.Fcostcode)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcostcode");
      entity.Property(e => e.Fcplnclass)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcplnclass");
      entity.Property(e => e.Fcpurchase)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcpurchase");
      entity.Property(e => e.Fcratedisc)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcratedisc");
      entity.Property(e => e.Fcstperinv)
          .HasColumnType("numeric(13, 9)")
          .HasColumnName("fcstperinv");
      entity.Property(e => e.Fcstscode)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcstscode");
      entity.Property(e => e.Fcudrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcudrev");
      entity.Property(e => e.Fcusrchr1)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcusrchr1");
      entity.Property(e => e.Fcusrchr2)
          .IsRequired()
          .HasMaxLength(40)
          .IsUnicode(false)
          .HasColumnName("fcusrchr2");
      entity.Property(e => e.Fcusrchr3)
          .IsRequired()
          .HasMaxLength(40)
          .IsUnicode(false)
          .HasColumnName("fcusrchr3");
      entity.Property(e => e.Fddcrefdat)
          .HasColumnType("datetime")
          .HasColumnName("fddcrefdat");
      entity.Property(e => e.Fdescript)
          .IsRequired()
          .HasMaxLength(35)
          .IsUnicode(false)
          .HasColumnName("fdescript");
      entity.Property(e => e.Fdisplcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fdisplcost");
      entity.Property(e => e.Fdispmcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fdispmcost");
      entity.Property(e => e.Fdispocost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fdispocost");
      entity.Property(e => e.Fdispprice)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fdispprice");
      entity.Property(e => e.Fdisptcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fdisptcost");
      entity.Property(e => e.Fdlastpc)
          .HasColumnType("datetime")
          .HasColumnName("fdlastpc");
      entity.Property(e => e.Fdrawno)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fdrawno");
      entity.Property(e => e.Fdrawsize)
          .IsRequired()
          .HasMaxLength(2)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fdrawsize");
      entity.Property(e => e.Fdusrdate1)
          .HasColumnType("datetime")
          .HasColumnName("fdusrdate1");
      entity.Property(e => e.Fdvenfence)
          .HasColumnType("datetime")
          .HasColumnName("fdvenfence");
      entity.Property(e => e.Fecdesc)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fecdesc");
      entity.Property(e => e.Fecfulldesc)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fecfulldesc");
      entity.Property(e => e.Fecname)
          .IsRequired()
          .HasMaxLength(400)
          .IsUnicode(false)
          .HasColumnName("fecname");
      entity.Property(e => e.FecprodId)
          .IsRequired()
          .HasMaxLength(36)
          .IsUnicode(false)
          .HasColumnName("fecprodId");
      entity.Property(e => e.Fecsku)
          .IsRequired()
          .HasMaxLength(400)
          .IsUnicode(false)
          .HasColumnName("fecsku");
      entity.Property(e => e.Fecsync).HasColumnName("fecsync");
      entity.Property(e => e.Fecsyncdt)
          .HasColumnType("datetime")
          .HasColumnName("fecsyncdt");
      entity.Property(e => e.Fendqty1)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fendqty1");
      entity.Property(e => e.Fendqty10)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty10");
      entity.Property(e => e.Fendqty11)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty11");
      entity.Property(e => e.Fendqty12)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty12");
      entity.Property(e => e.Fendqty2)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty2");
      entity.Property(e => e.Fendqty3)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty3");
      entity.Property(e => e.Fendqty4)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty4");
      entity.Property(e => e.Fendqty5)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty5");
      entity.Property(e => e.Fendqty6)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty6");
      entity.Property(e => e.Fendqty7)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty7");
      entity.Property(e => e.Fendqty8)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty8");
      entity.Property(e => e.Fendqty9)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty9");
      entity.Property(e => e.Fgroup)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fgroup");
      entity.Property(e => e.FiPcsOnHd).HasColumnName("fiPcsOnHd");
      entity.Property(e => e.Fidims).HasColumnName("fidims");
      entity.Property(e => e.Finspect)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("finspect");
      entity.Property(e => e.Fintransit)
          .HasColumnType("numeric(38, 5)")
          .HasColumnName("fintransit");
      entity.Property(e => e.FlFsrtn).HasColumnName("flFSRtn");
      entity.Property(e => e.FlHoldStoc).HasColumnName("flHoldStoc");
      entity.Property(e => e.FlLatefact).HasColumnName("flLatefact");
      entity.Property(e => e.FlPurBuf).HasColumnName("flPurBuf");
      entity.Property(e => e.FlSendSlx).HasColumnName("flSendSLX");
      entity.Property(e => e.FlSobuf).HasColumnName("flSOBuf");
      entity.Property(e => e.FlSynchOn).HasColumnName("flSynchOn");
      entity.Property(e => e.Flabcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("flabcost");
      entity.Property(e => e.Flaplpart).HasColumnName("flaplpart");
      entity.Property(e => e.Flastcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("flastcost");
      entity.Property(e => e.Flasteoc)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("flasteoc");
      entity.Property(e => e.Flastiss)
          .HasColumnType("datetime")
          .HasColumnName("flastiss");
      entity.Property(e => e.Flastrcpt)
          .HasColumnType("datetime")
          .HasColumnName("flastrcpt");
      entity.Property(e => e.Flchgpnd).HasColumnName("flchgpnd");
      entity.Property(e => e.Flcnstrpur).HasColumnName("flcnstrpur");
      entity.Property(e => e.Flconstrnt).HasColumnName("flconstrnt");
      entity.Property(e => e.Flct)
          .HasColumnType("datetime")
          .HasColumnName("flct");
      entity.Property(e => e.Fldctracke).HasColumnName("fldctracke");
      entity.Property(e => e.Fleadtime)
          .HasColumnType("numeric(7, 1)")
          .HasColumnName("fleadtime");
      entity.Property(e => e.Flexpreqd).HasColumnName("flexpreqd");
      entity.Property(e => e.Flfanpart).HasColumnName("flfanpart");
      entity.Property(e => e.Flistaxabl).HasColumnName("flistaxabl");
      entity.Property(e => e.Fllotreqd).HasColumnName("fllotreqd");
      entity.Property(e => e.Flocate1)
          .IsRequired()
          .HasMaxLength(14)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("flocate1");
      entity.Property(e => e.Flocbfdef)
          .IsRequired()
          .HasMaxLength(14)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("flocbfdef");
      entity.Property(e => e.Fluseudrev).HasColumnName("fluseudrev");
      entity.Property(e => e.Fmatlcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fmatlcost");
      entity.Property(e => e.Fmeasure)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fmeasure");
      entity.Property(e => e.Fmeasure2)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fmeasure2");
      entity.Property(e => e.Fmtdiss)
          .HasColumnType("numeric(38, 5)")
          .HasColumnName("fmtdiss");
      entity.Property(e => e.Fmtdrcpt)
          .HasColumnType("numeric(38, 5)")
          .HasColumnName("fmtdrcpt");
      entity.Property(e => e.Fmusrmemo1)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fmusrmemo1");
      entity.Property(e => e.FnHoldStoc)
          .HasColumnType("numeric(4, 2)")
          .HasColumnName("fnHoldStoc");
      entity.Property(e => e.FnLndToMfg)
          .HasColumnType("numeric(16, 5)")
          .HasColumnName("fnLndToMfg");
      entity.Property(e => e.FnPonHand)
          .HasColumnType("numeric(16, 5)")
          .HasColumnName("fnPOnHand");
      entity.Property(e => e.Fndbrmod).HasColumnName("fndbrmod");
      entity.Property(e => e.Fndcduty)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fndcduty");
      entity.Property(e => e.Fndcfreigh)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fndcfreigh");
      entity.Property(e => e.Fndcmisc)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fndcmisc");
      entity.Property(e => e.Fndctax)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fndctax");
      entity.Property(e => e.Fnfanaglvl).HasColumnName("fnfanaglvl");
      entity.Property(e => e.Fnifttime)
          .HasColumnType("numeric(7, 1)")
          .HasColumnName("fnifttime");
      entity.Property(e => e.Fnlatefact)
          .HasColumnType("numeric(4, 2)")
          .HasColumnName("fnlatefact");
      entity.Property(e => e.Fnonnetqty)
          .HasColumnType("numeric(38, 5)")
          .HasColumnName("fnonnetqty");
      entity.Property(e => e.Fnpurbuf).HasColumnName("fnpurbuf");
      entity.Property(e => e.Fnsobuf).HasColumnName("fnsobuf");
      entity.Property(e => e.Fnusrcur1)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fnusrcur1");
      entity.Property(e => e.Fnusrqty1)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fnusrqty1");
      entity.Property(e => e.Fnweight)
          .HasColumnType("numeric(10, 3)")
          .HasColumnName("fnweight");
      entity.Property(e => e.Fonhand)
          .HasColumnType("numeric(38, 5)")
          .HasColumnName("fonhand");
      entity.Property(e => e.Fonorder)
          .HasColumnType("numeric(38, 5)")
          .HasColumnName("fonorder");
      entity.Property(e => e.Fovhdcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fovhdcost");
      entity.Property(e => e.Fpartno)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartno");
      entity.Property(e => e.Fprice)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fprice");
      entity.Property(e => e.Fprodcl)
          .IsRequired()
          .HasMaxLength(4)
          .IsUnicode(false)
          .HasColumnName("fprodcl");
      entity.Property(e => e.Fproqty)
          .HasColumnType("numeric(38, 5)")
          .HasColumnName("fproqty");
      entity.Property(e => e.Fqtyinspec)
          .HasColumnType("numeric(38, 5)")
          .HasColumnName("fqtyinspec");
      entity.Property(e => e.Freordqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("freordqty");
      entity.Property(e => e.Frev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("frev");
      entity.Property(e => e.Frevdt)
          .HasColumnType("datetime")
          .HasColumnName("frevdt");
      entity.Property(e => e.Frolledup)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("frolledup");
      entity.Property(e => e.Fsafety)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fsafety");
      entity.Property(e => e.Fschecode)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fschecode");
      entity.Property(e => e.Fschedtype)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fschedtype");
      entity.Property(e => e.Fshipvia)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fshipvia");
      entity.Property(e => e.Fsource)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fsource");
      entity.Property(e => e.Fstdcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fstdcost");
      entity.Property(e => e.Fstdmemo)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fstdmemo");
      entity.Property(e => e.Ftaxable).HasColumnName("ftaxable");
      entity.Property(e => e.Fuprodtime)
          .HasColumnType("numeric(9, 3)")
          .HasColumnName("fuprodtime");
      entity.Property(e => e.Fyield)
          .HasColumnType("numeric(8, 3)")
          .HasColumnName("fyield");
      entity.Property(e => e.Fytdiss)
          .HasColumnType("numeric(38, 5)")
          .HasColumnName("fytdiss");
      entity.Property(e => e.Fytdrcpt)
          .HasColumnType("numeric(38, 5)")
          .HasColumnName("fytdrcpt");
      entity.Property(e => e.IdentityColumn).HasColumnName("identity_column");
      entity.Property(e => e.Itcfixed)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("itcfixed");
      entity.Property(e => e.Itcunit)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("itcunit");
      entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
      entity.Property(e => e.SchedDate).HasColumnType("datetime");
      entity.Property(e => e.Sfac)
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("sfac");
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
    });

    modelBuilder.Entity<Inmastx>(entity =>
    {
      entity
          .HasNoKey()
          .ToTable("inmastx", "dbo", tb =>
          {
            tb.HasTrigger("Audit_Trigger_For_inmastx_After_Delete");
            tb.HasTrigger("Audit_Trigger_For_inmastx_After_Insert");
            tb.HasTrigger("Audit_Trigger_For_inmastx_After_Update");
            tb.HasTrigger("inmastx_integrationdelete");
            tb.HasTrigger("td_INMASTX");
            tb.HasTrigger("ti_INMASTX");
            tb.HasTrigger("tu_INMASTX");
          });

      entity.HasIndex(e => new { e.Fpartno, e.Frev, e.Fac }, "PARTNO2");

      entity.HasIndex(e => new { e.Fpartno, e.Frev, e.Fbuyer, e.Fac }, "PLANNER");

      entity.HasIndex(e => e.Fbuyer, "buyer");

      entity.HasIndex(e => new { e.Fdescript, e.Fac, e.Fpartno, e.Frev }, "descpart");

      entity.HasIndex(e => e.Fidims, "fiDims");

      entity.HasIndex(e => e.Fgroup, "group_");

      entity.HasIndex(e => e.IdentityColumn, "identity_column_idx1")
          .IsUnique()
          .IsClustered();

      entity.HasIndex(e => new { e.Fpartno, e.Frev, e.Fac, e.IdentityColumn }, "idx_inmastx_partrevfac");

      entity.HasIndex(e => new { e.Flocate1, e.Fac, e.Fcstscode, e.Fsource }, "location");

      entity.HasIndex(e => e.Fprodcl, "prodclass");

      entity.HasIndex(e => new { e.Fcstscode, e.Fac, e.Fpartno, e.Frev }, "stscode");

      entity.Property(e => e.CreatedDate).HasColumnType("datetime");
      entity.Property(e => e.F2costcode)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("f2costcode");
      entity.Property(e => e.F2displcst)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2displcst");
      entity.Property(e => e.F2dispmcst)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2dispmcst");
      entity.Property(e => e.F2dispocst)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2dispocst");
      entity.Property(e => e.F2disptcst)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2disptcst");
      entity.Property(e => e.F2labcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2labcost");
      entity.Property(e => e.F2matlcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2matlcost");
      entity.Property(e => e.F2ovhdcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2ovhdcost");
      entity.Property(e => e.F2totcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("f2totcost");
      entity.Property(e => e.Fabccode)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fabccode");
      entity.Property(e => e.Fac)
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fac");
      entity.Property(e => e.Favgcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("favgcost");
      entity.Property(e => e.Fbin1)
          .IsRequired()
          .HasMaxLength(14)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbin1");
      entity.Property(e => e.Fbinbfdef)
          .IsRequired()
          .HasMaxLength(14)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbinbfdef");
      entity.Property(e => e.Fbulkissue)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbulkissue");
      entity.Property(e => e.Fbuyer)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbuyer");
      entity.Property(e => e.FcSlxprod)
          .IsRequired()
          .HasMaxLength(12)
          .IsUnicode(false)
          .IsFixedLength()
          .HasComment("CRM - SLX Product ID for this part")
          .HasColumnName("fcSLXProd");
      entity.Property(e => e.FcalcLead)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcalc_lead");
      entity.Property(e => e.Fcbackflsh)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcbackflsh");
      entity.Property(e => e.Fccadfile1)
          .IsRequired()
          .HasMaxLength(250)
          .IsUnicode(false)
          .HasColumnName("fccadfile1");
      entity.Property(e => e.Fccadfile2)
          .IsRequired()
          .HasMaxLength(250)
          .IsUnicode(false)
          .HasColumnName("fccadfile2");
      entity.Property(e => e.Fccadfile3)
          .IsRequired()
          .HasMaxLength(250)
          .IsUnicode(false)
          .HasColumnName("fccadfile3");
      entity.Property(e => e.Fcclass)
          .IsRequired()
          .HasMaxLength(12)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcclass");
      entity.Property(e => e.Fcdncfile)
          .IsRequired()
          .HasMaxLength(80)
          .IsUnicode(false)
          .HasColumnName("fcdncfile");
      entity.Property(e => e.Fcjrdict)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcjrdict");
      entity.Property(e => e.Fclotext)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fclotext");
      entity.Property(e => e.Fcnts).HasColumnName("fcnts");
      entity.Property(e => e.Fcomment)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fcomment");
      entity.Property(e => e.Fcopymemo)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcopymemo");
      entity.Property(e => e.Fcostcode)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcostcode");
      entity.Property(e => e.Fcplnclass)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcplnclass");
      entity.Property(e => e.Fcpurchase)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcpurchase");
      entity.Property(e => e.Fcratedisc)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcratedisc");
      entity.Property(e => e.Fcstperinv)
          .HasColumnType("numeric(13, 9)")
          .HasColumnName("fcstperinv");
      entity.Property(e => e.Fcstscode)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcstscode");
      entity.Property(e => e.Fcudrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcudrev");
      entity.Property(e => e.Fcusrchr1)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcusrchr1");
      entity.Property(e => e.Fcusrchr2)
          .IsRequired()
          .HasMaxLength(40)
          .IsUnicode(false)
          .HasColumnName("fcusrchr2");
      entity.Property(e => e.Fcusrchr3)
          .IsRequired()
          .HasMaxLength(40)
          .IsUnicode(false)
          .HasColumnName("fcusrchr3");
      entity.Property(e => e.Fddcrefdat)
          .HasColumnType("datetime")
          .HasColumnName("fddcrefdat");
      entity.Property(e => e.Fdescript)
          .IsRequired()
          .HasMaxLength(35)
          .IsUnicode(false)
          .HasColumnName("fdescript");
      entity.Property(e => e.Fdisplcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fdisplcost");
      entity.Property(e => e.Fdispmcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fdispmcost");
      entity.Property(e => e.Fdispocost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fdispocost");
      entity.Property(e => e.Fdispprice)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fdispprice");
      entity.Property(e => e.Fdisptcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fdisptcost");
      entity.Property(e => e.Fdlastpc)
          .HasColumnType("datetime")
          .HasColumnName("fdlastpc");
      entity.Property(e => e.Fdrawno)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fdrawno");
      entity.Property(e => e.Fdrawsize)
          .IsRequired()
          .HasMaxLength(2)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fdrawsize");
      entity.Property(e => e.Fdusrdate1)
          .HasColumnType("datetime")
          .HasColumnName("fdusrdate1");
      entity.Property(e => e.Fdvenfence)
          .HasColumnType("datetime")
          .HasColumnName("fdvenfence");
      entity.Property(e => e.Fecdesc)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fecdesc");
      entity.Property(e => e.Fecfulldesc)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fecfulldesc");
      entity.Property(e => e.Fecname)
          .IsRequired()
          .HasMaxLength(400)
          .IsUnicode(false)
          .HasColumnName("fecname");
      entity.Property(e => e.FecprodId)
          .IsRequired()
          .HasMaxLength(36)
          .IsUnicode(false)
          .HasColumnName("fecprodId");
      entity.Property(e => e.Fecsku)
          .IsRequired()
          .HasMaxLength(400)
          .IsUnicode(false)
          .HasColumnName("fecsku");
      entity.Property(e => e.Fecsync).HasColumnName("fecsync");
      entity.Property(e => e.Fecsyncdt)
          .HasColumnType("datetime")
          .HasColumnName("fecsyncdt");
      entity.Property(e => e.Fendqty1)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fendqty1");
      entity.Property(e => e.Fendqty10)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty10");
      entity.Property(e => e.Fendqty11)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty11");
      entity.Property(e => e.Fendqty12)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty12");
      entity.Property(e => e.Fendqty2)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty2");
      entity.Property(e => e.Fendqty3)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty3");
      entity.Property(e => e.Fendqty4)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty4");
      entity.Property(e => e.Fendqty5)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty5");
      entity.Property(e => e.Fendqty6)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty6");
      entity.Property(e => e.Fendqty7)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty7");
      entity.Property(e => e.Fendqty8)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty8");
      entity.Property(e => e.Fendqty9)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fendqty9");
      entity.Property(e => e.Fgroup)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fgroup");
      entity.Property(e => e.FiPcsOnHd).HasColumnName("fiPcsOnHd");
      entity.Property(e => e.Fidims).HasColumnName("fidims");
      entity.Property(e => e.Finspect)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("finspect");
      entity.Property(e => e.FlFsrtn).HasColumnName("flFSRtn");
      entity.Property(e => e.FlHoldStoc).HasColumnName("flHoldStoc");
      entity.Property(e => e.FlLatefact).HasColumnName("flLatefact");
      entity.Property(e => e.FlPurBuf).HasColumnName("flPurBuf");
      entity.Property(e => e.FlSendSlx)
          .HasComment("CRM - Should this part be sent to SLX")
          .HasColumnName("flSendSLX");
      entity.Property(e => e.FlSobuf).HasColumnName("flSOBuf");
      entity.Property(e => e.FlSynchOn).HasColumnName("flSynchOn");
      entity.Property(e => e.Flabcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("flabcost");
      entity.Property(e => e.Flaplpart).HasColumnName("flaplpart");
      entity.Property(e => e.Flastcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("flastcost");
      entity.Property(e => e.Flasteoc)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("flasteoc");
      entity.Property(e => e.Flchgpnd).HasColumnName("flchgpnd");
      entity.Property(e => e.Flcnstrpur).HasColumnName("flcnstrpur");
      entity.Property(e => e.Flconstrnt).HasColumnName("flconstrnt");
      entity.Property(e => e.Flct)
          .HasColumnType("datetime")
          .HasColumnName("flct");
      entity.Property(e => e.Fldctracke).HasColumnName("fldctracke");
      entity.Property(e => e.Fleadtime)
          .HasColumnType("numeric(7, 1)")
          .HasColumnName("fleadtime");
      entity.Property(e => e.Flexpreqd).HasColumnName("flexpreqd");
      entity.Property(e => e.Flfanpart).HasColumnName("flfanpart");
      entity.Property(e => e.Flistaxabl).HasColumnName("flistaxabl");
      entity.Property(e => e.Fllotreqd).HasColumnName("fllotreqd");
      entity.Property(e => e.Flocate1)
          .IsRequired()
          .HasMaxLength(14)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("flocate1");
      entity.Property(e => e.Flocbfdef)
          .IsRequired()
          .HasMaxLength(14)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("flocbfdef");
      entity.Property(e => e.Fluseudrev).HasColumnName("fluseudrev");
      entity.Property(e => e.Fmatlcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fmatlcost");
      entity.Property(e => e.Fmeasure)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fmeasure");
      entity.Property(e => e.Fmeasure2)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fmeasure2");
      entity.Property(e => e.Fmusrmemo1)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fmusrmemo1");
      entity.Property(e => e.FnHoldStoc)
          .HasColumnType("numeric(4, 2)")
          .HasColumnName("fnHoldStoc");
      entity.Property(e => e.FnLndToMfg)
          .HasColumnType("numeric(16, 5)")
          .HasColumnName("fnLndToMfg");
      entity.Property(e => e.FnPonHand)
          .HasColumnType("numeric(16, 5)")
          .HasColumnName("fnPOnHand");
      entity.Property(e => e.Fndbrmod).HasColumnName("fndbrmod");
      entity.Property(e => e.Fndcduty)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fndcduty");
      entity.Property(e => e.Fndcfreigh)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fndcfreigh");
      entity.Property(e => e.Fndcmisc)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fndcmisc");
      entity.Property(e => e.Fndctax)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fndctax");
      entity.Property(e => e.Fnfanaglvl).HasColumnName("fnfanaglvl");
      entity.Property(e => e.Fnifttime)
          .HasColumnType("numeric(7, 1)")
          .HasColumnName("fnifttime");
      entity.Property(e => e.Fnlatefact)
          .HasColumnType("numeric(4, 2)")
          .HasColumnName("fnlatefact");
      entity.Property(e => e.Fnpurbuf).HasColumnName("fnpurbuf");
      entity.Property(e => e.Fnsobuf).HasColumnName("fnsobuf");
      entity.Property(e => e.Fnusrcur1)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fnusrcur1");
      entity.Property(e => e.Fnusrqty1)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fnusrqty1");
      entity.Property(e => e.Fnweight)
          .HasColumnType("numeric(10, 3)")
          .HasColumnName("fnweight");
      entity.Property(e => e.Fovhdcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fovhdcost");
      entity.Property(e => e.Fpartno)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartno");
      entity.Property(e => e.Fprice)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fprice");
      entity.Property(e => e.Fprodcl)
          .IsRequired()
          .HasMaxLength(4)
          .IsUnicode(false)
          .HasColumnName("fprodcl");
      entity.Property(e => e.Freordqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("freordqty");
      entity.Property(e => e.Frev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("frev");
      entity.Property(e => e.Frevdt)
          .HasColumnType("datetime")
          .HasColumnName("frevdt");
      entity.Property(e => e.Frolledup)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("frolledup");
      entity.Property(e => e.Fsafety)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fsafety");
      entity.Property(e => e.Fschecode)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fschecode");
      entity.Property(e => e.Fschedtype)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fschedtype");
      entity.Property(e => e.Fshipvia)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fshipvia");
      entity.Property(e => e.Fsource)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fsource");
      entity.Property(e => e.Fstdcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fstdcost");
      entity.Property(e => e.Fstdmemo)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fstdmemo");
      entity.Property(e => e.Ftaxable).HasColumnName("ftaxable");
      entity.Property(e => e.Fuprodtime)
          .HasColumnType("numeric(9, 3)")
          .HasColumnName("fuprodtime");
      entity.Property(e => e.Fyield)
          .HasColumnType("numeric(8, 3)")
          .HasColumnName("fyield");
      entity.Property(e => e.IdentityColumn)
          .ValueGeneratedOnAdd()
          .HasColumnName("identity_column");
      entity.Property(e => e.Itcfixed)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("itcfixed");
      entity.Property(e => e.Itcunit)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("itcunit");
      entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
      entity.Property(e => e.SchedDate).HasColumnType("datetime");
      entity.Property(e => e.Sfac)
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("sfac");
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
    });

    modelBuilder.Entity<InOnhd>(entity =>
    {
      entity
          .HasNoKey()
          .ToTable("inonhd", "dbo", tb =>
          {
            tb.HasTrigger("Audit_Trigger_For_inonhd_After_Delete");
            tb.HasTrigger("Audit_Trigger_For_inonhd_After_Insert");
            tb.HasTrigger("Audit_Trigger_For_inonhd_After_Update");
            tb.HasTrigger("td_INONHD");
            tb.HasTrigger("ti_INONHD");
            tb.HasTrigger("tu_INONHD");
          });

      entity.HasIndex(e => new { e.Fpartno, e.Fpartrev, e.Flocation, e.Fbinno, e.Flot, e.Fac, e.Fexpdate }, "PARTLOCA").IsUnique();

      entity.HasIndex(e => new { e.Fpartno, e.Flocation, e.Fpartrev, e.Fac, e.Fonhand }, "QtyInmast");

      entity.HasIndex(e => e.IdentityColumn, "identity_column_idx1")
          .IsUnique()
          .IsClustered();

      entity.Property(e => e.CreatedDate).HasColumnType("datetime");
      entity.Property(e => e.Fac)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fac");
      entity.Property(e => e.Fbinno)
          .IsRequired()
          .HasMaxLength(14)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbinno");
      entity.Property(e => e.Fcudrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcudrev");
      entity.Property(e => e.Fexpdate)
          .HasColumnType("datetime")
          .HasColumnName("fexpdate");
      entity.Property(e => e.Flocation)
          .IsRequired()
          .HasMaxLength(14)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("flocation");
      entity.Property(e => e.Flot)
          .IsRequired()
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("flot");
      entity.Property(e => e.Fonhand)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fonhand");
      entity.Property(e => e.Fpartno)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartno");
      entity.Property(e => e.Fpartrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartrev");
      entity.Property(e => e.IdentityColumn)
          .ValueGeneratedOnAdd()
          .HasColumnName("identity_column");
      entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
    });

    modelBuilder.Entity<ApVend>(entity =>
    {
      entity
          .HasNoKey()
          .ToView("apvend", "dbo");

      entity.Property(e => e.CreatedDate).HasColumnType("datetime");
      entity.Property(e => e.F1099).HasColumnName("f1099");
      entity.Property(e => e.Fbal)
          .HasColumnType("money")
          .HasColumnName("fbal");
      entity.Property(e => e.Fbuyer)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbuyer");
      entity.Property(e => e.Fcacctnum)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcacctnum");
      entity.Property(e => e.Fccurid)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fccurid");
      entity.Property(e => e.Fccusno)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fccusno");
      entity.Property(e => e.Fcdefshpto)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .HasColumnName("fcdefshpto");
      entity.Property(e => e.Fcemail)
          .IsRequired()
          .HasMaxLength(100)
          .IsUnicode(false)
          .HasColumnName("fcemail");
      entity.Property(e => e.Fcfname)
          .IsRequired()
          .HasMaxLength(15)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcfname");
      entity.Property(e => e.Fchangeby)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fchangeby");
      entity.Property(e => e.Fcity)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcity");
      entity.Property(e => e.Fcngdate)
          .HasColumnType("datetime")
          .HasColumnName("fcngdate");
      entity.Property(e => e.Fcompany)
          .IsRequired()
          .HasMaxLength(35)
          .IsUnicode(false)
          .HasColumnName("fcompany");
      entity.Property(e => e.Fcontact)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcontact");
      entity.Property(e => e.Fcountry)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcountry");
      entity.Property(e => e.Fcshipvia)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcshipvia");
      entity.Property(e => e.Fcstatus)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcstatus");
      entity.Property(e => e.Fcsubstatus)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcsubstatus");
      entity.Property(e => e.Fcterms)
          .IsRequired()
          .HasMaxLength(4)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcterms");
      entity.Property(e => e.Fcuser1)
          .IsRequired()
          .HasMaxLength(40)
          .IsUnicode(false)
          .HasColumnName("fcuser1");
      entity.Property(e => e.Fcuser2)
          .IsRequired()
          .HasMaxLength(40)
          .IsUnicode(false)
          .HasColumnName("fcuser2");
      entity.Property(e => e.Fcuser3)
          .IsRequired()
          .HasMaxLength(40)
          .IsUnicode(false)
          .HasColumnName("fcuser3");
      entity.Property(e => e.Fdisttype)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .HasColumnName("fdisttype");
      entity.Property(e => e.Fdramt)
          .HasColumnType("money")
          .HasColumnName("fdramt");
      entity.Property(e => e.Fdsince)
          .HasColumnType("datetime")
          .HasColumnName("fdsince");
      entity.Property(e => e.Fduser1)
          .HasColumnType("datetime")
          .HasColumnName("fduser1");
      entity.Property(e => e.Ffax)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("ffax");
      entity.Property(e => e.Fiso9000).HasColumnName("fiso9000");
      entity.Property(e => e.Fleftvend).HasColumnName("fleftvend");
      entity.Property(e => e.Flimit)
          .HasColumnType("money")
          .HasColumnName("flimit");
      entity.Property(e => e.Flistaxabl).HasColumnName("flistaxabl");
      entity.Property(e => e.Fllongdist).HasColumnName("fllongdist");
      entity.Property(e => e.Flpaydate)
          .HasColumnType("datetime")
          .HasColumnName("flpaydate");
      entity.Property(e => e.Flpayment)
          .HasColumnType("money")
          .HasColumnName("flpayment");
      entity.Property(e => e.Fmstreet)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fmstreet");
      entity.Property(e => e.Fmuser1)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fmuser1");
      entity.Property(e => e.Fnminamt)
          .HasColumnType("money")
          .HasColumnName("fnminamt");
      entity.Property(e => e.Fnremdelivery).HasColumnName("fnremdelivery");
      entity.Property(e => e.Fnuser1)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fnuser1");
      entity.Property(e => e.Fnuser2)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fnuser2");
      entity.Property(e => e.Fphone)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fphone");
      entity.Property(e => e.Fprepaid)
          .HasColumnType("money")
          .HasColumnName("fprepaid");
      entity.Property(e => e.Freasoncng)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("freasoncng");
      entity.Property(e => e.Fsalestax)
          .HasColumnType("numeric(7, 3)")
          .HasColumnName("fsalestax");
      entity.Property(e => e.Fstate)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fstate");
      entity.Property(e => e.Fstatus)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fstatus");
      entity.Property(e => e.Ftaxid)
          .IsRequired()
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("ftaxid");
      entity.Property(e => e.Furgency).HasColumnName("furgency");
      entity.Property(e => e.Fvendno)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fvendno");
      entity.Property(e => e.Fvremadvfax)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fvremadvfax");
      entity.Property(e => e.Fvremadvmail)
          .IsRequired()
          .HasMaxLength(100)
          .IsUnicode(false)
          .HasColumnName("fvremadvmail");
      entity.Property(e => e.Fvtype)
          .IsRequired()
          .HasMaxLength(2)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fvtype");
      entity.Property(e => e.Fytdpur)
          .HasColumnType("numeric(38, 9)")
          .HasColumnName("fytdpur");
      entity.Property(e => e.Fzip)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fzip");
      entity.Property(e => e.IdentityColumn)
          .ValueGeneratedOnAdd()
          .HasColumnName("identity_column");
      entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
    });

    modelBuilder.Entity<JoItem>(entity =>
    {
      entity
          .HasNoKey()
          .ToTable("joitem", "dbo", tb =>
          {
            tb.HasTrigger("Audit_Trigger_For_joitem_After_Delete");
            tb.HasTrigger("Audit_Trigger_For_joitem_After_Insert");
            tb.HasTrigger("Audit_Trigger_For_joitem_After_Update");
            tb.HasTrigger("ti_JOITEM");
            tb.HasTrigger("tu_JOITEM");
          });

      entity.HasIndex(e => new { e.Fjobno, e.Fitem, e.Fac, e.Fpartno, e.Fpartrev }, "JOITPART");

      entity.HasIndex(e => new { e.Fpartno, e.Fpartrev, e.Fjobno, e.Fac }, "PARTJOB");

      entity.HasIndex(e => new { e.Fsono, e.Finumber, e.Fkey }, "SONOKEY");

      entity.HasIndex(e => e.IdentityColumn, "identity_column_idx1")
          .IsUnique()
          .IsClustered();

      entity.Property(e => e.CreatedDate).HasColumnType("datetime");
      entity.Property(e => e.Fac)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fac");
      entity.Property(e => e.Fbook)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fbook");
      entity.Property(e => e.Fbqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fbqty");
      entity.Property(e => e.FcostEst)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fcost_est");
      entity.Property(e => e.Fcudrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcudrev");
      entity.Property(e => e.Fcustpart)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcustpart");
      entity.Property(e => e.Fcustptrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcustptrev");
      entity.Property(e => e.Fdelivery)
          .IsUnicode(false)
          .HasColumnName("fdelivery");
      entity.Property(e => e.Fdesc)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fdesc");
      entity.Property(e => e.Fdescmemo)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fdescmemo");
      entity.Property(e => e.Fduedate)
          .HasColumnType("datetime")
          .HasColumnName("fduedate");
      entity.Property(e => e.Fgroup)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fgroup");
      entity.Property(e => e.FhourEst)
          .HasColumnType("numeric(9, 2)")
          .HasColumnName("fhour_est");
      entity.Property(e => e.Fidoshpqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fidoshpqty");
      entity.Property(e => e.Finumber)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("finumber");
      entity.Property(e => e.Fitem)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fitem");
      entity.Property(e => e.Fjob).HasColumnName("fjob");
      entity.Property(e => e.Fjobno)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fjobno");
      entity.Property(e => e.Fkey)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fkey");
      entity.Property(e => e.Flshipdate)
          .HasColumnType("datetime")
          .HasColumnName("flshipdate");
      entity.Property(e => e.Fmeasure)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fmeasure");
      entity.Property(e => e.Fmqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fmqty");
      entity.Property(e => e.Fmultiple)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fmultiple");
      entity.Property(e => e.Fndbrmod).HasColumnName("fndbrmod");
      entity.Property(e => e.Forderqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("forderqty");
      entity.Property(e => e.Fpartno)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartno");
      entity.Property(e => e.Fpartrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartrev");
      entity.Property(e => e.Fpartyld1)
          .HasColumnType("numeric(8, 3)")
          .HasColumnName("fpartyld1");
      entity.Property(e => e.Fprodcl)
          .IsRequired()
          .HasMaxLength(4)
          .IsUnicode(false)
          .HasColumnName("fprodcl");
      entity.Property(e => e.Frtgqty)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("frtgqty");
      entity.Property(e => e.Fshipqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fshipqty");
      entity.Property(e => e.Fsono)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .HasColumnName("fsono");
      entity.Property(e => e.Fsource)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fsource");
      entity.Property(e => e.Fstandpart).HasColumnName("fstandpart");
      entity.Property(e => e.Fstatus)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fstatus");
      entity.Property(e => e.Fulabcost1)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fulabcost1");
      entity.Property(e => e.Fuprice)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fuprice");
      entity.Property(e => e.IdentityColumn)
          .ValueGeneratedOnAdd()
          .HasColumnName("identity_column");
      entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
    });

    modelBuilder.Entity<JodBom>(entity =>
    {
      entity
          .HasNoKey()
          .ToTable("jodbom", "dbo", tb =>
          {
            tb.HasTrigger("Audit_Trigger_For_jodbom_After_Delete");
            tb.HasTrigger("Audit_Trigger_For_jodbom_After_Insert");
            tb.HasTrigger("Audit_Trigger_For_jodbom_After_Update");
            tb.HasTrigger("td_JODBOM");
            tb.HasTrigger("ti_JODBOM");
            tb.HasTrigger("tu_JODBOM");
          });

      entity.HasIndex(e => new { e.Fjobno, e.Fnoperno, e.Cfac, e.Fbompart, e.Fbomrev }, "BYJOBPRT");

      entity.HasIndex(e => new { e.Fjobno, e.Fbominum }, "JOBINUM");

      entity.HasIndex(e => new { e.Fjobno, e.Cfac, e.Fbompart, e.Fbomrev }, "JOBNOPRT");

      entity.HasIndex(e => new { e.Fjobno, e.Fbomsource, e.Cfac, e.Fbompart, e.Fbomrev }, "JOBSRCPT");

      entity.HasIndex(e => new { e.Fjobno, e.SchedDate }, "JobSchdDate");

      entity.HasIndex(e => new { e.Fvendno, e.Cfac, e.Fbompart, e.Fbomrev, e.Fjobno }, "PTJOBNOA");

      entity.HasIndex(e => new { e.Fbompart, e.Fjobno, e.Fbomsource, e.Fresponse, e.Flextend, e.FqtyIss, e.Ftotqty, e.Cfac, e.Fbomrev }, "QtyComm");

      entity.HasIndex(e => e.SchedDate, "SD");

      entity.HasIndex(e => e.IdentityColumn, "identity_column_idx1")
          .IsUnique()
          .IsClustered();

      entity.HasIndex(e => new { e.Fjobno, e.Fitem }, "jobnoitm");

      entity.HasIndex(e => e.FneedDt, "needdate");

      entity.HasIndex(e => new { e.Fbompart, e.Fbomrev, e.Fjobno, e.Cfac }, "ptjobno");

      entity.HasIndex(e => new { e.Fqtytopurc, e.Cfac, e.Fbompart, e.Fbomrev, e.Fjobno, e.Fpoqty }, "ptjobnob");

      entity.HasIndex(e => e.Fbomsource, "source");

      entity.HasIndex(e => e.FsubJob, "subjob");

      entity.Property(e => e.Cfac)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength();
      entity.Property(e => e.CreatedDate).HasColumnType("datetime");
      entity.Property(e => e.FOrigQty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fOrigQty");
      entity.Property(e => e.Factqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("factqty");
      entity.Property(e => e.Fbomdesc)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fbomdesc");
      entity.Property(e => e.Fbominum)
          .IsRequired()
          .HasMaxLength(4)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbominum");
      entity.Property(e => e.Fbomlcost)
          .HasColumnType("numeric(14, 5)")
          .HasColumnName("fbomlcost");
      entity.Property(e => e.Fbommeas)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbommeas");
      entity.Property(e => e.Fbomocost)
          .HasColumnType("numeric(14, 5)")
          .HasColumnName("fbomocost");
      entity.Property(e => e.Fbompart)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbompart");
      entity.Property(e => e.Fbomrec).HasColumnName("fbomrec");
      entity.Property(e => e.Fbomrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbomrev");
      entity.Property(e => e.Fbomsource)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbomsource");
      entity.Property(e => e.Fbook)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fbook");
      entity.Property(e => e.FcSource)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .HasColumnName("fcSource");
      entity.Property(e => e.Fcbomudrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcbomudrev");
      entity.Property(e => e.Fclotext)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fclotext");
      entity.Property(e => e.Fcparudrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcparudrev");
      entity.Property(e => e.Ffixcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("ffixcost");
      entity.Property(e => e.Fiissdpcs).HasColumnName("fiissdpcs");
      entity.Property(e => e.Finumber)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("finumber");
      entity.Property(e => e.Fipopieces).HasColumnName("fipopieces");
      entity.Property(e => e.Fitem)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fitem");
      entity.Property(e => e.Fjobno)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fjobno");
      entity.Property(e => e.Flabcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("flabcost");
      entity.Property(e => e.Flabsetcos)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("flabsetcos");
      entity.Property(e => e.Flastoper).HasColumnName("flastoper");
      entity.Property(e => e.Flextend).HasColumnName("flextend");
      entity.Property(e => e.Fllotreqd).HasColumnName("fllotreqd");
      entity.Property(e => e.Fltooling).HasColumnName("fltooling");
      entity.Property(e => e.Fmatlcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fmatlcost");
      entity.Property(e => e.FnIsoqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fnISOQty");
      entity.Property(e => e.Fndbrmod).HasColumnName("fndbrmod");
      entity.Property(e => e.FneedDt)
          .HasColumnType("datetime")
          .HasColumnName("fneed_dt");
      entity.Property(e => e.Fnoperno).HasColumnName("fnoperno");
      entity.Property(e => e.Fnqtylnd)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fnqtylnd");
      entity.Property(e => e.Fnretpoqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fnretpoqty");
      entity.Property(e => e.Fnumopers).HasColumnName("fnumopers");
      entity.Property(e => e.Fothrcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fothrcost");
      entity.Property(e => e.Fovrhdcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fovrhdcost");
      entity.Property(e => e.Fovrhdsetc)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fovrhdsetc");
      entity.Property(e => e.Fparent)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fparent");
      entity.Property(e => e.Fparentrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fparentrev");
      entity.Property(e => e.FpneedDt)
          .HasColumnType("datetime")
          .HasColumnName("fpneed_dt");
      entity.Property(e => e.Fpono)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .HasColumnName("fpono");
      entity.Property(e => e.Fpoqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fpoqty");
      entity.Property(e => e.FqtyIss)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fqty_iss");
      entity.Property(e => e.Fqtytopurc)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fqtytopurc");
      entity.Property(e => e.Freqd)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("FREQD");
      entity.Property(e => e.Fresponse)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fresponse");
      entity.Property(e => e.Fstdmemo)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fstdmemo");
      entity.Property(e => e.FsubJob)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fsub_job");
      entity.Property(e => e.FsubRel).HasColumnName("fsub_rel");
      entity.Property(e => e.Fsubcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fsubcost");
      entity.Property(e => e.Ftotptime)
          .HasColumnType("numeric(9, 2)")
          .HasColumnName("ftotptime");
      entity.Property(e => e.Ftotqty)
          .HasColumnType("numeric(20, 10)")
          .HasColumnName("ftotqty");
      entity.Property(e => e.Ftotstime)
          .HasColumnType("numeric(9, 2)")
          .HasColumnName("ftotstime");
      entity.Property(e => e.Ftransinv)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("ftransinv");
      entity.Property(e => e.Fvendno)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fvendno");
      entity.Property(e => e.IdentityColumn)
          .ValueGeneratedOnAdd()
          .HasColumnName("identity_column");
      entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
      entity.Property(e => e.Pfac)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength();
      entity.Property(e => e.SchedDate).HasColumnType("datetime");
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
    });

    modelBuilder.Entity<JodRtg>(entity =>
    {
      entity
          .HasNoKey()
          .ToTable("jodrtg", "dbo", tb =>
          {
            tb.HasTrigger("Audit_Trigger_For_jodrtg_After_Delete");
            tb.HasTrigger("Audit_Trigger_For_jodrtg_After_Insert");
            tb.HasTrigger("Audit_Trigger_For_jodrtg_After_Update");
            tb.HasTrigger("td_JODRTG");
            tb.HasTrigger("ti_JODRTG");
            tb.HasTrigger("tu_JODRTG");
          });

      entity.HasIndex(e => new { e.Fjobno, e.Foperno }, "JOBNOOP");

      entity.HasIndex(e => new { e.Fjobno, e.Fac, e.FproId }, "JOBNOPRO");

      entity.HasIndex(e => new { e.Fjobno, e.Factschdst, e.Factschdfn }, "OperSchedDate");

      entity.HasIndex(e => new { e.Fjobno, e.Foperno, e.FnqtyMove }, "QtyInProc");

      entity.HasIndex(e => e.IdentityColumn, "identity_column_idx1")
          .IsUnique()
          .IsClustered();

      entity.HasIndex(e => e.FneedDt, "needdate");

      entity.HasIndex(e => e.Foperno, "operno");

      entity.Property(e => e.ArriveTime).HasColumnType("datetime");
      entity.Property(e => e.BufferEnd).HasColumnType("datetime");
      entity.Property(e => e.BufferStrt).HasColumnType("datetime");
      entity.Property(e => e.CreatedDate).HasColumnType("datetime");
      entity.Property(e => e.CycleUnits).HasColumnType("numeric(13, 3)");
      entity.Property(e => e.Fac)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fac");
      entity.Property(e => e.Factschdfn)
          .HasColumnType("datetime")
          .HasColumnName("factschdfn");
      entity.Property(e => e.Factschdst)
          .HasColumnType("datetime")
          .HasColumnName("factschdst");
      entity.Property(e => e.Fbominum)
          .IsRequired()
          .HasMaxLength(4)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbominum");
      entity.Property(e => e.Fccharcode)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fccharcode");
      entity.Property(e => e.Fcfreezetype)
          .IsRequired()
          .HasMaxLength(15)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcfreezetype");
      entity.Property(e => e.Fchngrates)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fchngrates");
      entity.Property(e => e.Fcmachineuse)
          .IsRequired()
          .HasMaxLength(100)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcmachineuse");
      entity.Property(e => e.FcompDate)
          .HasColumnType("datetime")
          .HasColumnName("fcomp_date");
      entity.Property(e => e.Fcschdpct)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcschdpct");
      entity.Property(e => e.Fcstat)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcstat");
      entity.Property(e => e.Fcsyncmisc)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcsyncmisc");
      entity.Property(e => e.FddueDate)
          .HasColumnType("datetime")
          .HasColumnName("fddue_date");
      entity.Property(e => e.Fdescnum)
          .IsRequired()
          .HasMaxLength(4)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fdescnum");
      entity.Property(e => e.Fdplanstdt)
          .HasColumnType("datetime")
          .HasColumnName("fdplanstdt");
      entity.Property(e => e.FdrelDate)
          .HasColumnType("datetime")
          .HasColumnName("fdrel_date");
      entity.Property(e => e.Felpstime)
          .HasColumnType("numeric(8, 2)")
          .HasColumnName("felpstime");
      entity.Property(e => e.Ffixcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("ffixcost");
      entity.Property(e => e.Fflushed)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fflushed");
      entity.Property(e => e.Finumber)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("finumber");
      entity.Property(e => e.Fjobno)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fjobno");
      entity.Property(e => e.FlBflabor).HasColumnName("flBFLabor");
      entity.Property(e => e.Flastlab)
          .HasColumnType("datetime")
          .HasColumnName("flastlab");
      entity.Property(e => e.FleadStim)
          .HasColumnType("numeric(8, 2)")
          .HasColumnName("flead_stim");
      entity.Property(e => e.FleadTim)
          .HasColumnType("numeric(8, 2)")
          .HasColumnName("flead_tim");
      entity.Property(e => e.Flfreeze).HasColumnName("flfreeze");
      entity.Property(e => e.Fllotreqd).HasColumnName("fllotreqd");
      entity.Property(e => e.Flsaveprec).HasColumnName("flsaveprec");
      entity.Property(e => e.Flschedule).HasColumnName("flschedule");
      entity.Property(e => e.Flusesetup).HasColumnName("flusesetup");
      entity.Property(e => e.Fmovetime)
          .HasColumnType("numeric(8, 2)")
          .HasColumnName("fmovetime");
      entity.Property(e => e.Fndbrmod).HasColumnName("fndbrmod");
      entity.Property(e => e.Fndelay).HasColumnName("fndelay");
      entity.Property(e => e.FndueTime).HasColumnName("fndue_time");
      entity.Property(e => e.FneedDt)
          .HasColumnType("datetime")
          .HasColumnName("fneed_dt");
      entity.Property(e => e.Fnlatestrt).HasColumnName("fnlatestrt");
      entity.Property(e => e.Fnlflushqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fnlflushqty");
      entity.Property(e => e.Fnmachine).HasColumnName("fnmachine");
      entity.Property(e => e.FnnextEvt).HasColumnName("fnnext_evt");
      entity.Property(e => e.FnpctComp).HasColumnName("fnpct_comp");
      entity.Property(e => e.FnqtyComp)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fnqty_comp");
      entity.Property(e => e.FnqtyMove)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fnqty_move");
      entity.Property(e => e.FnqtyTogo)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fnqty_togo");
      entity.Property(e => e.FnqueTime).HasColumnName("fnque_time");
      entity.Property(e => e.FnrelTime).HasColumnName("fnrel_time");
      entity.Property(e => e.Fnretpoqty)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fnretpoqty");
      entity.Property(e => e.FnshDate)
          .HasColumnType("datetime")
          .HasColumnName("fnsh_date");
      entity.Property(e => e.FnshTime).HasColumnName("fnsh_time");
      entity.Property(e => e.Fnshft).HasColumnName("fnshft");
      entity.Property(e => e.Fnsimulops).HasColumnName("fnsimulops");
      entity.Property(e => e.Fnstrttime).HasColumnName("fnstrttime");
      entity.Property(e => e.FoperStrt)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("foper_strt");
      entity.Property(e => e.Fopermemo)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fopermemo");
      entity.Property(e => e.Foperno).HasColumnName("foperno");
      entity.Property(e => e.Foperqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("foperqty");
      entity.Property(e => e.Fothrcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fothrcost");
      entity.Property(e => e.Fpono)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .HasColumnName("fpono");
      entity.Property(e => e.Fpoqty)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fpoqty");
      entity.Property(e => e.FproId)
          .IsRequired()
          .HasMaxLength(7)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpro_id");
      entity.Property(e => e.FprodTim)
          .HasColumnType("numeric(8, 2)")
          .HasColumnName("fprod_tim");
      entity.Property(e => e.FprodVal)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fprod_val");
      entity.Property(e => e.Fresponse)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fresponse");
      entity.Property(e => e.FsetupTim)
          .HasColumnType("numeric(8, 2)")
          .HasColumnName("fsetup_tim");
      entity.Property(e => e.FsetupVal)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fsetup_val");
      entity.Property(e => e.Fsetuptime)
          .HasColumnType("numeric(7, 2)")
          .HasColumnName("fsetuptime");
      entity.Property(e => e.Fshipmt)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fshipmt");
      entity.Property(e => e.Fsource)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fsource");
      entity.Property(e => e.Fsplit).HasColumnName("fsplit");
      entity.Property(e => e.Fstrtdate)
          .HasColumnType("datetime")
          .HasColumnName("fstrtdate");
      entity.Property(e => e.Fsubcont)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fsubcont");
      entity.Property(e => e.Ftduedate)
          .HasColumnType("datetime")
          .HasColumnName("ftduedate");
      entity.Property(e => e.Ftfnshdate)
          .IsRequired()
          .HasMaxLength(15)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("ftfnshdate");
      entity.Property(e => e.Ftfnshtime).HasColumnName("ftfnshtime");
      entity.Property(e => e.Ftimetogo)
          .HasColumnType("numeric(10, 2)")
          .HasColumnName("ftimetogo");
      entity.Property(e => e.FtotApp)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("ftot_app");
      entity.Property(e => e.FtotRew)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("ftot_rew");
      entity.Property(e => e.FtotScr)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("ftot_scr");
      entity.Property(e => e.Ftquetime).HasColumnName("ftquetime");
      entity.Property(e => e.Ftreldate)
          .HasColumnType("datetime")
          .HasColumnName("ftreldate");
      entity.Property(e => e.Ftstrtdate)
          .IsRequired()
          .HasMaxLength(15)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("ftstrtdate");
      entity.Property(e => e.Ftstrttime).HasColumnName("ftstrttime");
      entity.Property(e => e.Fulabcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fulabcost");
      entity.Property(e => e.Fuovrhdcos)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fuovrhdcos");
      entity.Property(e => e.Fuprodtime)
          .HasColumnType("numeric(16, 10)")
          .HasColumnName("fuprodtime");
      entity.Property(e => e.Fusubcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fusubcost");
      entity.Property(e => e.Fvendno)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fvendno");
      entity.Property(e => e.IdentityColumn)
          .ValueGeneratedOnAdd()
          .HasColumnName("identity_column");
      entity.Property(e => e.LateStrtDt).HasColumnType("datetime");
      entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
      entity.Property(e => e.UnitSize).HasColumnType("numeric(13, 3)");
    });

    modelBuilder.Entity<JoMast>(entity =>
    {
      entity
          .HasNoKey()
          .ToTable("jomast", "dbo", tb =>
          {
            tb.HasTrigger("Audit_Trigger_For_jomast_After_Delete");
            tb.HasTrigger("Audit_Trigger_For_jomast_After_Insert");
            tb.HasTrigger("Audit_Trigger_For_jomast_After_Update");
            tb.HasTrigger("td_JOMAST");
            tb.HasTrigger("ti_JOMAST");
            tb.HasTrigger("tu_JOMAST");
          });

      entity.HasIndex(e => e.Fcrmano, "FCRMANO");

      entity.HasIndex(e => new { e.Fpartno, e.Fpartrev, e.Fjobno, e.Fac }, "PARTJBNO");

      entity.HasIndex(e => new { e.Fstatus, e.Fjobno, e.Fquantity }, "QtyComm");

      entity.HasIndex(e => new { e.Fpartno, e.Fjobno, e.Fstatus, e.Fquantity, e.Fac, e.Fpartrev, e.Fitype, e.Ftype }, "QtyInproc");

      entity.HasIndex(e => e.Fschbefjob, "SCHBEFJOB");

      entity.HasIndex(e => new { e.Fsono, e.Fjobno }, "SOJOBNUM");

      entity.HasIndex(e => e.FddueDate, "duedate");

      entity.HasIndex(e => e.FddueDate, "duedateque");

      entity.HasIndex(e => e.IdentityColumn, "identity_column_idx1")
          .IsUnique()
          .IsClustered();

      entity.HasIndex(e => e.Idono, "idono");

      entity.HasIndex(e => e.Fjobno, "jomastjobno");

      entity.HasIndex(e => new { e.Fjobno, e.Fsono }, "sojobnum1");

      entity.HasIndex(e => new { e.Fjobno, e.Fsono }, "sojobnum2");

      entity.HasIndex(e => new { e.Fsono, e.Fkey }, "sokey");

      entity.HasIndex(e => e.Fstatus, "status");

      entity.Property(e => e.BufferEnd).HasColumnType("datetime");
      entity.Property(e => e.BufferStrt).HasColumnType("datetime");
      entity.Property(e => e.Createddate)
          .HasColumnType("datetime")
          .HasColumnName("createddate");
      entity.Property(e => e.DemandCat)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength();
      entity.Property(e => e.FSetYield)
          .HasColumnType("numeric(8, 2)")
          .HasColumnName("fSetYield");
      entity.Property(e => e.FYield)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fYield");
      entity.Property(e => e.Fac)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fac");
      entity.Property(e => e.FactRel)
          .HasColumnType("datetime")
          .HasColumnName("fact_rel");
      entity.Property(e => e.Factschdfn)
          .HasColumnType("datetime")
          .HasColumnName("factschdfn");
      entity.Property(e => e.Factschdst)
          .HasColumnType("datetime")
          .HasColumnName("factschdst");
      entity.Property(e => e.FassyComp).HasColumnName("fassy_comp");
      entity.Property(e => e.FassyReq).HasColumnName("fassy_req");
      entity.Property(e => e.Fbilljob)
          .IsRequired()
          .HasMaxLength(8)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbilljob");
      entity.Property(e => e.Fbominum)
          .IsRequired()
          .HasMaxLength(4)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fbominum");
      entity.Property(e => e.Fbomrec).HasColumnName("fbomrec");
      entity.Property(e => e.FcasBom).HasColumnName("fcas_bom");
      entity.Property(e => e.Fccadfile1)
          .IsRequired()
          .HasMaxLength(250)
          .IsUnicode(false)
          .HasColumnName("fccadfile1");
      entity.Property(e => e.Fccadfile2)
          .IsRequired()
          .HasMaxLength(250)
          .IsUnicode(false)
          .HasColumnName("fccadfile2");
      entity.Property(e => e.Fccadfile3)
          .IsRequired()
          .HasMaxLength(250)
          .IsUnicode(false)
          .HasColumnName("fccadfile3");
      entity.Property(e => e.Fcdncfile)
          .IsRequired()
          .HasMaxLength(80)
          .IsUnicode(false)
          .HasColumnName("fcdncfile");
      entity.Property(e => e.Fckeyfield)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fckeyfield");
      entity.Property(e => e.Fclotext)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fclotext");
      entity.Property(e => e.FcompSchl).HasColumnName("fcomp_schl");
      entity.Property(e => e.Fcompany)
          .IsRequired()
          .HasMaxLength(35)
          .IsUnicode(false)
          .HasColumnName("fcompany");
      entity.Property(e => e.Fconfirm).HasColumnName("fconfirm");
      entity.Property(e => e.Fcrmano)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcrmano");
      entity.Property(e => e.Fcsyncmisc)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcsyncmisc");
      entity.Property(e => e.Fcudrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcudrev");
      entity.Property(e => e.FcusId)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcus_id");
      entity.Property(e => e.Fcusrchr1)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcusrchr1");
      entity.Property(e => e.Fcusrchr2)
          .IsRequired()
          .HasMaxLength(40)
          .IsUnicode(false)
          .HasColumnName("fcusrchr2");
      entity.Property(e => e.Fcusrchr3)
          .IsRequired()
          .HasMaxLength(40)
          .IsUnicode(false)
          .HasColumnName("fcusrchr3");
      entity.Property(e => e.FddueDate)
          .HasColumnType("datetime")
          .HasColumnName("fddue_date");
      entity.Property(e => e.Fdduedtime).HasColumnName("fdduedtime");
      entity.Property(e => e.Fdesc).HasColumnName("fdesc");
      entity.Property(e => e.Fdescript)
          .IsRequired()
          .HasMaxLength(70)
          .IsUnicode(false)
          .HasColumnName("fdescript");
      entity.Property(e => e.FdetBom).HasColumnName("fdet_bom");
      entity.Property(e => e.FdetRtg).HasColumnName("fdet_rtg");
      entity.Property(e => e.Fdfnshdate)
          .HasColumnType("datetime")
          .HasColumnName("fdfnshdate");
      entity.Property(e => e.Fdmndrank).HasColumnName("fdmndrank");
      entity.Property(e => e.Fdorgduedt)
          .HasColumnType("datetime")
          .HasColumnName("fdorgduedt");
      entity.Property(e => e.Fdstart)
          .HasColumnType("datetime")
          .HasColumnName("fdstart");
      entity.Property(e => e.Fdusrdate1)
          .HasColumnType("datetime")
          .HasColumnName("fdusrdate1");
      entity.Property(e => e.FfstJob).HasColumnName("ffst_job");
      entity.Property(e => e.Fglacct)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fglacct");
      entity.Property(e => e.FholdBy)
          .IsRequired()
          .HasMaxLength(23)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fhold_by");
      entity.Property(e => e.FholdDt)
          .HasColumnType("datetime")
          .HasColumnName("fhold_dt");
      entity.Property(e => e.Fitems).HasColumnName("fitems");
      entity.Property(e => e.Fitype)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fitype");
      entity.Property(e => e.FjobMem)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fjob_mem");
      entity.Property(e => e.FjobName)
          .IsRequired()
          .HasMaxLength(86)
          .IsUnicode(false)
          .HasColumnName("fjob_name");
      entity.Property(e => e.Fjobno)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fjobno");
      entity.Property(e => e.Fkey)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fkey");
      entity.Property(e => e.Flastlab)
          .HasColumnType("datetime")
          .HasColumnName("flastlab");
      entity.Property(e => e.Flchgpnd).HasColumnName("flchgpnd");
      entity.Property(e => e.Flfreeze).HasColumnName("flfreeze");
      entity.Property(e => e.Flisapl).HasColumnName("flisapl");
      entity.Property(e => e.Fllasteco)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fllasteco");
      entity.Property(e => e.Fllotreqd).HasColumnName("fllotreqd");
      entity.Property(e => e.Flplanfreeze).HasColumnName("flplanfreeze");
      entity.Property(e => e.Flquick).HasColumnName("flquick");
      entity.Property(e => e.Flresync).HasColumnName("flresync");
      entity.Property(e => e.Fmatlpcnt).HasColumnName("fmatlpcnt");
      entity.Property(e => e.Fmeasure)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fmeasure");
      entity.Property(e => e.Fmethod)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fmethod");
      entity.Property(e => e.Fmultiple).HasColumnName("fmultiple");
      entity.Property(e => e.Fmusermemo)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fmusermemo");
      entity.Property(e => e.FnassyCom).HasColumnName("fnassy_com");
      entity.Property(e => e.FnassyReq).HasColumnName("fnassy_req");
      entity.Property(e => e.Fndbrmod).HasColumnName("fndbrmod");
      entity.Property(e => e.Fnfnshtime).HasColumnName("fnfnshtime");
      entity.Property(e => e.Fnlastopno).HasColumnName("fnlastopno");
      entity.Property(e => e.Fnontime).HasColumnName("fnontime");
      entity.Property(e => e.FnpctComp)
          .HasColumnType("numeric(6, 1)")
          .HasColumnName("fnpct_comp");
      entity.Property(e => e.FnpctIdle)
          .HasColumnType("numeric(6, 1)")
          .HasColumnName("fnpct_idle");
      entity.Property(e => e.FnrelTime).HasColumnName("fnrel_time");
      entity.Property(e => e.Fnrouteno).HasColumnName("fnrouteno");
      entity.Property(e => e.Fnshft).HasColumnName("fnshft");
      entity.Property(e => e.Fnusrcur1)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fnusrcur1");
      entity.Property(e => e.Fnusrqty1)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fnusrqty1");
      entity.Property(e => e.FopenDt)
          .HasColumnType("datetime")
          .HasColumnName("fopen_dt");
      entity.Property(e => e.Fpartdesc)
          .IsRequired()
          .HasMaxLength(40)
          .IsUnicode(false)
          .HasColumnName("fpartdesc");
      entity.Property(e => e.Fpartno)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartno");
      entity.Property(e => e.Fpartrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartrev");
      entity.Property(e => e.FpickDt)
          .HasColumnType("datetime")
          .HasColumnName("fpick_dt");
      entity.Property(e => e.FpickSt).HasColumnName("fpick_st");
      entity.Property(e => e.FpoComp)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpo_comp");
      entity.Property(e => e.Fpriority)
          .IsRequired()
          .HasMaxLength(11)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpriority");
      entity.Property(e => e.FproPlan).HasColumnName("fpro_plan");
      entity.Property(e => e.Fprocessby)
          .IsRequired()
          .HasMaxLength(12)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fprocessby");
      entity.Property(e => e.Fprodcl)
          .IsRequired()
          .HasMaxLength(4)
          .IsUnicode(false)
          .HasColumnName("fprodcl");
      entity.Property(e => e.Fquantity)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fquantity");
      entity.Property(e => e.FrDt)
          .HasColumnType("datetime")
          .HasColumnName("fr_dt");
      entity.Property(e => e.FrRev)
          .IsRequired()
          .HasMaxLength(2)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fr_rev");
      entity.Property(e => e.FrType)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fr_type");
      entity.Property(e => e.FrelDt)
          .HasColumnType("datetime")
          .HasColumnName("frel_dt");
      entity.Property(e => e.Fremtime).HasColumnName("fremtime");
      entity.Property(e => e.Fresponse)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fresponse");
      entity.Property(e => e.FresuBy)
          .IsRequired()
          .HasMaxLength(19)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fresu_by");
      entity.Property(e => e.FresuDt)
          .HasColumnType("datetime")
          .HasColumnName("fresu_dt");
      entity.Property(e => e.Frouting)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("frouting");
      entity.Property(e => e.Fschbefjob)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fschbefjob");
      entity.Property(e => e.Fschdflag)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fschdflag");
      entity.Property(e => e.Fschdprior)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fschdprior");
      entity.Property(e => e.Fschresdt)
          .HasColumnType("datetime")
          .HasColumnName("fschresdt");
      entity.Property(e => e.FsignOff).HasColumnName("fsign_off");
      entity.Property(e => e.Fsono)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .HasColumnName("fsono");
      entity.Property(e => e.Fsplit).HasColumnName("fsplit");
      entity.Property(e => e.Fsplitfrom)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fsplitfrom");
      entity.Property(e => e.Fsplitinfo)
          .IsRequired()
          .HasMaxLength(12)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fsplitinfo");
      entity.Property(e => e.Fstandpart).HasColumnName("fstandpart");
      entity.Property(e => e.Fstarted).HasColumnName("fstarted");
      entity.Property(e => e.Fstatus)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fstatus");
      entity.Property(e => e.FstrtDate)
          .HasColumnType("datetime")
          .HasColumnName("fstrt_date");
      entity.Property(e => e.FstrtTime).HasColumnName("fstrt_time");
      entity.Property(e => e.FsubFrom)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fsub_from");
      entity.Property(e => e.FsubRel).HasColumnName("fsub_rel");
      entity.Property(e => e.Fsummary).HasColumnName("fsummary");
      entity.Property(e => e.Ftduedate)
          .HasColumnType("datetime")
          .HasColumnName("ftduedate");
      entity.Property(e => e.Ftfnshdate)
          .IsRequired()
          .HasMaxLength(15)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("ftfnshdate");
      entity.Property(e => e.Ftfnshtime).HasColumnName("ftfnshtime");
      entity.Property(e => e.FtotAssy).HasColumnName("ftot_assy");
      entity.Property(e => e.FtraveDt)
          .HasColumnType("datetime")
          .HasColumnName("ftrave_dt");
      entity.Property(e => e.FtraveSt).HasColumnName("ftrave_st");
      entity.Property(e => e.Ftreldt)
          .HasColumnType("datetime")
          .HasColumnName("ftreldt");
      entity.Property(e => e.Ftschresdt)
          .HasColumnType("datetime")
          .HasColumnName("ftschresdt");
      entity.Property(e => e.Ftstrtdate)
          .IsRequired()
          .HasMaxLength(15)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("ftstrtdate");
      entity.Property(e => e.Ftstrttime).HasColumnName("ftstrttime");
      entity.Property(e => e.Ftype)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("ftype");
      entity.Property(e => e.IdentityColumn)
          .ValueGeneratedOnAdd()
          .HasColumnName("identity_column");
      entity.Property(e => e.Idono)
          .HasMaxLength(10)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("idono");
      entity.Property(e => e.ModDate).HasColumnType("datetime");
      entity.Property(e => e.Sfac)
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("sfac");
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
    });

    modelBuilder.Entity<SoMast>(entity =>
    {
      entity
          .HasNoKey()
          .ToTable("somast", "dbo", tb =>
          {
            tb.HasTrigger("Audit_Trigger_For_somast_After_Delete");
            tb.HasTrigger("Audit_Trigger_For_somast_After_Insert");
            tb.HasTrigger("Audit_Trigger_For_somast_After_Update");
            tb.HasTrigger("somast_integrationdelete");
            tb.HasTrigger("td_SOMAST");
            tb.HasTrigger("ti_SOMAST");
            tb.HasTrigger("tu_SOMAST");
          });

      entity.HasIndex(e => e.Fccontkey, "ContKey");

      entity.HasIndex(e => e.ContractNu, "ContrNum");

      entity.HasIndex(e => e.Fcfromno, "FCFROMNO");

      entity.HasIndex(e => new { e.Fcfromtype, e.QuoteNumber }, "FtQtno");

      entity.HasIndex(e => e.OpportunNum, "OpportunNum");

      entity.HasIndex(e => new { e.Fsono, e.Fstatus }, "QtyComm");

      entity.HasIndex(e => new { e.Fcustno, e.Fsono, e.Fstatus, e.Fackdate }, "QtySLCDPM");

      entity.HasIndex(e => e.Fcompany, "company");

      entity.HasIndex(e => e.Fcustpono, "cponumber");

      entity.HasIndex(e => e.Fcustno, "custno");

      entity.HasIndex(e => e.Fcompany, "fcompany");

      entity.HasIndex(e => e.Ffob, "ffob");

      entity.HasIndex(e => e.IdentityColumn, "identity_column_idx1")
          .IsUnique()
          .IsClustered();

      entity.HasIndex(e => e.Fsono, "sono");

      entity.HasIndex(e => e.Fstatus, "status");

      entity.Property(e => e.Contactnum)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .HasColumnName("contactnum");
      entity.Property(e => e.ContractNu)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false);
      entity.Property(e => e.CreatedDate).HasColumnType("datetime");
      entity.Property(e => e.Fackdate)
          .HasColumnType("datetime")
          .HasColumnName("fackdate");
      entity.Property(e => e.Fackmemo)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fackmemo");
      entity.Property(e => e.Fbilladdr)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .HasColumnName("fbilladdr");
      entity.Property(e => e.FcancDt)
          .HasColumnType("datetime")
          .HasColumnName("fcanc_dt");
      entity.Property(e => e.Fccommcode)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fccommcode");
      entity.Property(e => e.Fccontkey)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fccontkey");
      entity.Property(e => e.Fccurid)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fccurid");
      entity.Property(e => e.Fcfactor)
          .HasColumnType("numeric(22, 10)")
          .HasColumnName("fcfactor");
      entity.Property(e => e.Fcfname)
          .IsRequired()
          .HasMaxLength(15)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcfname");
      entity.Property(e => e.Fcfromno)
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcfromno");
      entity.Property(e => e.Fcfromtype)
          .IsRequired()
          .HasMaxLength(5)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcfromtype");
      entity.Property(e => e.Fcity)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcity");
      entity.Property(e => e.FclosDt)
          .HasColumnType("datetime")
          .HasColumnName("fclos_dt");
      entity.Property(e => e.Fcompany)
          .IsRequired()
          .HasMaxLength(35)
          .IsUnicode(false)
          .HasColumnName("fcompany");
      entity.Property(e => e.Fcontact)
          .IsRequired()
          .HasMaxLength(30)
          .IsUnicode(false)
          .HasColumnName("fcontact");
      entity.Property(e => e.Fcountry)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcountry");
      entity.Property(e => e.FcrmorderId)
          .IsRequired()
          .HasMaxLength(36)
          .IsUnicode(false)
          .HasColumnName("fcrmorderId");
      entity.Property(e => e.Fcrmsyncdt)
          .HasColumnType("datetime")
          .HasColumnName("fcrmsyncdt");
      entity.Property(e => e.Fcusrchr1)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcusrchr1");
      entity.Property(e => e.Fcusrchr2)
          .IsRequired()
          .HasMaxLength(40)
          .IsUnicode(false)
          .HasColumnName("fcusrchr2");
      entity.Property(e => e.Fcusrchr3)
          .IsRequired()
          .HasMaxLength(40)
          .IsUnicode(false)
          .HasColumnName("fcusrchr3");
      entity.Property(e => e.Fcustno)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcustno");
      entity.Property(e => e.Fcustpono)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcustpono");
      entity.Property(e => e.Fdcurdate)
          .HasColumnType("datetime")
          .HasColumnName("fdcurdate");
      entity.Property(e => e.Fdeurodate)
          .HasColumnType("datetime")
          .HasColumnName("fdeurodate");
      entity.Property(e => e.Fdisrate)
          .HasColumnType("numeric(8, 3)")
          .HasColumnName("fdisrate");
      entity.Property(e => e.Fdistno)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fdistno");
      entity.Property(e => e.Fduedate)
          .HasColumnType("datetime")
          .HasColumnName("fduedate");
      entity.Property(e => e.Fduplicate).HasColumnName("fduplicate");
      entity.Property(e => e.Fdusrdate1)
          .HasColumnType("datetime")
          .HasColumnName("fdusrdate1");
      entity.Property(e => e.FecorderId)
          .IsRequired()
          .HasMaxLength(36)
          .IsUnicode(false)
          .HasColumnName("fecorderId");
      entity.Property(e => e.Fecshipamount)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fecshipamount");
      entity.Property(e => e.Fecshipmethod)
          .IsRequired()
          .HasMaxLength(100)
          .IsUnicode(false)
          .HasColumnName("fecshipmethod");
      entity.Property(e => e.Fecsync).HasColumnName("fecsync");
      entity.Property(e => e.Fectaxamount)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fectaxamount");
      entity.Property(e => e.Festimator)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("festimator");
      entity.Property(e => e.Feurofctr)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("feurofctr");
      entity.Property(e => e.Ffax)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("ffax");
      entity.Property(e => e.Ffob)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("ffob");
      entity.Property(e => e.Flchgpnd).HasColumnName("flchgpnd");
      entity.Property(e => e.Flcontract).HasColumnName("flcontract");
      entity.Property(e => e.Fllasteco)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fllasteco");
      entity.Property(e => e.Flpaybycc).HasColumnName("flpaybycc");
      entity.Property(e => e.Flprofprtd).HasColumnName("flprofprtd");
      entity.Property(e => e.Flprofrqd).HasColumnName("flprofrqd");
      entity.Property(e => e.Fmstreet)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fmstreet");
      entity.Property(e => e.Fmusrmemo1)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fmusrmemo1");
      entity.Property(e => e.Fncancchrge)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fncancchrge");
      entity.Property(e => e.Fndbrmod).HasColumnName("fndbrmod");
      entity.Property(e => e.Fndpstrcvd)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fndpstrcvd");
      entity.Property(e => e.Fndpstrqd)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fndpstrqd");
      entity.Property(e => e.Fnextenum)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fnextenum");
      entity.Property(e => e.Fnextinum)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fnextinum");
      entity.Property(e => e.Fnusrcur1)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fnusrcur1");
      entity.Property(e => e.Fnusrqty1)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fnusrqty1");
      entity.Property(e => e.Forderdate)
          .HasColumnType("datetime")
          .HasColumnName("forderdate");
      entity.Property(e => e.Fordername)
          .IsRequired()
          .HasMaxLength(65)
          .IsUnicode(false)
          .HasColumnName("fordername");
      entity.Property(e => e.Fordrevdt)
          .HasColumnType("datetime")
          .HasColumnName("fordrevdt");
      entity.Property(e => e.Fpaytype)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpaytype");
      entity.Property(e => e.Fphone)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fphone");
      entity.Property(e => e.FprintDt)
          .HasColumnType("datetime")
          .HasColumnName("fprint_dt");
      entity.Property(e => e.Fprinted).HasColumnName("fprinted");
      entity.Property(e => e.Fpriority).HasColumnName("fpriority");
      entity.Property(e => e.Fsalcompct)
          .HasColumnType("numeric(8, 3)")
          .HasColumnName("fsalcompct");
      entity.Property(e => e.Fsalecom).HasColumnName("fsalecom");
      entity.Property(e => e.Fsalescode)
          .IsRequired()
          .HasMaxLength(7)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fsalescode");
      entity.Property(e => e.Fshipvia)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fshipvia");
      entity.Property(e => e.Fshptoaddr)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .HasColumnName("fshptoaddr");
      entity.Property(e => e.Fsocoord)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fsocoord");
      entity.Property(e => e.Fsoldaddr)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .HasColumnName("fsoldaddr");
      entity.Property(e => e.Fsoldby)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fsoldby");
      entity.Property(e => e.Fsono)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .HasColumnName("fsono");
      entity.Property(e => e.Fsorev)
          .IsRequired()
          .HasMaxLength(2)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fsorev");
      entity.Property(e => e.Fstate)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fstate");
      entity.Property(e => e.Fstatus)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fstatus");
      entity.Property(e => e.Ftaxcode)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("ftaxcode");
      entity.Property(e => e.Ftaxrate)
          .HasColumnType("numeric(7, 3)")
          .HasColumnName("ftaxrate");
      entity.Property(e => e.Fterm)
          .IsRequired()
          .HasMaxLength(4)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fterm");
      entity.Property(e => e.Fterr)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fterr");
      entity.Property(e => e.Fusercode)
          .IsRequired()
          .HasMaxLength(7)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fusercode");
      entity.Property(e => e.Fzip)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fzip");
      entity.Property(e => e.IdentityColumn)
          .ValueGeneratedOnAdd()
          .HasColumnName("identity_column");
      entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
      entity.Property(e => e.OppCrType)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength();
      entity.Property(e => e.OpportunNum)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false);
      entity.Property(e => e.QuoteNumber)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false);
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
    });

    modelBuilder.Entity<SoItem>(entity =>
    {
      entity
          .HasNoKey()
          .ToTable("soitem", "dbo", tb =>
          {
            tb.HasTrigger("Audit_Trigger_For_soitem_After_Delete");
            tb.HasTrigger("Audit_Trigger_For_soitem_After_Insert");
            tb.HasTrigger("Audit_Trigger_For_soitem_After_Update");
            tb.HasTrigger("soitem_integrationdelete");
            tb.HasTrigger("td_SOITEM");
            tb.HasTrigger("ti_SOITEM");
            tb.HasTrigger("tu_SOITEM");
          });

      entity.HasIndex(e => e.ContractNu, "ContrNum");

      entity.HasIndex(e => e.Fcfromtype, "Ft");

      entity.HasIndex(e => new { e.Fsono, e.Fac, e.Fpartno, e.Fpartrev }, "PartNo");

      entity.HasIndex(e => new { e.Fpartno, e.Finumber, e.Fpartrev, e.Fsono, e.Fsource, e.Fac }, "QtyComm");

      entity.HasIndex(e => new { e.Fshipitem, e.Fsource }, "ShiSrc");

      entity.HasIndex(e => new { e.Fsono, e.Fenumber }, "enumber");

      entity.HasIndex(e => e.IdentityColumn, "identity_column_idx1")
          .IsUnique()
          .IsClustered();

      entity.HasIndex(e => new { e.Fsono, e.Finumber }, "inumber");

      entity.HasIndex(e => e.Fsource, "source");

      entity.Property(e => e.ContractNu)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false);
      entity.Property(e => e.Fac)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fac");
      entity.Property(e => e.Fautocreat).HasColumnName("fautocreat");
      entity.Property(e => e.FcAltUm)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("FcAltUM");
      entity.Property(e => e.FcItemStatus)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcItemStatus");
      entity.Property(e => e.FcasBom).HasColumnName("fcas_bom");
      entity.Property(e => e.FcasRtg).HasColumnName("fcas_rtg");
      entity.Property(e => e.Fcfromitem)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcfromitem");
      entity.Property(e => e.Fcfromno)
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcfromno");
      entity.Property(e => e.Fcfromtype)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcfromtype");
      entity.Property(e => e.Fclotext)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fclotext");
      entity.Property(e => e.Fcommpct)
          .HasColumnType("numeric(8, 2)")
          .HasColumnName("fcommpct");
      entity.Property(e => e.Fcostfrom)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false);
      entity.Property(e => e.Fcprodid)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcprodid");
      entity.Property(e => e.Fcrmid)
          .IsRequired()
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("fcrmid");
      entity.Property(e => e.Fcrmsyncdt)
          .HasColumnType("datetime")
          .HasColumnName("fcrmsyncdt");
      entity.Property(e => e.Fcudrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcudrev");
      entity.Property(e => e.Fcustpart)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcustpart");
      entity.Property(e => e.Fcustptrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcustptrev");
      entity.Property(e => e.Fdcreateddate)
          .HasColumnType("datetime")
          .HasColumnName("fdcreateddate");
      entity.Property(e => e.Fdesc)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fdesc");
      entity.Property(e => e.Fdescmemo)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fdescmemo");
      entity.Property(e => e.FdetBom).HasColumnName("fdet_bom");
      entity.Property(e => e.FdetRtg).HasColumnName("fdet_rtg");
      entity.Property(e => e.Fdmodifieddate)
          .HasColumnType("datetime")
          .HasColumnName("fdmodifieddate");
      entity.Property(e => e.Fdrequestdate)
          .HasColumnType("datetime")
          .HasColumnName("fdrequestdate");
      entity.Property(e => e.Fduedate)
          .HasColumnType("datetime")
          .HasColumnName("fduedate");
      entity.Property(e => e.Fenumber)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fenumber");
      entity.Property(e => e.FfinalSchd).HasColumnName("FFinalSchd");
      entity.Property(e => e.Ffixact)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("ffixact");
      entity.Property(e => e.Fgroup)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fgroup");
      entity.Property(e => e.Finumber)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("finumber");
      entity.Property(e => e.Flabact)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("flabact");
      entity.Property(e => e.Fllotreqd).HasColumnName("fllotreqd");
      entity.Property(e => e.Fmatlact)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fmatlact");
      entity.Property(e => e.Fmeasure)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fmeasure");
      entity.Property(e => e.Fmultiple).HasColumnName("fmultiple");
      entity.Property(e => e.FnAltQty).HasColumnType("numeric(17, 5)");
      entity.Property(e => e.Fndbrmod).HasColumnName("fndbrmod");
      entity.Property(e => e.Fnextinum).HasColumnName("fnextinum");
      entity.Property(e => e.Fnextrel)
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fnextrel");
      entity.Property(e => e.Fnlatefact)
          .HasColumnType("numeric(4, 2)")
          .HasColumnName("fnlatefact");
      entity.Property(e => e.Fnover)
          .HasColumnType("numeric(12, 5)")
          .HasColumnName("fnover");
      entity.Property(e => e.Fnsobuf).HasColumnName("fnsobuf");
      entity.Property(e => e.Fnunder)
          .HasColumnType("numeric(12, 5)")
          .HasColumnName("fnunder");
      entity.Property(e => e.Fordertype)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fordertype");
      entity.Property(e => e.ForigReqDt)
          .HasColumnType("datetime")
          .HasColumnName("FOrigReqDt");
      entity.Property(e => e.Fothract)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fothract");
      entity.Property(e => e.Fovhdact)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fovhdact");
      entity.Property(e => e.Fpartno)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartno");
      entity.Property(e => e.Fpartrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartrev");
      entity.Property(e => e.Fprice).HasColumnName("fprice");
      entity.Property(e => e.Fprintmemo).HasColumnName("fprintmemo");
      entity.Property(e => e.Fprodcl)
          .IsRequired()
          .HasMaxLength(4)
          .IsUnicode(false)
          .HasColumnName("fprodcl");
      entity.Property(e => e.Fquantity)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fquantity");
      entity.Property(e => e.Fquoteqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fquoteqty");
      entity.Property(e => e.Frtgsetupa)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("frtgsetupa");
      entity.Property(e => e.Fschecode)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fschecode");
      entity.Property(e => e.Fschedtype)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fschedtype");
      entity.Property(e => e.Fshipitem).HasColumnName("fshipitem");
      entity.Property(e => e.Fsoldby)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fsoldby");
      entity.Property(e => e.Fsono)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .HasColumnName("fsono");
      entity.Property(e => e.Fsource)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fsource");
      entity.Property(e => e.Fstandpart).HasColumnName("fstandpart");
      entity.Property(e => e.Fsubact)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fsubact");
      entity.Property(e => e.Fsummary).HasColumnName("fsummary");
      entity.Property(e => e.Ftaxcode)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("ftaxcode");
      entity.Property(e => e.Ftaxrate)
          .HasColumnType("numeric(7, 3)")
          .HasColumnName("ftaxrate");
      entity.Property(e => e.Ftnumoper).HasColumnName("ftnumoper");
      entity.Property(e => e.Ftoolact)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("ftoolact");
      entity.Property(e => e.Ftotnonpr).HasColumnName("ftotnonpr");
      entity.Property(e => e.Ftotptime)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("ftotptime");
      entity.Property(e => e.Ftotstime)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("ftotstime");
      entity.Property(e => e.Fulabcost1)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fulabcost1");
      entity.Property(e => e.Fviewprice).HasColumnName("fviewprice");
      entity.Property(e => e.IdentityColumn)
          .ValueGeneratedOnAdd()
          .HasColumnName("identity_column");
      entity.Property(e => e.Itccost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("ITCCOST");
      entity.Property(e => e.Sfac)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("sfac");
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
    });

    modelBuilder.Entity<Sorel>(entity =>
    {
      entity
          .HasNoKey()
          .ToTable("sorels", "dbo", tb =>
          {
            tb.HasTrigger("Audit_Trigger_For_sorels_After_Delete");
            tb.HasTrigger("Audit_Trigger_For_sorels_After_Insert");
            tb.HasTrigger("Audit_Trigger_For_sorels_After_Update");
            tb.HasTrigger("SORels_CalcInvcPoss");
            tb.HasTrigger("td_SORELS");
            tb.HasTrigger("ti_SORELS");
            tb.HasTrigger("tu_SORELS");
          });

      entity.HasIndex(e => new { e.Fsono, e.Finumber, e.Frelease, e.FlInvcPoss, e.Fmasterrel, e.Fcpbtype }, "ForInvc");

      entity.HasIndex(e => e.FlInvcPoss, "Invposs");

      entity.HasIndex(e => new { e.Fsono, e.Finumber, e.Fmasterrel, e.Forderqty, e.Fshipbook, e.Fshipbuy, e.Fshipmake, e.Fstkqty }, "QtyComm");

      entity.HasIndex(e => new { e.Fsono, e.Fbook, e.Fbqty, e.Fmasterrel, e.Fmqty, e.Forderqty, e.Funetprice }, "QtySLCDPM");

      entity.HasIndex(e => new { e.Fpartno, e.Fpartrev, e.Fsono }, "buyparts");

      entity.HasIndex(e => new { e.Forderqty, e.Fshipbook, e.Fshipmake, e.Fshipbuy }, "dmdamt");

      entity.HasIndex(e => e.Fduedate, "duedate");

      entity.HasIndex(e => e.IdentityColumn, "identity_column_idx1")
          .IsUnique()
          .IsClustered();

      entity.HasIndex(e => new { e.Ftoshpbook, e.Ftoshpmake, e.Fninvship, e.Forderqty, e.Fshipbook, e.Fshipmake, e.Ftoshpbuy, e.Fshipbuy, e.Finvqty }, "invopen");

      entity.HasIndex(e => e.FcRelsStatus, "ix_sorels_RelStatus");

      entity.HasIndex(e => new { e.Fsono, e.Finumber, e.Frelease }, "makeitems");

      entity.HasIndex(e => new { e.Fshipbook, e.Fshipmake, e.Fshipbuy, e.Finvqty }, "shipamt");

      entity.HasIndex(e => new { e.Fsono, e.Fshptoaddr, e.Finumber }, "shipto");

      entity.Property(e => e.Earlydays).HasColumnName("EARLYDAYS");
      entity.Property(e => e.Favailship).HasColumnName("favailship");
      entity.Property(e => e.Fbook)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fbook");
      entity.Property(e => e.Fbqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fbqty");
      entity.Property(e => e.FcRelsStatus)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcRelsStatus");
      entity.Property(e => e.Fcbin)
          .IsRequired()
          .HasMaxLength(14)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcbin");
      entity.Property(e => e.Fcloc)
          .IsRequired()
          .HasMaxLength(14)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcloc");
      entity.Property(e => e.Fcpbtype)
          .IsRequired()
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasComment("Progress Billing Type")
          .HasColumnName("fcpbtype");
      entity.Property(e => e.Fcudrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcudrev");
      entity.Property(e => e.Fdcreateddate)
          .HasColumnType("datetime")
          .HasColumnName("fdcreateddate");
      entity.Property(e => e.Fdelivery)
          .IsRequired()
          .IsUnicode(false)
          .HasColumnName("fdelivery");
      entity.Property(e => e.Fdiscount)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fdiscount");
      entity.Property(e => e.Fdiscpct)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fdiscpct");
      entity.Property(e => e.Fdmodifieddate)
          .HasColumnType("datetime")
          .HasColumnName("fdmodifieddate");
      entity.Property(e => e.Fdrequestdate)
          .HasColumnType("datetime")
          .HasColumnName("fdrequestdate");
      entity.Property(e => e.Fduedate)
          .HasColumnType("datetime")
          .HasColumnName("fduedate");
      entity.Property(e => e.Fenumber)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fenumber");
      entity.Property(e => e.FfinalSchd).HasColumnName("FFinalSchd");
      entity.Property(e => e.Finumber)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("finumber");
      entity.Property(e => e.Finvamount)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("finvamount");
      entity.Property(e => e.Finvqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("finvqty");
      entity.Property(e => e.Fjob).HasColumnName("fjob");
      entity.Property(e => e.Fjoqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fjoqty");
      entity.Property(e => e.FlInvcPoss).HasColumnName("flInvcPoss");
      entity.Property(e => e.Flabcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("flabcost");
      entity.Property(e => e.Flabpadj)
          .HasColumnType("numeric(16, 5)")
          .HasColumnName("flabpadj");
      entity.Property(e => e.Flatp).HasColumnName("flatp");
      entity.Property(e => e.Flistaxabl).HasColumnName("flistaxabl");
      entity.Property(e => e.Fljrdif).HasColumnName("fljrdif");
      entity.Property(e => e.Flngth)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("flngth");
      entity.Property(e => e.Flshipdate)
          .HasColumnType("datetime")
          .HasColumnName("flshipdate");
      entity.Property(e => e.Fmasterrel).HasColumnName("fmasterrel");
      entity.Property(e => e.Fmatlcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fmatlcost");
      entity.Property(e => e.Fmatlpadj)
          .HasColumnType("numeric(16, 5)")
          .HasColumnName("fmatlpadj");
      entity.Property(e => e.Fmaxqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fmaxqty");
      entity.Property(e => e.Fmqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fmqty");
      entity.Property(e => e.Fmsi)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fmsi");
      entity.Property(e => e.FnIsoqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fnISOQty");
      entity.Property(e => e.Fndbrmod).HasColumnName("fndbrmod");
      entity.Property(e => e.Fneteuropr)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fneteuropr");
      entity.Property(e => e.Fnetprice)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fnetprice");
      entity.Property(e => e.Fnettxnprice)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fnettxnprice");
      entity.Property(e => e.Fninvship)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fninvship");
      entity.Property(e => e.Fnpurvar)
          .HasColumnType("money")
          .HasColumnName("fnpurvar");
      entity.Property(e => e.Fnretpoqty)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fnretpoqty");
      entity.Property(e => e.Forderqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("forderqty");
      entity.Property(e => e.ForigReqDt)
          .HasColumnType("datetime")
          .HasColumnName("FOrigReqDt");
      entity.Property(e => e.Fothrcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fothrcost");
      entity.Property(e => e.Fothrpadj)
          .HasColumnType("numeric(16, 5)")
          .HasColumnName("fothrpadj");
      entity.Property(e => e.Fovhdcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fovhdcost");
      entity.Property(e => e.Fovhdpadj)
          .HasColumnType("numeric(16, 5)")
          .HasColumnName("fovhdpadj");
      entity.Property(e => e.Fpartno)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartno");
      entity.Property(e => e.Fpartrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fpartrev");
      entity.Property(e => e.Fpoqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fpoqty");
      entity.Property(e => e.Fpostatus)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .HasColumnName("fpostatus");
      entity.Property(e => e.Fpriority).HasColumnName("fpriority");
      entity.Property(e => e.Fquant)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fquant");
      entity.Property(e => e.Frelease)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("frelease");
      entity.Property(e => e.Fsetupcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fsetupcost");
      entity.Property(e => e.Fsetuppadj)
          .HasColumnType("numeric(16, 5)")
          .HasColumnName("fsetuppadj");
      entity.Property(e => e.Fshipbook)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fshipbook");
      entity.Property(e => e.Fshipbuy)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fshipbuy");
      entity.Property(e => e.Fshipmake)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fshipmake");
      entity.Property(e => e.Fshpbefdue).HasColumnName("fshpbefdue");
      entity.Property(e => e.Fshptoaddr)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .HasColumnName("fshptoaddr");
      entity.Property(e => e.Fsono)
          .IsRequired()
          .HasMaxLength(10)
          .IsUnicode(false)
          .HasColumnName("fsono");
      entity.Property(e => e.Fsplitshp).HasColumnName("fsplitshp");
      entity.Property(e => e.Fstatus)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .HasColumnName("fstatus");
      entity.Property(e => e.Fstkqty)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fstkqty");
      entity.Property(e => e.Fsubcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("fsubcost");
      entity.Property(e => e.Fsubpadj)
          .HasColumnType("numeric(16, 5)")
          .HasColumnName("fsubpadj");
      entity.Property(e => e.Ftoolcost)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("ftoolcost");
      entity.Property(e => e.Ftoolpadj)
          .HasColumnType("numeric(16, 5)")
          .HasColumnName("ftoolpadj");
      entity.Property(e => e.Ftoshpbook)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("ftoshpbook");
      entity.Property(e => e.Ftoshpbuy)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("ftoshpbuy");
      entity.Property(e => e.Ftoshpmake)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("ftoshpmake");
      entity.Property(e => e.Funeteuropr)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("funeteuropr");
      entity.Property(e => e.Funetprice)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("funetprice");
      entity.Property(e => e.Funettxnpric)
          .HasColumnType("numeric(17, 5)")
          .HasColumnName("funettxnpric");
      entity.Property(e => e.Fvendno)
          .IsRequired()
          .HasMaxLength(6)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fvendno");
      entity.Property(e => e.Fwidth)
          .HasColumnType("numeric(15, 5)")
          .HasColumnName("fwidth");
      entity.Property(e => e.IdentityColumn)
          .ValueGeneratedOnAdd()
          .HasColumnName("identity_column");
      entity.Property(e => e.SchedDate).HasColumnType("datetime");
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
    });

    modelBuilder.Entity<Invcur>(entity =>
    {
      entity
          .HasNoKey()
          .ToTable("invcur", "dbo");

      entity.HasIndex(e => new { e.Fcpartno, e.Fcpartrev, e.Fac }, "PARTREV");

      entity.HasIndex(e => e.IdentityColumn, "identity_column_idx1")
          .IsUnique()
          .IsClustered();

      entity.Property(e => e.CreatedDate).HasColumnType("datetime");
      entity.Property(e => e.Fac)
          .IsRequired()
          .HasMaxLength(20)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fac");
      entity.Property(e => e.Fcpartno)
          .IsRequired()
          .HasMaxLength(25)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcpartno");
      entity.Property(e => e.Fcpartrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcpartrev");
      entity.Property(e => e.Fcudrev)
          .IsRequired()
          .HasMaxLength(3)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("fcudrev");
      entity.Property(e => e.Flanycur).HasColumnName("flanycur");
      entity.Property(e => e.IdentityColumn)
          .ValueGeneratedOnAdd()
          .HasColumnName("identity_column");
      entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
      entity.Property(e => e.TimestampColumn)
          .IsRowVersion()
          .IsConcurrencyToken()
          .HasColumnName("timestamp_column");
    });


    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
