namespace SEV.Domain.Models;

public partial class Sorel
{
    public string Fenumber { get; set; }

    public string Finumber { get; set; }

    public string Fpartno { get; set; }

    public string Fpartrev { get; set; }

    public string Frelease { get; set; }

    public string Fshptoaddr { get; set; }

    public string Fsono { get; set; }

    public bool Favailship { get; set; }

    public decimal Fbook { get; set; }

    public decimal Fbqty { get; set; }

    public decimal Fdiscount { get; set; }

    public DateTime Fduedate { get; set; }

    public decimal Finvamount { get; set; }

    public decimal Finvqty { get; set; }

    public bool Fjob { get; set; }

    public decimal Fjoqty { get; set; }

    public decimal Flabcost { get; set; }

    public decimal Flngth { get; set; }

    public DateTime Flshipdate { get; set; }

    public bool Fmasterrel { get; set; }

    public decimal Fmatlcost { get; set; }

    public decimal Fmaxqty { get; set; }

    public decimal Fmqty { get; set; }

    public decimal Fmsi { get; set; }

    public decimal Fnetprice { get; set; }

    public decimal Fninvship { get; set; }

    public decimal Fnpurvar { get; set; }

    public decimal Forderqty { get; set; }

    public decimal Fothrcost { get; set; }

    public decimal Fovhdcost { get; set; }

    public decimal Fpoqty { get; set; }

    public string Fpostatus { get; set; }

    public decimal Fquant { get; set; }

    public decimal Fsetupcost { get; set; }

    public decimal Fshipbook { get; set; }

    public decimal Fshipbuy { get; set; }

    public decimal Fshipmake { get; set; }

    public bool Fshpbefdue { get; set; }

    public bool Fsplitshp { get; set; }

    public string Fstatus { get; set; }

    public decimal Fstkqty { get; set; }

    public decimal Fsubcost { get; set; }

    public decimal Ftoolcost { get; set; }

    public decimal Ftoshpbook { get; set; }

    public decimal Ftoshpbuy { get; set; }

    public decimal Ftoshpmake { get; set; }

    public decimal Funetprice { get; set; }

    public string Fvendno { get; set; }

    public decimal Fwidth { get; set; }

    public decimal Fnretpoqty { get; set; }

    public decimal Fnettxnprice { get; set; }

    public decimal Funettxnpric { get; set; }

    public decimal Fneteuropr { get; set; }

    public decimal Funeteuropr { get; set; }

    public decimal Fdiscpct { get; set; }

    public bool Fljrdif { get; set; }

    public bool Flistaxabl { get; set; }

    public bool Flatp { get; set; }

    public byte[] TimestampColumn { get; set; }

    public int IdentityColumn { get; set; }

    public string Fdelivery { get; set; }

    /// <summary>
    /// Progress Billing Type
    /// </summary>
    public string Fcpbtype { get; set; }

    public string Fcbin { get; set; }

    public string Fcloc { get; set; }

    public string Fcudrev { get; set; }

    public int Fndbrmod { get; set; }

    public DateTime SchedDate { get; set; }

    public int Fpriority { get; set; }

    public bool FlInvcPoss { get; set; }

    public decimal? Fmatlpadj { get; set; }

    public decimal? Ftoolpadj { get; set; }

    public decimal? Flabpadj { get; set; }

    public decimal? Fovhdpadj { get; set; }

    public decimal? Fsubpadj { get; set; }

    public decimal? Fothrpadj { get; set; }

    public decimal? Fsetuppadj { get; set; }

    public decimal FnIsoqty { get; set; }

    public int Earlydays { get; set; }

    public string FcRelsStatus { get; set; }

    public DateTime Fdrequestdate { get; set; }

    public DateTime Fdcreateddate { get; set; }

    public DateTime Fdmodifieddate { get; set; }

    public DateTime ForigReqDt { get; set; }

    public bool FfinalSchd { get; set; }
}
