namespace SEV.Domain.Models
{
  public class JobOrderSimple
  {
    public string JobOrderNumber { get; set; }
    public string SalesOrderNumber { get; set; }
    public string PartNumber { get; set; }
    public string Status { get; set; }
    public double Quantity { get; set; }
    public DateTime? DueDate { get; set; }

    public JobOrderSimple()
    {
    }

  }
}
