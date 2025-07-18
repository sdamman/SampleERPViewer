using System;
using System.Collections.Generic;

namespace SEV.Domain.Models;

public partial class SoMast
{
    public string Fsono { get; set; }

    public string Fcustno { get; set; }

    public string Fcompany { get; set; }

    public string Fcity { get; set; }

    public string Fcustpono { get; set; }

    public DateTime Fackdate { get; set; }

    public DateTime FcancDt { get; set; }

    public string Fccurid { get; set; }

    public decimal Fcfactor { get; set; }

    public string Fcfname { get; set; }

    public string Fcfromno { get; set; }

    public string Fcfromtype { get; set; }

    public string Fcontact { get; set; }

    public DateTime FclosDt { get; set; }

    public string Fcountry { get; set; }

    public string Fcusrchr1 { get; set; }

    public string Fcusrchr2 { get; set; }

    public string Fcusrchr3 { get; set; }

    public DateTime Fdcurdate { get; set; }

    public decimal Fdisrate { get; set; }

    public string Fdistno { get; set; }

    public DateTime Fduedate { get; set; }

    public bool Fduplicate { get; set; }

    public DateTime Fdusrdate1 { get; set; }

    public string Festimator { get; set; }

    public string Ffax { get; set; }

    public string Ffob { get; set; }

    public string Fnextenum { get; set; }

    public string Fnextinum { get; set; }

    public decimal Fnusrqty1 { get; set; }

    public decimal Fnusrcur1 { get; set; }

    public DateTime Forderdate { get; set; }

    public string Fordername { get; set; }

    public DateTime Fordrevdt { get; set; }

    public string Fpaytype { get; set; }

    public string Fphone { get; set; }

    public DateTime FprintDt { get; set; }

    public bool Fprinted { get; set; }

    public decimal Fsalcompct { get; set; }

    public bool Fsalecom { get; set; }

    public string Fshipvia { get; set; }

    public string Fshptoaddr { get; set; }

    public string Fsocoord { get; set; }

    public string Fsoldaddr { get; set; }

    public string Fsoldby { get; set; }

    public string Fsorev { get; set; }

    public string Fstate { get; set; }

    public string Fstatus { get; set; }

    public string Ftaxcode { get; set; }

    public decimal Ftaxrate { get; set; }

    public string Fterm { get; set; }

    public string Fterr { get; set; }

    public string Fzip { get; set; }

    public bool Flprofprtd { get; set; }

    public bool Flprofrqd { get; set; }

    public decimal Fndpstrcvd { get; set; }

    public decimal Fndpstrqd { get; set; }

    public DateTime Fdeurodate { get; set; }

    public decimal Feurofctr { get; set; }

    public string Fsalescode { get; set; }

    public string Fusercode { get; set; }

    public decimal Fncancchrge { get; set; }

    public bool Flchgpnd { get; set; }

    public string Fllasteco { get; set; }

    public byte[] TimestampColumn { get; set; }

    public int IdentityColumn { get; set; }

    public string Fackmemo { get; set; }

    public string Fmstreet { get; set; }

    public string Fmusrmemo1 { get; set; }

    public string Fccontkey { get; set; }

    public bool Flcontract { get; set; }

    public int Fndbrmod { get; set; }

    public string Fccommcode { get; set; }

    public int Fpriority { get; set; }

    public string ContractNu { get; set; }

    public string Fbilladdr { get; set; }

    public string OpportunNum { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public string OppCrType { get; set; }

    public string QuoteNumber { get; set; }

    public string Contactnum { get; set; }

    public bool Flpaybycc { get; set; }

    public bool Fecsync { get; set; }

    public string FecorderId { get; set; }

    public decimal Fectaxamount { get; set; }

    public decimal Fecshipamount { get; set; }

    public string Fecshipmethod { get; set; }

    public string FcrmorderId { get; set; }

    public DateTime Fcrmsyncdt { get; set; }
}
