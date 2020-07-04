using SoundCloudClone.Enums;
using SoundCloudClone.Interfaces;

namespace SoundCloudClone.ViewModels.Library
{
    public class SettingsViewModel
    {
        public ThemeEnum SelectedTheme { get; private set; }

        public SettingsViewModel(IStorage storage)
        {
            var themeValue = storage.Get(Constants.SelectedThemeKey, (int)ThemeEnum.NonSelected);
            SelectedTheme = (ThemeEnum)themeValue;
        }
    }
}
