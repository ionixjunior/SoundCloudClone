using System.Collections.Generic;
using SoundCloudClone.Enums;
using SoundCloudClone.Interfaces;
using Xamarin.Essentials;

namespace SoundCloudClone.Services
{
    public class ThemeService : ITheme
    {
        public IList<ThemeEnum> GetOptions()
        {
            var options = new List<ThemeEnum>();

            if (DeviceInfo.Platform == DevicePlatform.Android)
                options.Add(ThemeEnum.BatterySaver);

            if (DeviceInfo.Platform == DevicePlatform.iOS)
                options.Add(ThemeEnum.System);

            options.Add(ThemeEnum.Light);
            options.Add(ThemeEnum.Dark);

            return options;
        }
    }
}
