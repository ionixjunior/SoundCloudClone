using System;
using System.Globalization;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Humanizer;

namespace SoundCloudClone.Converters
{
    public class DateTimeToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
                return dateTime.Humanize();

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
