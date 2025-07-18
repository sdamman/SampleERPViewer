namespace SEV.Domain.Models
{
  public class JobOrderDetail
  {

    public string OperationID { get; set; }
    public string WorkCenter { get; set; }
    // Estimated Hours is a calculated quantity.
    public double EstimatedHours { get; set; }
    public double ActualHours { get; set; }
    public DateTime? LastCompletionDate { get; set; }
    public DateTime? ScheduleStart { get; set; }
    public DateTime? ScheduleFinish { get; set; }

    public JobOrderDetail()
    {
    }
  }
}
