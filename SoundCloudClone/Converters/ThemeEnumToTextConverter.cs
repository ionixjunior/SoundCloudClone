using System;
using System.Globalization;
using SoundCloudClone.Enums;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SoundCloudClone.Converters
{
    public class ThemeEnumToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ThemeEnum themeEnum)
            {
                return themeEnum switch
                {
                    ThemeEnum.Light => "Light",
                    ThemeEnum.Dark => "Dark",
                    ThemeEnum.System => "System",
                    ThemeEnum.BatterySaver => "Set by Battery Saver",
                    _ => string.Empty
                };
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
