using MvvmHelpers;
using SoundCloudClone.Enums;
using SoundCloudClone.Interfaces;

namespace SoundCloudClone.ViewModels.Library
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly IStorage _storage;

        private ThemeEnum _selectedTheme;
        public ThemeEnum SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                _selectedTheme = value;
                OnPropertyChanged(nameof(SelectedTheme));
            }
        }

        public SettingsViewModel(IStorage storage)
        {
            _storage = storage;
        }

        public void LoadSelectedTheme()
        {
            var themeValue = _storage.Get(Constants.SelectedThemeKey, (int)ThemeEnum.NonSelected);
            SelectedTheme = (ThemeEnum)themeValue;
        }
    }
}
