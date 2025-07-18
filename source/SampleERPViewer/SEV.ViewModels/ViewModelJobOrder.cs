using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SEV.Data.Repositories;
using SEV.Domain.Models;
using SEV.Domain.Models.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SEV.ViewModels
{
  public partial class ViewModelJobOrder : ViewModelBase
  {

    private readonly IRepositoryInventory _repositoryInventory;

    public IRelayCommand<string> CommandSearchJobOrder { get; }
    public IRelayCommand CommandCopyRouting { get; }
    public IRelayCommand CommandCopyJobList { get; }
    public IRelayCommand<string> CommandGetJobOrder { get; }

    [ObservableProperty]
    private string jobOrderNumber = null;
    [ObservableProperty]
    private string salesOrderNumber = null;
    [ObservableProperty]
    private string partNumber = null;
    [ObservableProperty]
    private string description;
    [ObservableProperty]
    private string group;
    [ObservableProperty]
    private string status;
    [ObservableProperty]
    private double quantity;
    [ObservableProperty]
    private string productClass;
    [ObservableProperty]
    private DateTime? dueDate;
    [ObservableProperty]
    private DateTime? releaseDate;
    [ObservableProperty]
    private DateTime? actualReleaseDate;
    [ObservableProperty]
    private DateTime? startDate;
    [ObservableProperty]
    private List<JobOrderDetail> jobOrderDetails = [];
    [ObservableProperty]
    private List<JobOrderSimple> jobOrderList = [];
    [ObservableProperty]
    private string dateForToday = null;
    [ObservableProperty]
    private bool isJobOrder = true;
    [ObservableProperty]
    private bool isPartNumber = false;
    [ObservableProperty]
    private bool isSalesOrder = false;
    [ObservableProperty]
    private string searchParameter = null;
    [ObservableProperty]
    private bool isJobOrderDetailVisible = false;
    [ObservableProperty]
    private bool isJobOrderListVisible = false;

    public ViewModelJobOrder(IRepositoryInventory repositoryInventory)
    {
      _repositoryInventory = repositoryInventory;
      CommandSearchJobOrder = new RelayCommand<string>(SearchJobOrder);
      CommandCopyRouting = new RelayCommand(CopyRouting);
      CommandCopyJobList = new RelayCommand(CopyJobList);
      CommandGetJobOrder = new RelayCommand<string>(GetJobOrder);

      DateForToday = DateTime.Now.ToString("yyyy-MMM-dd");
    }

    public void GetJobOrder(string jobOrderNumber = null)
    {
      SearchJobOrderComplete(jobOrderNumber, true, false, false);
    }

    private void SearchJobOrder(string parameter = null)
    {
      if (string.IsNullOrWhiteSpace(parameter))
      {
        MessageBox.Show("Please enter a search term.");
        return;
      }
      SearchJobOrderComplete(parameter);
    }

    private async void SearchJobOrderComplete(string parameter = null,
                                      bool? searchByJobOrder = null,
                                      bool? searchBySalesOrder = null,
                                      bool? searchByPartNumber = null)
    {
      IsJobOrderDetailVisible = false;
      IsJobOrderListVisible = false;

      searchByJobOrder ??= IsJobOrder;
      searchBySalesOrder ??= IsSalesOrder;
      searchByPartNumber ??= IsPartNumber;
      try
      {
        //searchByJobOrder
        await Task.Run(() =>
        {
          JoMast joResult = new();
          // Search by Job Order number.
          if ((bool)searchByJobOrder)
          {
            JobOrderList = _repositoryInventory.GetJobOrderByJO(parameter).ToList();
            if (JobOrderList == null)
            {
              MessageBox.Show($"Could not find Job Order(s) for {parameter}.");
              return;
            }
            else if (JobOrderList.Count == 1)
            {
              joResult = _repositoryInventory.GetJobOrderByNumber(JobOrderList[0].JobOrderNumber);
            }
            else
            {
              IsJobOrderListVisible = true;
              return;
            }
          }
          // Search by sales order number.
          else if ((bool)searchBySalesOrder)
          {
            if (!parameter.StartsWith('0'))
              parameter = "0" + parameter;
            JobOrderList = _repositoryInventory.GetJobOrderBySalesOrder(parameter).ToList();
            if (JobOrderList == null)
            {
              MessageBox.Show($"Could not find Job Order(s) for Sales Order {parameter}.");
              return;
            }
            else
            {
              IsJobOrderListVisible = true;
              return;
            }
          }
          // Search by part number.
          else if ((bool)searchByPartNumber)
          {
            JobOrderList = _repositoryInventory.GetJobOrderByPart(parameter).ToList();
            if (JobOrderList == null)
            {
              MessageBox.Show($"Could not find Job Order(s) for Part Number {parameter}.");
              return;
            }
            else
            {
              IsJobOrderListVisible = true;
              return;
            }
          }
          else
            return;

          var joItem = _repositoryInventory.GetJobItemByJobNumber(joResult.Fjobno);
          var details = _repositoryInventory.GetJobOrdersDetail(joResult.Fjobno);
          BuildJobOrder(joResult, joItem, details.ToList());
          IsJobOrderDetailVisible = true;

        });

      }
      catch (Exception)
      {

        throw;
      }
    }

    private void BuildJobOrder(JoMast joResult, JoItem joItem,
                                List<JobOrderDetail> details)
    {
      JobOrderNumber = joResult.Fjobno;
      SalesOrderNumber = joResult.Fsono;
      PartNumber = joItem.Fpartno;
      Description = joItem.Fdesc;
      Group = joItem.Fgroup;
      Status = joResult.Fstatus;
      Quantity = (double)joResult.Fquantity;
      ProductClass = joResult.Fprodcl;
      DueDate = joResult.FddueDate;
      ReleaseDate = joResult.FrelDt;
      ActualReleaseDate = joResult.FactRel;
      StartDate = joResult.FstrtDate;
      JobOrderDetails = details;
    }

    private void CopyRouting()
    {
      string imData = CopyRoutingData();
      Clipboard.SetText(imData, TextDataFormat.Text);
      DisplayMessage("Routing data copied to Clipboard.", MessagePriority.Info);
    }

    private void CopyJobList()
    {
      string imData = CopyJobListData();
      Clipboard.SetText(imData, TextDataFormat.Text);
      DisplayMessage("Job List copied to Clipboard.", MessagePriority.Info);
    }


    private string CopyRoutingData()
    {
      StringBuilder sb = new();

      //sb.Append($"{Company}\t{CustomerNumber}\t{Memo1}\n");
      //sb.Append($"{SoldToAddress}\tSerial Number: {SerialNumber}\n");
      //sb.Append($"{SoldToCity},{SoldToState}\tModel: {Model}\n");
      //sb.Append($"{SoldToCountry}  {SoldToPostalCode}\n");

      //if (Items.Count > 0)
      //{
      //  sb.AppendLine("\nItem\tPart Number\tRev\tDescription\tQty\tUOM\tUnit Price\tMemo");

      //  foreach (SalesOrderItem item in Items)
      //  {
      //    string memo = item.ItemMemo.Replace("\r", "");
      //    memo = memo.Replace("\n", "");
      //    sb.AppendLine($"'{item.SequenceNumber}\t{item.PartNumber}\t'{item.Revision}"
      //      + $"\t{item.Description}\t{item.Quantity}\t{item.UnitOfMeasure}"
      //      + $"\t{item.UnitPrice}\t{memo}");
      //  }
      //}
      return sb.ToString();
    }

    private string CopyJobListData()
    {
      StringBuilder sb = new();

      //sb.Append($"{Company}\t{CustomerNumber}\t{Memo1}\n");
      //sb.Append($"{SoldToAddress}\tSerial Number: {SerialNumber}\n");
      //sb.Append($"{SoldToCity},{SoldToState}\tModel: {Model}\n");
      //sb.Append($"{SoldToCountry}  {SoldToPostalCode}\n");

      //if (Items.Count > 0)
      //{
      //  sb.AppendLine("\nItem\tPart Number\tRev\tDescription\tQty\tUOM\tUnit Price\tMemo");

      //  foreach (SalesOrderItem item in Items)
      //  {
      //    string memo = item.ItemMemo.Replace("\r", "");
      //    memo = memo.Replace("\n", "");
      //    sb.AppendLine($"'{item.SequenceNumber}\t{item.PartNumber}\t'{item.Revision}"
      //      + $"\t{item.Description}\t{item.Quantity}\t{item.UnitOfMeasure}"
      //      + $"\t{item.UnitPrice}\t{memo}");
      //  }
      //}
      return sb.ToString();
    }

  }
}
