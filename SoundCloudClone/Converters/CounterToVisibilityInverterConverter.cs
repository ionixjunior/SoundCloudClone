using System;
using System.Globalization;
using Xamarin.Forms;

namespace SoundCloudClone.Converters
{
    public class CounterToVisibilityInverterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int counter)
                return counter == 0 ? true : false;

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
