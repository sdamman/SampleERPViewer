using System;
using System.Collections.Generic;

namespace SEV.Domain.Models;

public partial class InOnhd
{
    public string Fpartno { get; set; }

    public string Fpartrev { get; set; }

    public string Fbinno { get; set; }

    public string Flocation { get; set; }

    public DateTime Fexpdate { get; set; }

    public string Flot { get; set; }

    public decimal Fonhand { get; set; }

    public int IdentityColumn { get; set; }

    public byte[] TimestampColumn { get; set; }

    public string Fac { get; set; }

    public string Fcudrev { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
