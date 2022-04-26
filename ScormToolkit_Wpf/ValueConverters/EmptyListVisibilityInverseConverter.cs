using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ScormToolkit_Wpf.ValueConverters
{
    public class EmptyListVisibilityInverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;
            else
            {
                ICollection list = value as ICollection;
                if (list != null)
                {
                    if (list.Count == 0)
                        return Visibility.Visible;
                    else
                        return Visibility.Collapsed;
                }
                else
                    return Visibility.Collapsed;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)

        {
            throw new NotImplementedException();
        }
    }
}