using System;
using System.Collections.Generic;

namespace SEV.Domain.Models;

public partial class JodBom
{
    public string Fitem { get; set; }

    public string Fbompart { get; set; }

    public string Fbomrev { get; set; }

    public string Fbomdesc { get; set; }

    public string Fparent { get; set; }

    public string Fparentrev { get; set; }

    public decimal Factqty { get; set; }

    public decimal Fbomlcost { get; set; }

    public string Fbommeas { get; set; }

    public decimal Fbomocost { get; set; }

    public int Fbomrec { get; set; }

    public string Fbomsource { get; set; }

    public decimal Fbook { get; set; }

    public decimal Ffixcost { get; set; }

    public string Finumber { get; set; }

    public string Fjobno { get; set; }

    public decimal Flabcost { get; set; }

    public decimal Flabsetcos { get; set; }

    public int Flastoper { get; set; }

    public bool Flextend { get; set; }

    public bool Fltooling { get; set; }

    public decimal Fmatlcost { get; set; }

    public DateTime FneedDt { get; set; }

    public int Fnumopers { get; set; }

    public string Fbominum { get; set; }

    public decimal Fothrcost { get; set; }

    public decimal Fovrhdcost { get; set; }

    public decimal Fovrhdsetc { get; set; }

    public string Fpono { get; set; }

    public decimal Fpoqty { get; set; }

    public decimal Fqtytopurc { get; set; }

    public decimal FqtyIss { get; set; }

    public string Fresponse { get; set; }

    public decimal Fsubcost { get; set; }

    public string FsubJob { get; set; }

    public bool FsubRel { get; set; }

    public decimal Ftotptime { get; set; }

    public decimal Ftotqty { get; set; }

    public decimal Ftotstime { get; set; }

    public decimal Ftransinv { get; set; }

    public string Fvendno { get; set; }

    public bool Fllotreqd { get; set; }

    public string Fclotext { get; set; }

    public decimal Fnretpoqty { get; set; }

    public int Fnoperno { get; set; }

    public byte[] TimestampColumn { get; set; }

    public int IdentityColumn { get; set; }

    public string Fstdmemo { get; set; }

    public DateTime FpneedDt { get; set; }

    public string Cfac { get; set; }

    public string Fcbomudrev { get; set; }

    public string Fcparudrev { get; set; }

    public int Fiissdpcs { get; set; }

    public int Fipopieces { get; set; }

    public int Fndbrmod { get; set; }

    public decimal Fnqtylnd { get; set; }

    public string Pfac { get; set; }

    public DateTime SchedDate { get; set; }

    public decimal FOrigQty { get; set; }

    public decimal FnIsoqty { get; set; }

    public string FcSource { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string Freqd { get; set; }
}
