using System;
using System.Collections.Generic;

namespace SEV.Domain.Models;

public partial class JoItem
{
    public string Fjobno { get; set; }

    public string Fitem { get; set; }

    public string Fpartno { get; set; }

    public string Fpartrev { get; set; }

    public string Fsono { get; set; }

    public string Finumber { get; set; }

    public bool Fjob { get; set; }

    public string Fkey { get; set; }

    public decimal Fbook { get; set; }

    public decimal Fbqty { get; set; }

    public decimal FcostEst { get; set; }

    public string Fcustpart { get; set; }

    public string Fcustptrev { get; set; }

    public DateTime Fduedate { get; set; }

    public string Fgroup { get; set; }

    public decimal FhourEst { get; set; }

    public DateTime Flshipdate { get; set; }

    public string Fmeasure { get; set; }

    public decimal Fmqty { get; set; }

    public string Fmultiple { get; set; }

    public decimal Forderqty { get; set; }

    public decimal Fpartyld1 { get; set; }

    public string Fprodcl { get; set; }

    public decimal Frtgqty { get; set; }

    public decimal Fshipqty { get; set; }

    public string Fsource { get; set; }

    public bool Fstandpart { get; set; }

    public string Fstatus { get; set; }

    public decimal Fulabcost1 { get; set; }

    public decimal Fuprice { get; set; }

    public byte[] TimestampColumn { get; set; }

    public int IdentityColumn { get; set; }

    public string Fdesc { get; set; }

    public string Fdescmemo { get; set; }

    public string Fac { get; set; }

    public decimal? Fidoshpqty { get; set; }

    public string Fcudrev { get; set; }

    public int Fndbrmod { get; set; }

    public string Fdelivery { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
