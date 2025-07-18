using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEV.Domain.Models
{
  public class JodBomWhereUsed
  {

    public string JobNumber { get; set; }
    public string SalesOrder { get; set; }
    public string JobStatus { get; set; }
    public double QuantityNeeded { get; set; }
    public double QuantityIssued { get; set; }
    public string ParentPart { get; set; }
    public string ParentRev { get; set; }

    public JodBomWhereUsed()
    {

    }
  }
}
