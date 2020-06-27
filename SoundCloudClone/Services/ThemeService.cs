using System.Collections.Generic;
using SoundCloudClone.Enums;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Models.App;
using SoundCloudClone.Styles;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SoundCloudClone.Services
{
    public class ThemeService : ITheme
    {
        public IList<Theme> GetOptions()
        {
            var options = new List<Theme>();

            if (DeviceInfo.Platform == DevicePlatform.Android)
                options.Add(new Theme(ThemeEnum.BatterySaver, false));

            if (DeviceInfo.Platform == DevicePlatform.iOS)
                options.Add(new Theme(ThemeEnum.System, false));

            options.Add(new Theme(ThemeEnum.Light, false));
            options.Add(new Theme(ThemeEnum.Dark, true));

            return options;
        }

        public void Change(ThemeEnum theme)
        {
            var appStyle = theme switch
            {
                ThemeEnum.Light => new LightStyle(),
                ThemeEnum.Dark => new DarkStyle(),
                ThemeEnum.System => GetStyleBySystem(),
                _ => new LightStyle()
            };

            Application.Current.Resources = appStyle;
        }

        private ResourceDictionary GetStyleBySystem()
        {
            if (AppInfo.RequestedTheme == AppTheme.Dark)
                return new DarkStyle();

            return new LightStyle();
        }
    }
}
