namespace SEV.Domain.Models
{
  public class SalesOrderItem
  {
    public string SequenceNumber { get; set; }
    public string PartNumber { get; set; }
    public string Revision { get; set; }
    public string Description { get; set; }
    public double Quantity { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal UnitPrice { get; set; }
    public string ItemMemo { get; set; }

    public SalesOrderItem()
    {
    }

  }
}
