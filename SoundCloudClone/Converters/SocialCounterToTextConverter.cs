using System;
using System.Globalization;
using Xamarin.Forms;

namespace SoundCloudClone.Converters
{
    public class SocialCounterToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int counter)
            {
                if (counter is 0)
                    return string.Empty;

                return $"  {counter}";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
