using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEV.Domain.Models
{
  public class ItemMaster
  {
    // ########  Master
    public string PartNumber { get; set; }
    public string Description { get; set; }
    public string Revision { get; set; }
    public decimal StandardCost { get; set; }
    public string UnitOfMeasure { get; set; }
    public string Location { get; set; }
    public string Memo { get; set; }
    public string Comment { get; set; }
    public decimal QuantityOnHand { get; set; }
    public decimal QuantityAvailable { get; set; }
    public string Status { get; set; }
    public string UserDefinedMemo { get; set; }

    // ########  Vendors
    public List<VendorForPart> VendorInformation { get; set; } = [];


    public ItemMaster() { }
  }
}
