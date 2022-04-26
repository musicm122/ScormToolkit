using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ScormToolkit_Wpf.ValueConverters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;
            else
            {
                var boolVal = (bool)value;
                if (boolVal)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;

            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}