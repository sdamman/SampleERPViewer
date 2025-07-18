using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SEV.Domain.Helpers
{
  public class Enums
  {

    public enum SearchBy
    {
      StartsWith,
      EndsWith,
      Contains
    }

    public enum SearchFor
    {
      Description,
      PartNumber,
      VendorPartNumber
    }

  }
}

