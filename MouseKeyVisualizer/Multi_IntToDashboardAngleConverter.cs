using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MouseKeyVisualizer
{
    public class Multi_IntToDashboardAngleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 3)
            {
                if (values[0] is double min && values[1] is double max && values[2] is double now)
                {
                    //var minDeg = -40;
                    //var maxDeg = 220;
                    var o = now / (max - min);
                    var deg = -40 + (270) * o;
                    return deg;
                }
            }

            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}