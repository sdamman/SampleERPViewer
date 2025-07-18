namespace SEV.Domain.Models
{
  public class BomSimple
  {

    public string Parent { get; set; }
    public string ParentRevision { get; set; }
    public string PartNumber { get; set; }
    public string PartRev { get; set; }
    public string Description { get; set; }
    public double Quantity { get; set; }
    public string UnitOfMeasure { get; set; }
    public double StandardCost { get; set; }
    public double QuantityOnHand { get; set; }
    public string Location { get; set; }


    public BomSimple()
    {
    }

    public BomSimple(string parent, string parentRev,
                     string part, string partRev,
                     string description, double quantity,
                     string uom, double stdcost,
                     double qtyonhand, string location)
    {
      Parent = parent;
      ParentRevision = parentRev;
      PartNumber = part;
      PartRev = partRev;
      Description = description;
      Quantity = quantity;
      UnitOfMeasure = uom;
      StandardCost = stdcost;
      QuantityOnHand = qtyonhand;
      Location = location;
    }


  }
}
