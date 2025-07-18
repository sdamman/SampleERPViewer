using System;
using System.Collections.Generic;

namespace SEV.Domain.Models;

public partial class JoMast
{
    public string Fjobno { get; set; }

    public string Fpartno { get; set; }

    public string Fpartrev { get; set; }

    public string Fsono { get; set; }

    public string Fstatus { get; set; }

    public DateTime Factschdfn { get; set; }

    public DateTime Factschdst { get; set; }

    public DateTime FactRel { get; set; }

    public int FassyComp { get; set; }

    public int FassyReq { get; set; }

    public string Fbilljob { get; set; }

    public string Fbominum { get; set; }

    public int Fbomrec { get; set; }

    public bool FcasBom { get; set; }

    public string Fckeyfield { get; set; }

    public string Fcompany { get; set; }

    public bool FcompSchl { get; set; }

    public bool Fconfirm { get; set; }

    public string FcusId { get; set; }

    public int Fdduedtime { get; set; }

    public DateTime FddueDate { get; set; }

    public bool Fdesc { get; set; }

    public string Fdescript { get; set; }

    public bool FdetBom { get; set; }

    public bool FdetRtg { get; set; }

    public DateTime Fdstart { get; set; }

    public DateTime Fdfnshdate { get; set; }

    public bool FfstJob { get; set; }

    public string Fglacct { get; set; }

    public string FholdBy { get; set; }

    public DateTime FholdDt { get; set; }

    public int Fitems { get; set; }

    public string Fitype { get; set; }

    public string FjobName { get; set; }

    public string Fkey { get; set; }

    public DateTime Flastlab { get; set; }

    public int Fmatlpcnt { get; set; }

    public string Fmeasure { get; set; }

    public string Fmethod { get; set; }

    public bool Fmultiple { get; set; }

    public int FnassyCom { get; set; }

    public int FnassyReq { get; set; }

    public int Fnfnshtime { get; set; }

    public int Fnontime { get; set; }

    public decimal FnpctComp { get; set; }

    public decimal FnpctIdle { get; set; }

    public int FnrelTime { get; set; }

    public int Fnshft { get; set; }

    public DateTime FopenDt { get; set; }

    public string Fpartdesc { get; set; }

    public DateTime FpickDt { get; set; }

    public bool FpickSt { get; set; }

    public string FpoComp { get; set; }

    public DateTime FtraveDt { get; set; }

    public bool FtraveSt { get; set; }

    public string Fpriority { get; set; }

    public string Fprocessby { get; set; }

    public string Fprodcl { get; set; }

    public bool FproPlan { get; set; }

    public decimal Fquantity { get; set; }

    public DateTime FrelDt { get; set; }

    public int Fremtime { get; set; }

    public string Fresponse { get; set; }

    public string FresuBy { get; set; }

    public DateTime FresuDt { get; set; }

    public decimal Frouting { get; set; }

    public DateTime FrDt { get; set; }

    public string FrRev { get; set; }

    public string FrType { get; set; }

    public string Fschbefjob { get; set; }

    public string Fschdflag { get; set; }

    public string Fschdprior { get; set; }

    public DateTime Fschresdt { get; set; }

    public bool FsignOff { get; set; }

    public bool Fsplit { get; set; }

    public string Fsplitfrom { get; set; }

    public string Fsplitinfo { get; set; }

    public bool Fstandpart { get; set; }

    public bool Fstarted { get; set; }

    public DateTime FstrtDate { get; set; }

    public int FstrtTime { get; set; }

    public string FsubFrom { get; set; }

    public bool FsubRel { get; set; }

    public bool Fsummary { get; set; }

    public DateTime Ftduedate { get; set; }

    public string Ftfnshdate { get; set; }

    public int Ftfnshtime { get; set; }

    public int FtotAssy { get; set; }

    public DateTime Ftreldt { get; set; }

    public DateTime Ftschresdt { get; set; }

    public string Ftstrtdate { get; set; }

    public int Ftstrttime { get; set; }

    public string Ftype { get; set; }

    public string Fcusrchr1 { get; set; }

    public string Fcusrchr2 { get; set; }

    public string Fcusrchr3 { get; set; }

    public decimal Fnusrqty1 { get; set; }

    public decimal Fnusrcur1 { get; set; }

    public DateTime Fdusrdate1 { get; set; }

    public int Fnlastopno { get; set; }

    public string Fcdncfile { get; set; }

    public string Fccadfile1 { get; set; }

    public string Fccadfile2 { get; set; }

    public string Fccadfile3 { get; set; }

    public bool Fllotreqd { get; set; }

    public string Fclotext { get; set; }

    public bool Flresync { get; set; }

    public DateTime Fdorgduedt { get; set; }

    public bool Flquick { get; set; }

    public bool Flfreeze { get; set; }

    public bool Flchgpnd { get; set; }

    public string Fllasteco { get; set; }

    public bool Flisapl { get; set; }

    public byte[] TimestampColumn { get; set; }

    public int IdentityColumn { get; set; }

    public string FjobMem { get; set; }

    public string Fmusermemo { get; set; }

    public string Fac { get; set; }

    public string Idono { get; set; }

    public string Sfac { get; set; }

    public string Fcudrev { get; set; }

    public int Fdmndrank { get; set; }

    public int Fndbrmod { get; set; }

    public int Fnrouteno { get; set; }

    public bool Flplanfreeze { get; set; }

    public string Fcsyncmisc { get; set; }

    public bool UseBuffer { get; set; }

    public DateTime BufferStrt { get; set; }

    public DateTime BufferEnd { get; set; }

    public string DemandCat { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime ModDate { get; set; }

    public decimal FYield { get; set; }

    public decimal FSetYield { get; set; }

    public string Fcrmano { get; set; }

    public bool Firmed { get; set; }
}
