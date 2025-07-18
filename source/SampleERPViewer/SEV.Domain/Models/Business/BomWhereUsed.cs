namespace SEV.Domain.Models
{
  public class BomWhereUsed
  {
    public string ParentDescription { get; set; }
    public double QuantityPer { get; set; }
    public string ParentPart { get; set; }
    public string ParentRev { get; set; }

    public BomWhereUsed()
    {

    }
  }
}
