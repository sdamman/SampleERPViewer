using System;
using System.Collections.Generic;

namespace SEV.Domain.Models;

public partial class InMast
{
    public string Fpartno { get; set; }

    public string Frev { get; set; }

    public string Fcstscode { get; set; }

    public string Fdescript { get; set; }

    public bool Flchgpnd { get; set; }

    public string Fmeasure { get; set; }

    public string Fsource { get; set; }

    public decimal Fleadtime { get; set; }

    public decimal Fprice { get; set; }

    public decimal Fstdcost { get; set; }

    public decimal F2totcost { get; set; }

    public decimal Flastcost { get; set; }

    public string Flocate1 { get; set; }

    public string Fbin1 { get; set; }

    public string F2costcode { get; set; }

    public decimal F2displcst { get; set; }

    public decimal F2dispmcst { get; set; }

    public decimal F2dispocst { get; set; }

    public decimal F2disptcst { get; set; }

    public decimal F2labcost { get; set; }

    public decimal F2matlcost { get; set; }

    public decimal F2ovhdcost { get; set; }

    public decimal Favgcost { get; set; }

    public string Fbulkissue { get; set; }

    public string Fbuyer { get; set; }

    public string FcalcLead { get; set; }

    public string Fcbackflsh { get; set; }

    public int Fcnts { get; set; }

    public string Fcopymemo { get; set; }

    public string Fcostcode { get; set; }

    public string Fcpurchase { get; set; }

    public decimal Fcstperinv { get; set; }

    public decimal Fdisplcost { get; set; }

    public decimal Fdispmcost { get; set; }

    public decimal Fdispocost { get; set; }

    public decimal Fdispprice { get; set; }

    public decimal Fdisptcost { get; set; }

    public string Fdrawno { get; set; }

    public string Fdrawsize { get; set; }

    public decimal Fendqty1 { get; set; }

    public decimal Fendqty10 { get; set; }

    public decimal Fendqty11 { get; set; }

    public decimal Fendqty12 { get; set; }

    public decimal Fendqty2 { get; set; }

    public decimal Fendqty3 { get; set; }

    public decimal Fendqty4 { get; set; }

    public decimal Fendqty5 { get; set; }

    public decimal Fendqty6 { get; set; }

    public decimal Fendqty7 { get; set; }

    public decimal Fendqty8 { get; set; }

    public decimal Fendqty9 { get; set; }

    public string Fgroup { get; set; }

    public string Finspect { get; set; }

    public decimal Flabcost { get; set; }

    public string Flasteoc { get; set; }

    public DateTime Flct { get; set; }

    public bool Fllotreqd { get; set; }

    public decimal Fmatlcost { get; set; }

    public string Fmeasure2 { get; set; }

    public decimal Fnweight { get; set; }

    public decimal Fovhdcost { get; set; }

    public string Fprodcl { get; set; }

    public decimal Freordqty { get; set; }

    public DateTime Frevdt { get; set; }

    public string Frolledup { get; set; }

    public decimal Fsafety { get; set; }

    public string Fschecode { get; set; }

    public decimal Fuprodtime { get; set; }

    public decimal Fyield { get; set; }

    public string Fabccode { get; set; }

    public bool Ftaxable { get; set; }

    public string Fcusrchr1 { get; set; }

    public string Fcusrchr2 { get; set; }

    public string Fcusrchr3 { get; set; }

    public decimal Fnusrqty1 { get; set; }

    public decimal Fnusrcur1 { get; set; }

    public DateTime Fdusrdate1 { get; set; }

    public string Fcdncfile { get; set; }

    public string Fccadfile1 { get; set; }

    public string Fccadfile2 { get; set; }

    public string Fccadfile3 { get; set; }

    public string Fclotext { get; set; }

    public bool Flexpreqd { get; set; }

    public DateTime Fdlastpc { get; set; }

    public string Fschedtype { get; set; }

    public bool Fldctracke { get; set; }

    public DateTime Fddcrefdat { get; set; }

    public decimal Fndctax { get; set; }

    public decimal Fndcduty { get; set; }

    public decimal Fndcfreigh { get; set; }

    public decimal Fndcmisc { get; set; }

    public string Fcratedisc { get; set; }

    public bool Flconstrnt { get; set; }

    public bool Flistaxabl { get; set; }

    public string Fcjrdict { get; set; }

    public bool Flaplpart { get; set; }

    public bool Flfanpart { get; set; }

    public int Fnfanaglvl { get; set; }

    public string Fcplnclass { get; set; }

    public string Fcclass { get; set; }

    public byte[] TimestampColumn { get; set; }

    public int IdentityColumn { get; set; }

    public string Fcomment { get; set; }

    public string Fmusrmemo1 { get; set; }

    public string Fstdmemo { get; set; }

    public string Fac { get; set; }

    public string Sfac { get; set; }

    public decimal? Itcfixed { get; set; }

    public decimal? Itcunit { get; set; }

    public decimal FnPonHand { get; set; }

    public decimal FnLndToMfg { get; set; }

    public int FiPcsOnHd { get; set; }

    public string Fcudrev { get; set; }

    public int Fidims { get; set; }

    public bool Fluseudrev { get; set; }

    public int Fndbrmod { get; set; }

    public bool FlFsrtn { get; set; }

    public decimal Fnlatefact { get; set; }

    public int Fnsobuf { get; set; }

    public int Fnpurbuf { get; set; }

    public bool Flcnstrpur { get; set; }

    public DateTime Fdvenfence { get; set; }

    public bool FlLatefact { get; set; }

    public bool FlSobuf { get; set; }

    public bool FlPurBuf { get; set; }

    public bool FlHoldStoc { get; set; }

    public decimal FnHoldStoc { get; set; }

    public bool ManualPlan { get; set; }

    public bool FlSendSlx { get; set; }

    public string FcSlxprod { get; set; }

    public DateTime SchedDate { get; set; }

    public string Flocbfdef { get; set; }

    public string Fbinbfdef { get; set; }

    public int DockTime { get; set; }

    public decimal Fnifttime { get; set; }

    public bool FlSynchOn { get; set; }

    public string Fshipvia { get; set; }

    public string Fecname { get; set; }

    public string Fecdesc { get; set; }

    public string Fecfulldesc { get; set; }

    public bool Fecsync { get; set; }

    public string FecprodId { get; set; }

    public DateTime Fecsyncdt { get; set; }

    public string Fecsku { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public decimal Fonhand { get; set; }

    public decimal Fqtyinspec { get; set; }

    public decimal Fnonnetqty { get; set; }

    public decimal Fproqty { get; set; }

    public decimal? Fonorder { get; set; }

    public decimal? Fbook { get; set; }

    public DateTime Flastiss { get; set; }

    public DateTime Flastrcpt { get; set; }

    public decimal Fmtdiss { get; set; }

    public decimal Fytdiss { get; set; }

    public decimal Fmtdrcpt { get; set; }

    public decimal Fytdrcpt { get; set; }

    public decimal Fintransit { get; set; }
}
