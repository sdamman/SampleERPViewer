namespace SEV.Domain.Models;

public partial class SoItem
{
    public string Finumber { get; set; }

    public string Fpartno { get; set; }

    public string Fpartrev { get; set; }

    public string Fsono { get; set; }

    public string Fclotext { get; set; }

    public bool Fllotreqd { get; set; }

    public bool Fautocreat { get; set; }

    public bool FcasBom { get; set; }

    public bool FcasRtg { get; set; }

    public decimal Fcommpct { get; set; }

    public string Fcustpart { get; set; }

    public string Fcustptrev { get; set; }

    public bool FdetBom { get; set; }

    public bool FdetRtg { get; set; }

    public DateTime Fduedate { get; set; }

    public string Fenumber { get; set; }

    public decimal Ffixact { get; set; }

    public string Fgroup { get; set; }

    public decimal Flabact { get; set; }

    public decimal Fmatlact { get; set; }

    public string Fmeasure { get; set; }

    public bool Fmultiple { get; set; }

    public int Fnextinum { get; set; }

    public string Fnextrel { get; set; }

    public decimal Fnunder { get; set; }

    public decimal Fnover { get; set; }

    public string Fordertype { get; set; }

    public decimal Fothract { get; set; }

    public decimal Fovhdact { get; set; }

    public bool Fprice { get; set; }

    public bool Fprintmemo { get; set; }

    public string Fprodcl { get; set; }

    public decimal Fquantity { get; set; }

    public string Fcfromtype { get; set; }

    public string Fcfromno { get; set; }

    public string Fcfromitem { get; set; }

    public decimal Fquoteqty { get; set; }

    public decimal Frtgsetupa { get; set; }

    public string Fschecode { get; set; }

    public bool Fshipitem { get; set; }

    public string Fsoldby { get; set; }

    public string Fsource { get; set; }

    public bool Fstandpart { get; set; }

    public decimal Fsubact { get; set; }

    public bool Fsummary { get; set; }

    public string Ftaxcode { get; set; }

    public decimal Ftaxrate { get; set; }

    public decimal Ftoolact { get; set; }

    public int Ftnumoper { get; set; }

    public int Ftotnonpr { get; set; }

    public decimal Ftotptime { get; set; }

    public decimal Ftotstime { get; set; }

    public decimal Fulabcost1 { get; set; }

    public bool Fviewprice { get; set; }

    public string Fcprodid { get; set; }

    public string Fschedtype { get; set; }

    public byte[] TimestampColumn { get; set; }

    public int IdentityColumn { get; set; }

    public string Fdesc { get; set; }

    public string Fdescmemo { get; set; }

    public string Fac { get; set; }

    public string Sfac { get; set; }

    public decimal Itccost { get; set; }

    public string FcAltUm { get; set; }

    public decimal FnAltQty { get; set; }

    public string Fcudrev { get; set; }

    public int Fndbrmod { get; set; }

    public decimal Fnlatefact { get; set; }

    public int Fnsobuf { get; set; }

    public bool ManualPlan { get; set; }

    public string ContractNu { get; set; }

    public bool Flrfqreqd { get; set; }

    public string Fcostfrom { get; set; }

    public string FcItemStatus { get; set; }

    public DateTime Fdrequestdate { get; set; }

    public DateTime Fdcreateddate { get; set; }

    public DateTime Fdmodifieddate { get; set; }

    public DateTime ForigReqDt { get; set; }

    public bool FfinalSchd { get; set; }

    public DateTime Fcrmsyncdt { get; set; }

    public string Fcrmid { get; set; }
}
