using System;
using System.Globalization;
using Humanizer;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SoundCloudClone.Converters
{
    public class NumericalToMetricConverter : IValueConverter
    {
        public string Convert(object value)
        {
            return (string)Convert(value, null, null, null);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int numeric)
                return numeric.ToMetric(decimals: 0);

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
