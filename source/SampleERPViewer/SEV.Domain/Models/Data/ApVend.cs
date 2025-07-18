using System;
using System.Collections.Generic;

namespace SEV.Domain.Models;

public partial class ApVend
{
    public string Fvendno { get; set; }

    public string Fcompany { get; set; }

    public string Fbuyer { get; set; }

    public string Fcacctnum { get; set; }

    public string Fccusno { get; set; }

    public string Fcdefshpto { get; set; }

    public string Fcity { get; set; }

    public string Fcountry { get; set; }

    public string Fcfname { get; set; }

    public string Fcontact { get; set; }

    public string Fcshipvia { get; set; }

    public string Fcterms { get; set; }

    public string Fccurid { get; set; }

    public string Fcuser1 { get; set; }

    public string Fcuser2 { get; set; }

    public string Fcuser3 { get; set; }

    public DateTime Fduser1 { get; set; }

    public DateTime Fdsince { get; set; }

    public string Ffax { get; set; }

    public bool Fiso9000 { get; set; }

    public decimal Flimit { get; set; }

    public bool Fllongdist { get; set; }

    public decimal Fnminamt { get; set; }

    public decimal Fnuser1 { get; set; }

    public decimal Fnuser2 { get; set; }

    public string Fphone { get; set; }

    public decimal Fprepaid { get; set; }

    public decimal Fsalestax { get; set; }

    public string Fstate { get; set; }

    public string Fstatus { get; set; }

    public int Furgency { get; set; }

    public decimal Fdramt { get; set; }

    public string Fvtype { get; set; }

    public string Fzip { get; set; }

    public bool F1099 { get; set; }

    public string Fcstatus { get; set; }

    public bool Flistaxabl { get; set; }

    public string Fcemail { get; set; }

    public byte[] TimestampColumn { get; set; }

    public int IdentityColumn { get; set; }

    public string Fmstreet { get; set; }

    public string Fmuser1 { get; set; }

    public string Fdisttype { get; set; }

    public string Fchangeby { get; set; }

    public DateTime Fcngdate { get; set; }

    public string Fcsubstatus { get; set; }

    public string Freasoncng { get; set; }

    public int Fnremdelivery { get; set; }

    public string Fvremadvmail { get; set; }

    public string Fvremadvfax { get; set; }

    public bool Fleftvend { get; set; }

    public string Ftaxid { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public decimal? Flpayment { get; set; }

    public DateTime? Flpaydate { get; set; }

    public decimal? Fytdpur { get; set; }

    public decimal? Fbal { get; set; }
}
