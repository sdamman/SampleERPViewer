using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace SEV.UI.Converters
{
  public class AssemblyVersionConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      char[] trimChars = new char[] { '.', '0' };
      return $"version {Assembly.GetEntryAssembly().GetName().Version.ToString().TrimEnd(trimChars)}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
