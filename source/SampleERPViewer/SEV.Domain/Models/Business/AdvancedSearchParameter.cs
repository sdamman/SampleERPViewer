using CommunityToolkit.Mvvm.ComponentModel;
using SEV.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEV.Domain.Models
{
  public partial class AdvancedSearchParameter : ObservableObject
  {
    [ObservableProperty]
    private Enums.SearchBy searchByFirst;
    [ObservableProperty]
    private string searchTermFirst;
    [ObservableProperty]
    private bool isEnabled0 = false;
    [ObservableProperty]
    private bool isEnabled1 = false;
    [ObservableProperty]
    private bool isEnabled2 = false;
    [ObservableProperty]
    private Enums.SearchBy searchBy0;
    [ObservableProperty]
    private Enums.SearchBy searchBy1;
    [ObservableProperty]
    private Enums.SearchBy searchBy2;
    [ObservableProperty]
    private List<string> searchTerms = [];

    public AdvancedSearchParameter()
    {
      for (int i = 0; i < 3; i++)
        SearchTerms.Add(null);
    }
  }


}
