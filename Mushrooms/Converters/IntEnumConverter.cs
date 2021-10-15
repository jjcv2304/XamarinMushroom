using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Mushrooms.Converters
{
  public class IntEnumConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is Enum)
      {
        return (int)value;
      }
      return 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is int)
      {
        return Enum.ToObject(targetType, value);
      }
      return 0;
    }

    //public object ConvertTo(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //{
    //  if (!(value is DropoffContact))
    //    return value;
    //  switch (DropoffContact)value) {
    //    case DropoffContact.Display:
    //    return "Some string representation"
    //    default:
    //    return value;
    //  }
    //}

    //public void ConvertFrom(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //{
    //  thrown new NotImplementedException();
    //}
  }
}
