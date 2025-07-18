using System;
using System.Globalization;
using System.Windows.Data;

namespace SEV.UI.Converters
{
  public class RoundDecimalsConverter : IValueConverter
  {
    public object Convert(object value, Type targetType,
      object parameter, CultureInfo culture)
    {
      if (value == null) return null;
      if (!int.TryParse((string)parameter, out int places)) places = 2;
      if ((value is decimal) || (value is double) || (value is int))
          return Math.Round((double)value, places);
      else
        return null;
    }

    public object ConvertBack(object value, Type targetType,
      object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
