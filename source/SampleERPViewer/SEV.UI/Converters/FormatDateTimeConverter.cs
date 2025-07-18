using System;
using System.Globalization;
using System.Windows.Data;

namespace SEV.UI.Converters
{
  public class FormatDateTimeConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, 
      object parameter, CultureInfo culture)
    {
      if (value == null) return null;
      if ((value is DateTime) || (value is DateTime?))
      {
        return ((DateTime)value).ToString("yyyy-MM-dd HH:mm");
      }
      else
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
