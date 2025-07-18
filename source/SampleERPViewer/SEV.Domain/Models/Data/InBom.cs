using System;
using System.Collections.Generic;

namespace SEV.Domain.Models;

public partial class InBom
{
    public string Fcomponent { get; set; }

    public string Fcomprev { get; set; }

    public string Fitem { get; set; }

    public string Fparent { get; set; }

    public string Fparentrev { get; set; }

    public DateTime FendEfDt { get; set; }

    public string Fmemoexist { get; set; }

    public decimal Fqty { get; set; }

    public string Freqd { get; set; }

    public DateTime FstEfDt { get; set; }

    public bool Flextend { get; set; }

    public bool Fltooling { get; set; }

    public int Fnoperno { get; set; }

    public byte[] TimestampColumn { get; set; }

    public int IdentityColumn { get; set; }

    public string Fbommemo { get; set; }

    public string Cfacilityid { get; set; }

    public string Pfacilityid { get; set; }

    public string Fcompudrev { get; set; }

    public string Fcparudrev { get; set; }

    public int Fndbrmod { get; set; }

    public bool FlFssvc { get; set; }

    public decimal FOrigQty { get; set; }

    public string FcSource { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
