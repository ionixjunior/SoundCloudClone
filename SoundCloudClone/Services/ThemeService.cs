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
            switch (theme)
            {
                case ThemeEnum.Light:
                    ChangeByAppStyle(new LightStyle());
                    break;
                case ThemeEnum.Dark:
                    ChangeByAppStyle(new DarkStyle());
                    break;
                case ThemeEnum.System:
                    ChangeBySystem();
                    break;
            }
        }

        private void ChangeByAppStyle(ResourceDictionary style)
        {
            Application.Current.Resources = style;
        }

        private void ChangeBySystem()
        {
            var systemTheme = AppInfo.RequestedTheme;

            if (systemTheme == AppTheme.Light)
                ChangeByAppStyle(new LightStyle());

            if (systemTheme == AppTheme.Dark)
                ChangeByAppStyle(new DarkStyle());

            if (systemTheme == AppTheme.Unspecified)
                ChangeByAppStyle(new LightStyle());
        }

    }
}
