using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SEV.Domain.Models;
using SEV.Domain.Models.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SEV.ViewModels
{
  public partial class ViewModelSearchResults : ViewModelBase
  {
    public IRelayCommand CommandCopySearchResults { get; }

    public ViewModelSearchResults()
    {
      CommandCopySearchResults = new RelayCommand(CopySearchResults);
      DateForToday = DateTime.Now.ToString("yyyy-MMM-dd");
    }

    [ObservableProperty]
    private List<PartSimple> itemsList = [];
    [ObservableProperty]
    private bool isSearchResultsVisible = false;
    [ObservableProperty]
    private bool? isPartAscending = null;
    [ObservableProperty]
    private bool? isDescriptionAscending = null;
    [ObservableProperty]
    private bool? isCostAscending = null;
    [ObservableProperty]
    private string dateForToday = null;

    partial void OnIsPartAscendingChanged(bool? value)
    {
      if (value == null) return;
      if ((bool)value)
        ItemsList = ItemsList.OrderBy(p => p.PartNumber).ToList();
      else
        ItemsList = ItemsList.OrderByDescending(p => p.PartNumber).ToList();

      IsDescriptionAscending = null;
      IsCostAscending = null;
    }

    partial void OnIsDescriptionAscendingChanged(bool? value)
    {
      if (value == null) return;
      if ((bool)value)
        ItemsList = ItemsList.OrderBy(p => p.Description).ToList();
      else
        ItemsList = ItemsList.OrderByDescending(p => p.Description).ToList();

      IsPartAscending = null;
      IsCostAscending = null;
    }

    partial void OnIsCostAscendingChanged(bool? value)
    {
      if (value == null) return;
      if ((bool)value)
        ItemsList = ItemsList.OrderBy(p => p.StandardCost).ToList();
      else
        ItemsList = ItemsList.OrderByDescending(p => p.StandardCost).ToList();

      IsPartAscending = null;
      IsDescriptionAscending = null;
    }

    private void CopySearchResults()
    {
      if (ItemsList.Count > 0)
      {
        if (ItemsList.Count > 100)
          if (UserWarnedOff()) return;

        string bomData = CopySearchResultsData();
        Clipboard.SetText(bomData, TextDataFormat.Text);
        DisplayMessage("Search Results data copied to Clipboard.", MessagePriority.Info);
      }
    }

    private string CopySearchResultsData()
    {
      StringBuilder sb = new();

      sb.AppendLine("P/N\tRev\tDescription\tUOM\tStdCost");

      foreach (PartSimple p in ItemsList)
        sb.AppendLine($"{p.PartNumber}\t{p.Revision}\t{p.Description}\t{p.UnitOfMeasure}\t{p.StandardCost}");

      return sb.ToString();
    }

    private bool UserWarnedOff()
    {
      MessageBoxResult mbr = MessageBox.Show($"There are {ItemsList.Count} search results.\nDo you really want to copy them all?",
        "Large number of results warning", MessageBoxButton.YesNo);
      if (mbr == MessageBoxResult.Yes)
        return false;
      else
        return true;
    }

  }
}
