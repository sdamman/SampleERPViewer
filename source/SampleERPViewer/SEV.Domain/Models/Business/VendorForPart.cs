namespace SEV.Domain.Models
{
  public class VendorForPart
  {
    public string VendorNumber { get; set; }
    public string VendorName { get; set; }
    public string PartNumber { get; set; }
    public string Description { get; set; }
    public string Comments { get; set; }

    public string Fpartno { get; set; }
    public string Fpartrev { get; set; }
    public string Fpriority { get; set; }
    public string Fvendno { get; set; }
    public decimal Fvconvfact { get; set; }
    public decimal Fvlastpc { get; set; }
    public DateTime Fvlastpd { get; set; }
    public decimal Fvlastpq { get; set; }
    public decimal Fvleadtime { get; set; }
    public string Fvmeasure { get; set; }
    public string Fvpartno { get; set; }
    public string Fvptdes { get; set; }
    public string Fclastpono { get; set; }
    public string Fcjrdict { get; set; }
    public byte[] TimestampColumn { get; set; }
    public int IdentityColumn { get; set; }
    public string Fvcomment { get; set; }
    public string Fac { get; set; }
    public string Fcudrev { get; set; }
    public string Fvlastapno { get; set; }
    public decimal Fvlasttxnpc { get; set; }
    public decimal Fvfactor { get; set; }
    public string Fccurid { get; set; }
    public bool Fmulticurr { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public VendorForPart() { }
  }
}
