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

  public partial class ViewModelSalesOrder : ViewModelBase
  {

    private readonly IRepositoryInventory _repositoryInventory;

    public IRelayCommand<string> CommandGetSalesOrder { get; }
    public IRelayCommand CommandCopySalesOrder { get; }

    [ObservableProperty]
    private string salesOrderNumber;
    [ObservableProperty]
    private string status;
    [ObservableProperty]
    private string company;
    [ObservableProperty]
    private string customerNumber;
    [ObservableProperty]
    private string soldToAddress;
    [ObservableProperty]
    private string soldToCity;
    [ObservableProperty]
    private string soldToState;
    [ObservableProperty]
    private string soldToCountry;
    [ObservableProperty]
    private string soldToPostalCode;
    [ObservableProperty]
    private string serialNumber;
    [ObservableProperty]
    private string model;
    [ObservableProperty]
    private string city;
    [ObservableProperty]
    private string memo1;
    [ObservableProperty]
    private List<SalesOrderItem> items = [];
    [ObservableProperty]
    private bool isVisible = false;
    [ObservableProperty]
    private string dateForToday = null;
    [ObservableProperty]
    private string dueDateDisplay = null;

    public ViewModelSalesOrder(IRepositoryInventory repositoryInventory)
    {
      _repositoryInventory = repositoryInventory;
      CommandGetSalesOrder = new RelayCommand<string>(GetSalesOrder);
      CommandCopySalesOrder = new RelayCommand(CopySalesOrder);

      DateForToday = DateTime.Now.ToString("yyyy-MMM-dd");
    }

    private void LoadItems(SoMast salesOrder, List<SalesOrderItem> lstItems)
    {
      SalesOrderNumber = salesOrder.Fsono.Trim();
      Status = salesOrder.Fstatus.ToUpper();
      Company = salesOrder.Fcompany;
      CustomerNumber = salesOrder.Fcustno;
      SoldToAddress = salesOrder.Fmstreet;
      SoldToCity = salesOrder.Fcity.Trim();
      SoldToState = salesOrder.Fstate.Trim();
      SoldToCountry = salesOrder.Fcountry.Trim();
      SoldToPostalCode = salesOrder.Fzip.Trim();
      SerialNumber = salesOrder.Fcusrchr1;
      Model = salesOrder.Fcusrchr2;
      City = salesOrder.Fcusrchr3;
      Memo1 = salesOrder.Fmusrmemo1;
      DueDateDisplay = salesOrder.Fduedate.ToString("yyyy-MMM-dd");
      Items = lstItems;
      IsVisible = true;
    }


    public async void GetSalesOrder(string salesOrderNumber = "")
    {
      IsVisible = false;
      try
      {
        await Task.Run(() =>
        {
          if (string.IsNullOrWhiteSpace(salesOrderNumber))
          {
            MessageBox.Show("Please enter a valid Sales Order Number.");
            return;
          }
          if (!salesOrderNumber.StartsWith('0'))
            salesOrderNumber = "0" + salesOrderNumber;
          var soResult = _repositoryInventory.GetSalesOrder(salesOrderNumber);
          var soItems = _repositoryInventory.GetSalesOrderItems(salesOrderNumber);
          if ((soResult != null) && (soItems != null))
            LoadItems(soResult, soItems.ToList());
          else
            MessageBox.Show($"Could not find Sales Order {salesOrderNumber}.");
        });
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void CopySalesOrder()
    {
      string imData = CopySalesOrderData();
      Clipboard.SetText(imData, TextDataFormat.Text);
      DisplayMessage("Sales Order data copied to Clipboard.", MessagePriority.Info);
    }

    private string CopySalesOrderData()
    {
      StringBuilder sb = new();

      sb.Append($"{Company}\t{CustomerNumber}\t{Memo1}\n");
      sb.Append($"{SoldToAddress}\tSerial Number: {SerialNumber}\n");
      sb.Append($"{SoldToCity},{SoldToState}\tModel: {Model}\n");
      sb.Append($"{SoldToCountry}  {SoldToPostalCode}\n");

      if (Items.Count > 0)
      {
        sb.AppendLine("\nItem\tPart Number\tRev\tDescription\tQty\tUOM\tUnit Price\tMemo");

        foreach (SalesOrderItem item in Items)
        {
          string memo = item.ItemMemo.Replace("\r", "");
          memo = memo.Replace("\n", "");
          sb.AppendLine($"'{item.SequenceNumber}\t{item.PartNumber}\t'{item.Revision}"
            + $"\t{item.Description}\t{item.Quantity}\t{item.UnitOfMeasure}"
            + $"\t{item.UnitPrice}\t{memo}");
        }
      }
      return sb.ToString();
    }

  }
}
