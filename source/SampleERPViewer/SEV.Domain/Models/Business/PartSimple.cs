using SEV.Domain.Helpers;
using System.ComponentModel;

namespace SEV.Domain.Models
{
  public class PartSimple
  {
    public string PartNumber { get; set; }
    public string Revision { get; set; }
    public string Description { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal StandardCost { get; set; }
    public string Status { get; set; }

    public PartSimple() { }

    public PartSimple(Inmastx inmast)
    {
      if (inmast != null)
      {
        PartNumber = inmast.Fpartno;
        Revision = inmast.Frev;
        Description = inmast.Fdescript;
        UnitOfMeasure = inmast.Fmeasure;
        StandardCost = inmast.Fstdcost;
        Status = inmast.Fcstscode == "A" ? "Active" : "Obsolete";
      }
    }

  }
}
