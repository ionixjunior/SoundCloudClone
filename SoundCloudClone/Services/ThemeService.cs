using System;
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
        private Lazy<LightStyle> _lightStyle = new Lazy<LightStyle>();
        private Lazy<DarkStyle> _darkStyle = new Lazy<DarkStyle>();

        public IList<Theme> GetOptions()
        {
            var options = new List<Theme>();

            if (DeviceInfo.Platform == DevicePlatform.Android)
                options.Add(new Theme(ThemeEnum.BatterySaver, false));

            if (DeviceInfo.Platform == DevicePlatform.iOS)
                options.Add(new Theme(ThemeEnum.System, false));

            options.Add(new Theme(ThemeEnum.Light, false));
            options.Add(new Theme(ThemeEnum.Dark, false));

            return options;
        }

        public void Change(ThemeEnum theme)
        {
            var appStyle = theme switch
            {
                ThemeEnum.Light => _lightStyle.Value,
                ThemeEnum.Dark => _darkStyle.Value,
                ThemeEnum.System => GetStyleBySystem(),
                ThemeEnum.BatterySaver => GetStyleByBatterySaver(),
                _ => _lightStyle.Value
            };

            Application.Current.Resources = appStyle;
        }

        private ResourceDictionary GetStyleBySystem()
        {
            if (AppInfo.RequestedTheme == AppTheme.Dark)
                return _darkStyle.Value;

            return _lightStyle.Value;
        }

        private ResourceDictionary GetStyleByBatterySaver()
        {
            if (Battery.EnergySaverStatus == EnergySaverStatus.On)
                return _darkStyle.Value;

            return _lightStyle.Value;
        }
    }
}
