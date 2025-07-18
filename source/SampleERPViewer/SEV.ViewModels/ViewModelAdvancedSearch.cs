using CommunityToolkit.Mvvm.ComponentModel;
using SEV.Domain.Helpers;
using SEV.Domain.Models;
using System.Collections.ObjectModel;

namespace SEV.ViewModels
{
  public partial class ViewModelAdvancedSearch : ObservableObject
  {

    [ObservableProperty]
    private AdvancedSearchParameter aSP = new();
    public ObservableCollection<Enums.SearchBy> ListSearchBys { get; } = [];

    public ViewModelAdvancedSearch()
    {
      ListSearchBys.Add(Enums.SearchBy.Contains);
      ListSearchBys.Add(Enums.SearchBy.StartsWith);
      ListSearchBys.Add(Enums.SearchBy.EndsWith);
    }

  }
}
 