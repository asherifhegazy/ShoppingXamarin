using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace eShopApp.Converters
{
    public class StringToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool ButtonIsEnabled = false;

            if (value == null)
                return false;

            if (!string.IsNullOrEmpty(value.ToString()))
            {
                ButtonIsEnabled = Regex.IsMatch(value.ToString(), "^[A-Za-z0-9]*$");
            }

            return ButtonIsEnabled;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
