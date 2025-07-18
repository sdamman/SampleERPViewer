using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SEV.UI.Converters
{
  public class NullToCollapsedConverter : IValueConverter
  {
    public object Convert(object value, Type targetType,
                          object parameter, CultureInfo culture)
    {
      if (value == null) return Visibility.Collapsed;
      else
      {
        if ((value is string) && (string.IsNullOrWhiteSpace(value as string)))
        {
          return Visibility.Collapsed;
        }
        else
          return Visibility.Visible;
      }
    }

    public object ConvertBack(object value, Type targetType,
                              object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
