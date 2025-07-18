using SEV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SEV.UI.Converters
{

  internal class ListToVisibilityConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null)
        return Visibility.Collapsed;

      List<BomWhereUsed> bomList = [];
      List<JodBomWhereUsed> jodBomList = [];
      if (bomList.GetType() == value.GetType())
      {
        bomList = (List<BomWhereUsed>)value;
        if (bomList.Count > 0)
          return Visibility.Visible;
        else
          return Visibility.Collapsed;
      }
      else if (jodBomList.GetType() == value.GetType())
      {
        jodBomList = (List<JodBomWhereUsed>)value;
        if (jodBomList.Count > 0)
          return Visibility.Visible;
        else
          return Visibility.Collapsed;
      }

      return Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }

  class GenericList<T> : List<T>
  {

  }
}
