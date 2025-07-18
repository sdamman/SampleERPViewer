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
  public partial class ViewModelWhereUsed : ViewModelBase
  {

    public IRelayCommand CommandCopyWhereUsed { get; }
    public IRelayCommand CommandCopyWhereUsedJob { get; }

    public ViewModelWhereUsed()
    {
      CommandCopyWhereUsed = new RelayCommand(CopyWhereUsed);
      CommandCopyWhereUsedJob = new RelayCommand(CopyWhereUsedJob);
      DateForToday = DateTime.Now.ToString("yyyy-MMM-dd");
    }

    [ObservableProperty]
    private List<BomWhereUsed> whereUsedList = [];
    [ObservableProperty]
    private List<JodBomWhereUsed> whereUsedJobList = [];
    [ObservableProperty]
    private List<JodBomWhereUsed> whereUsedJobListDisplay = [];
    [ObservableProperty]
    private bool isWhereUsedVisible = false;
    [ObservableProperty]
    private bool? isParentAscending = null;
    [ObservableProperty]
    private bool? isParentDescriptionAscending = null;
    [ObservableProperty]
    private bool? isJobNumberAscending = null;
    [ObservableProperty]
    private bool? isJobParentAscending = null;
    [ObservableProperty]
    private bool? isSalesOrderAscending = null;
    [ObservableProperty]
    private bool? isJobStatusAscending = null;
    [ObservableProperty]
    private bool areClosedOrdersHidden = false;
    [ObservableProperty]
    private string dateForToday = null;

    private bool doNotSort = false;

    partial void OnWhereUsedJobListChanged(List<JodBomWhereUsed> value)
    {
      WhereUsedJobListDisplay = value;
    }

    partial void OnIsParentAscendingChanged(bool? value)
    {
      if (value == null) return;
      if ((bool)value)
        WhereUsedList = WhereUsedList.OrderBy(p => p.ParentPart).ToList();
      else
        WhereUsedList = WhereUsedList.OrderByDescending(p => p.ParentPart).ToList();

      IsParentDescriptionAscending = null;
    }

    partial void OnIsParentDescriptionAscendingChanged(bool? value)
    {
      if (value == null) return;
      if ((bool)value)
        WhereUsedList = WhereUsedList.OrderBy(d => d.ParentDescription).ToList();
      else
        WhereUsedList = WhereUsedList.OrderByDescending(d => d.ParentDescription).ToList();

      IsParentAscending = null;
    }

    partial void OnIsJobNumberAscendingChanged(bool? value)
    {
      if (value == null) return;
      if (doNotSort)
      {
        doNotSort = false;
        return;
      }
      ResetSorting();
      if ((bool)value)
        WhereUsedJobListDisplay = WhereUsedJobListDisplay.OrderBy(j => j.JobNumber).ToList();
      else
        WhereUsedJobListDisplay = WhereUsedJobListDisplay.OrderByDescending(j => j.JobNumber).ToList();
      // Prevents recursive calls to this method.
      doNotSort = true;
      IsJobNumberAscending = value;
    }

    partial void OnIsJobParentAscendingChanged(bool? value)
    {
      if (value == null) return;
      if (doNotSort)
      {
        doNotSort = false;
        return;
      }
      ResetSorting();
      if ((bool)value)
        WhereUsedJobListDisplay = WhereUsedJobListDisplay.OrderBy(j => j.ParentPart).ToList();
      else
        WhereUsedJobListDisplay = WhereUsedJobListDisplay.OrderByDescending(j => j.ParentPart).ToList();
      // Prevents recursive calls to this method.
      doNotSort = true;
      IsJobParentAscending = value;
    }

    partial void OnIsSalesOrderAscendingChanged(bool? value)
    {
      if (value == null) return;
      if (doNotSort)
      {
        doNotSort = false;
        return;
      }
      ResetSorting();
      if ((bool)value)
        WhereUsedJobListDisplay = WhereUsedJobListDisplay.OrderBy(j => j.SalesOrder).ToList();
      else
        WhereUsedJobListDisplay = WhereUsedJobListDisplay.OrderByDescending(j => j.SalesOrder).ToList();
      // Prevents recursive calls to this method.
      doNotSort = true;
      IsSalesOrderAscending = value;
    }

    partial void OnIsJobStatusAscendingChanged(bool? value)
    {
      if (value == null) return;
      if (doNotSort)
      {
        doNotSort = false;
        return;
      }
      ResetSorting();
      if ((bool)value)
        WhereUsedJobListDisplay = WhereUsedJobListDisplay.OrderBy(j => j.JobStatus).ToList();
      else
        WhereUsedJobListDisplay = WhereUsedJobListDisplay.OrderByDescending(j => j.JobStatus).ToList();
      // Prevents recursive calls to this method.
      doNotSort = true;
      IsJobStatusAscending = value;
    }

    partial void OnAreClosedOrdersHiddenChanged(bool value)
    {
      if ((bool)value)
        WhereUsedJobListDisplay = WhereUsedJobList.Where(j => j.JobStatus != "CLOSED").ToList();
      else
        WhereUsedJobListDisplay = WhereUsedJobList;
    }

    private void ResetSorting()
    {
      IsJobNumberAscending = null;
      IsJobParentAscending = null;
      IsSalesOrderAscending = null;
      IsJobStatusAscending = null;
    }

    private void CopyWhereUsed()
    {
      string bomData = CopyWhereUsedData();
      Clipboard.SetText(bomData, TextDataFormat.Text);
      DisplayMessage("Where Used data copied to Clipboard.", MessagePriority.Info);
    }

    private void CopyWhereUsedJob()
    {
      string bomData = CopyWhereUsedJobData();
      Clipboard.SetText(bomData, TextDataFormat.Text);
      DisplayMessage("Where Used Job data copied to Clipboard.", MessagePriority.Info);
   }

    private string CopyWhereUsedData()
    {
      StringBuilder sb = new();
      if (WhereUsedList.Count > 0)
      {
        sb.AppendLine("Parent\tParent Rev\tParent Description\tSource\tQuantity Per");

        foreach (BomWhereUsed b in WhereUsedList)
          sb.AppendLine($"{b.ParentPart}\t{b.ParentRev}\t{b.ParentDescription}\t{b.QuantityPer}");
      }
      return sb.ToString();
    }

    private string CopyWhereUsedJobData()
    {
      StringBuilder sb = new();
      if (WhereUsedJobList.Count > 0)
      {
        sb.AppendLine("Job Number\tParent Part\tParent Rev\tSales Order\tJob Status\tQty Needed\tQty Issued");
        foreach (JodBomWhereUsed j in WhereUsedJobList)
          sb.AppendLine($"{j.JobNumber}\t{j.ParentPart}\t{j.ParentRev}\t{j.SalesOrder}\t{j.JobStatus}\t{j.QuantityNeeded}\t{j.QuantityIssued}");
      }
      return sb.ToString();
    }

  }

}
