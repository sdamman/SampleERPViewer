using System;
using System.Globalization;
using System.Windows.Data;

namespace SEV.UI.Converters
{
  public class TrimContentConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null) return null;
      if (value.GetType().Equals(typeof(string)))
      {
        string strVal = value.ToString();
        return strVal.Trim();
      }
      else
        return value;

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
