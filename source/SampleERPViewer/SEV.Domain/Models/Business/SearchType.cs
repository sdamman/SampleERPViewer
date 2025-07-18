using static SEV.Domain.Helpers.Enums;

namespace SEV.Domain.Models
{
  public class SearchType(SearchFor type, string description)
  {
    public SearchFor SType { get; set; } = type;
    public string Description { get; set; } = description;
  }
}
