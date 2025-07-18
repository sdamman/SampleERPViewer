using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SEV.Domain.Models;
using SEV.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;
using System.Text;
using System;
using static SEV.Domain.Helpers.Enums;
using SEV.Domain.Models.Messaging;

namespace SEV.ViewModels
{

  public partial class ViewModelMain : ViewModelBase
  {

    private readonly IRepositoryInventory _repositoryInventory;

    public IRelayCommand<string> CommandGetBom { get; }
    public IRelayCommand<string> CommandGetWhereUsed { get; }
    public IRelayCommand<string> CommandGetItemMaster { get; }
    public IRelayCommand<string> CommandSearch { get; }
    public IRelayCommand<AdvancedSearchParameter> CommandSearchAdvanced { get; }
    public IRelayCommand<string> CommandCallSalesOrder { get; }
    public IRelayCommand<string> CommandCallJobOrder { get; }
    public IRelayCommand CommandCopyItemMaster { get; }
    public IRelayCommand CommandCopyBom { get; }

    public ViewModelMain(IRepositoryInventory repositoryInventory)
    {
      CommandGetBom = new RelayCommand<string>(GetBom);
      CommandGetWhereUsed = new RelayCommand<string>(GetWhereUsed);
      CommandGetItemMaster = new RelayCommand<string>(GetItemMaster);
      CommandSearch = new RelayCommand<string>(SearchBy);
      CommandSearchAdvanced = new RelayCommand<AdvancedSearchParameter>(SearchAdvanced);
      CommandCallSalesOrder = new RelayCommand<string>(CallSalesOrder);
      CommandCallJobOrder = new RelayCommand<string>(CallJobOrder);
      CommandCopyItemMaster = new RelayCommand(CopyItemMaster);
      CommandCopyBom = new RelayCommand(CopyBom);

      _repositoryInventory = repositoryInventory;

      VMSO = new(_repositoryInventory);
      vMJO = new(_repositoryInventory);

      DateForToday = DateTime.Now.ToString("yyyy-MMM-dd");

      BuildSearchTypes();
    }


    //
    // ######### Properties ##########
    // 
    [ObservableProperty]
    private ViewModelWhereUsed vMWU = new();
    [ObservableProperty]
    private ViewModelSearchResults vMSR = new();
    [ObservableProperty]
    private ViewModelAdvancedSearch vMAS = new();
    [ObservableProperty]
    private ViewModelSalesOrder vMSO;
    [ObservableProperty]
    private ViewModelJobOrder vMJO;
    [ObservableProperty]
    private string version = null;
    [ObservableProperty]
    private string copyright = null;
    [ObservableProperty]
    private List<SearchType> searchTypes = [];
    [ObservableProperty]
    private SearchType selectedSearchType;
    [ObservableProperty]
    private int selectedSearchIndex = -1;
    [ObservableProperty]
    private string title = "Made 2 View";
    [ObservableProperty]
    private string parentNumber = null;
    [ObservableProperty]
    private string partDescription = null;
    [ObservableProperty]
    private string tableInfo = null;
    [ObservableProperty]
    private List<BomSimple> bomList = [];
    [ObservableProperty]
    private PartSimple partSummary = new();
    [ObservableProperty]
    private ItemMaster item = new();
    [ObservableProperty]
    private bool isBomVisible = false;
    [ObservableProperty]
    private bool isSimplePartVisible = false;
    [ObservableProperty]
    private bool isItemMasterVisible = false;
    [ObservableProperty]
    private bool isStartsWith = false;
    [ObservableProperty]
    private bool isEndsWith = false;
    [ObservableProperty]
    private bool isContains = true;
    [ObservableProperty]
    private bool isAppBusy = false;
    [ObservableProperty]
    private bool areButtonsEnabled = true;
    [ObservableProperty]
    private string dateForToday = null;
    [ObservableProperty]
    private bool isPartNumberSelected = true;
    [ObservableProperty]
    private bool isSalesOrderSelected = false;
    [ObservableProperty]
    private bool isJobOrderSelected = false;
    private string content = null;
    private MessagePriority priority = MessagePriority.Info;


    //
    // ######### Methods ##########
    // 
    private async void GetBom(string item = "")
    {
      AreButtonsEnabled = false;
      IsAppBusy = true;
      HideAllScreens();
      try
      {
        await Task.Run(() =>
        {
          ParentNumber = item;
          GetPartSummary(item);
          if (PartSummary.PartNumber == null)
            DisplayMessage(ErrorMessage.PartNotFound.GetDescription(), MessagePriority.Error);
          else
          {
            IsBomVisible = true;
            IsSimplePartVisible = true;
            BomList = _repositoryInventory.GetBomOfPart(item).ToList();
            if (BomList.Count == 0)
              DisplayMessage(ErrorMessage.BomNotFound.GetDescription(), MessagePriority.Warning);
          }
        });
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      finally
      {
        AreButtonsEnabled = true;
        IsAppBusy = false;
      }
    }

    private async void GetWhereUsed(string item = "")
    {
      AreButtonsEnabled = false;
      IsAppBusy = true;
      HideAllScreens();
      ParentNumber = item;
      await Task.Run(() =>
      {
        GetPartSummary(item);
        if (PartSummary.PartNumber == null)
          DisplayMessage(ErrorMessage.PartNotFound.GetDescription(), MessagePriority.Error);
        else
        {
          VMWU.IsWhereUsedVisible = true;
          IsSimplePartVisible = true;
          VMWU.WhereUsedList = _repositoryInventory.GetWhereUsedByPart(item,
                                                                       PartSummary.Revision);
          VMWU.WhereUsedJobList = _repositoryInventory.GetWhereUsedJobByPart(item,
                                                                      PartSummary.Revision);
        }
      });
      AreButtonsEnabled = true;
      IsAppBusy = false;
    }

    private void GetItemMaster(string item = "")
    {
      HideAllScreens();
      try
      {
        var itemMasterResult = _repositoryInventory.GetItemMaster(item, ref content, ref priority);
        if (itemMasterResult == null)
          DisplayMessage(content, priority);
        else
        {
          IsPartNumberSelected = true;
          IsItemMasterVisible = true;
          ParentNumber = item;
          Item = itemMasterResult;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void SearchBy(string parameter = "")
    {
      if (SelectedSearchType != null)
      {
        switch (SelectedSearchType.SType)
        {
          case SearchFor.Description:
            SearchByDescription(parameter);
            break;
          case SearchFor.PartNumber:
            SearchByPartialPartNumber(parameter);
            break;
          case SearchFor.VendorPartNumber:
            SearchByVendorPartNumber(parameter);
            break;
          default:
            break;
        }
      }
    }

    private async void SearchByDescription(string description = "")
    {
      HideAllScreens();
      if (SearchTermIsValid(description))
      {
        IsAppBusy = true;
        AreButtonsEnabled = false;
        if (IsStartsWith)
        {
          await Task.Run(() =>
          {
            VMSR.ItemsList =
            _repositoryInventory.SearchByDescriptionStartsWith(description).ToList();
          });
        }
        if (IsEndsWith)
        {
          await Task.Run(() =>
          {
            VMSR.ItemsList =
            _repositoryInventory.SearchByDescriptionEndsWith(description).ToList();
          });
        }
        if (IsContains)
        {
          await Task.Run(() =>
          {
            VMSR.ItemsList =
            _repositoryInventory.SearchByDescriptionContains(description).ToList();
          });
        }
        VMSR.IsSearchResultsVisible = true;
        IsAppBusy = false;
        AreButtonsEnabled = true;
      }
    }

    public async void SearchAdvanced(AdvancedSearchParameter searchParam)
    {
      HideAllScreens();
      IsAppBusy = true;
      AreButtonsEnabled = false;

      await Task.Run(() =>
      {
        VMSR.ItemsList =
          _repositoryInventory.SearchAdvanced(searchParam).ToList();
      });

      VMSR.IsSearchResultsVisible = true;
      IsAppBusy = false;
      AreButtonsEnabled = true;
    }

    public async void SearchByVendorPartNumber(string parameter)
    {
      if (string.IsNullOrEmpty(parameter)) return;
      HideAllScreens();
      IsAppBusy = true;
      AreButtonsEnabled = false;

      await Task.Run(() =>
      {
        VMSR.ItemsList =
        _repositoryInventory.SearchByVendorPartNumber(parameter).ToList();
      });

      VMSR.IsSearchResultsVisible = true;
      IsAppBusy = false;
      AreButtonsEnabled = true;
    }

    public async void SearchByPartialPartNumber(string parameter)
    {
      if (string.IsNullOrEmpty(parameter)) return;
      HideAllScreens();
      IsAppBusy = true;
      AreButtonsEnabled = false;

      await Task.Run(() =>
      {
        VMSR.ItemsList =
        _repositoryInventory.SearchByPartialPartNumber(parameter).ToList();
      });

      VMSR.IsSearchResultsVisible = true;
      IsAppBusy = false;
      AreButtonsEnabled = true;
    }

    public void CallSalesOrder(string orderNum = null)
    {
      VMSO.GetSalesOrder(orderNum);
      IsSalesOrderSelected = true;
    }

    public void CallJobOrder(string jobNum = null)
    {
      VMJO.GetJobOrder(jobNum);
      IsJobOrderSelected = true;
    }

    private void GetPartSummary(string partNum)
    {
      var singleInmast = _repositoryInventory.GetPartByNumber(partNum);
      PartSummary = new(singleInmast);
    }



    private void HideAllScreens()
    {
      IsSimplePartVisible = false;
      IsBomVisible = false;
      VMWU.IsWhereUsedVisible = false;
      IsItemMasterVisible = false;
      VMSR.IsSearchResultsVisible = false;
    }

    private bool SearchTermIsValid(string searchTerm)
    {
      if (string.IsNullOrWhiteSpace(searchTerm)) return false;
      
      if (searchTerm.Contains('%'))
      {
        DisplayMessage(ErrorMessage.InvalidSearchTerms.GetDescription(), MessagePriority.Warning);
        return false;
      }
      return true;
    }

    private void CopyItemMaster()
    {
      string imData = CopyItemMasterData();
      Clipboard.SetText(imData, TextDataFormat.Text);
      DisplayMessage("Item Master data copied to Clipboard.", MessagePriority.Info);
    }


    private string CopyItemMasterData()
    {
      StringBuilder sb = new();
      sb.Append($"P/N: {Item.PartNumber}\tStd Cost: {Item.StandardCost}\n");
      sb.Append($"Description: {Item.Description}\tUOM: {Item.UnitOfMeasure}\n");
      sb.Append($"Current Revision: {Item.Revision}\tQty On Hand: {Item.QuantityOnHand}\n");
      sb.Append($"Location: {Item.Location}\tQty Available: {Item.QuantityAvailable}\n");
      sb.Append($"Memo: {Item.Memo}\tComment: {Item.Comment}\n");
      sb.Append($"User Defined Memo: {Item.UserDefinedMemo}\n");

      if (Item.VendorInformation.Count > 0)
      {
        sb.AppendLine("\nVendor#\tVendor Name\tVendor P/N\tDescription\tComment");

        foreach (VendorForPart vendor in Item.VendorInformation)
          sb.AppendLine($"{vendor.VendorNumber}\t{vendor.VendorName}\t{vendor.PartNumber}"
            + $"\t{vendor.Description}\t{vendor.Comments}");
      }
      return sb.ToString();
    }


    private void CopyBom()
    {
      string bomData = CopyBomData();
      Clipboard.SetText(bomData, TextDataFormat.Text);
      DisplayMessage("BOM data copied to Clipboard.", MessagePriority.Info);
    }

    private string CopyBomData()
    {
      StringBuilder sb = new();
      if (BomList.Count > 0)
      {
        sb.AppendLine("Parent\tParent Rev\tP/N\tPart Rev\tDescription\tQTY\tUOM"
                      + "\tStdCost\tOnHand\tBin");

        foreach (BomSimple b in BomList)
          sb.AppendLine($"{b.Parent}\t{b.ParentRevision}\t{b.PartNumber}\t{b.PartRev}"
            + $"\t{b.Description}\t{b.Quantity}\t{b.UnitOfMeasure}\t{b.StandardCost}"
            + $"\t{b.QuantityOnHand}\t{b.Location}");
      }

      return sb.ToString();
    }


    private void BuildSearchTypes()
    {
      SearchTypes.Add(new SearchType(SearchFor.Description, "by Description"));
      SearchTypes.Add(new SearchType(SearchFor.VendorPartNumber, "by Vendor P/N"));
      SearchTypes.Add(new SearchType(SearchFor.PartNumber, "by Part Number"));
      SelectedSearchIndex = 0;
    }


  }

}
