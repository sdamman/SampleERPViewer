namespace SEV.Domain.Models.Messaging
{
  public enum ErrorMessage
  {
    None,
    PartNotFound,
    BomNotFound,
    SalesOrderNotFound,
    JobOrderNotFound,
    MissingRevision,
    MissingSearchTerms,
    InvalidSearchTerms
  }


  public static class ErrorMessageExtensions
  {
    public static string GetDescription(this ErrorMessage errorMessage)
    {
      return errorMessage switch
      {
        ErrorMessage.None =>
          "No error",
        ErrorMessage.PartNotFound =>
          "Part Number or Material not found in the system.",
        ErrorMessage.BomNotFound =>
          "Bill of Material not found for the specified Part Number. ",
        ErrorMessage.SalesOrderNotFound =>
          "Sales Order not found.",
        ErrorMessage.JobOrderNotFound =>
          "Job Order not found.",
        ErrorMessage.MissingRevision =>
          "Part Number was found, but it is not marked with a current revision, " +
          "so it is not valid for use.  Check ERP System with Live ERP Tool.",
        ErrorMessage.MissingSearchTerms =>
          "No search terms were entered.  Cannot run search.",
        ErrorMessage.InvalidSearchTerms =>
          "The '%' wildcard character is not valid.\n" +
          "Please remove and try again." ,
        _ => "Unknown error"
      };
    }
  }


}
