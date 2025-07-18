namespace SEV.Domain.Models;

public partial class Invcur
{
    public string Fcpartno { get; set; }

    public string Fcpartrev { get; set; }

    public bool Flanycur { get; set; }

    public int IdentityColumn { get; set; }

    public byte[] TimestampColumn { get; set; }

    public string Fac { get; set; }

    public string Fcudrev { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
