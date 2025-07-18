using System;
using System.Globalization;
using System.Windows.Data;

namespace SEV.UI.Converters
{
  internal class CurrencyDisplayConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null) return null;
      if (double.TryParse(value.ToString(), out double currencyValue))
      {
        string roundedVal = string.Format("{0:C2}", Math.Round(currencyValue, 2));
        
        return roundedVal;
      }
      else
        return "?";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
