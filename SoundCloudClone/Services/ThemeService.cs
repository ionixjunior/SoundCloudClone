using System;
using System.Collections.Generic;
using SoundCloudClone.Enums;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Models.App;
using SoundCloudClone.Styles;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

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

        private ResourceDictionary _lastAppStyleSelected;

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

            if (ThemeShouldChange(appStyle))
            {
                Application.Current.Resources = appStyle;
                _lastAppStyleSelected = appStyle;
            }
        }

        private bool ThemeShouldChange(ResourceDictionary appStyle)
        {
            if (_lastAppStyleSelected is null)
                return true;

            if (_lastAppStyleSelected != appStyle)
                return true;

            return false;
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
