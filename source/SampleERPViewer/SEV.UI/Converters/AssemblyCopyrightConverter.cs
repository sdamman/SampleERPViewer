using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Data;

namespace SEV.UI.Converters
{
  internal class AssemblyCopyrightConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      IEnumerable<CustomAttributeData> cad = Assembly.GetEntryAssembly().CustomAttributes;
      CustomAttributeData custAtt = cad.First(x => x.AttributeType.Name == typeof(AssemblyCopyrightAttribute).Name);
      string copy = custAtt.ConstructorArguments[0].ToString().Trim('"');
      string origYear = copy.Substring(1, 4);
      string newYear = DateTime.Now.Year.ToString();
      if (origYear == newYear)
      {
        return copy.Replace("-xxxx", string.Empty);
      }
      else
      {
        return copy.Replace("xxxx", newYear);
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
