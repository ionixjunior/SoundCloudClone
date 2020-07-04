using System.Linq;
using System.Collections.Generic;
using MvvmHelpers;
using MvvmHelpers.Commands;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Models.App;
using SoundCloudClone.Enums;

namespace SoundCloudClone.ViewModels
{
    public class ThemeViewModel : BaseViewModel
    {
        private readonly ITheme _theme;
        private readonly IStorage _storage;

        public IList<Theme> Options { get; private set; }
        public Theme SelectedOption { get; set; }
        public Command OptionSelectedCommand { get; private set; }

        public ThemeViewModel(ITheme theme, IStorage storage)
        {
            _theme = theme;
            _storage = storage;

            Options = theme.GetOptions();
            OptionSelectedCommand = new Command(OptionSelected);
            SelectConfiguredOption(storage);
        }

        private void OptionSelected()
        {
            Options.FirstOrDefault(option => option.IsSelected)?.UnSelect();
            SelectedOption?.Select();
            _storage.Set(Constants.SelectedThemeKey, (int)SelectedOption.Name);
            _theme.Change(SelectedOption.Name);
        }

        private void SelectConfiguredOption(IStorage storage)
        {
            var themeValue = storage.Get(Constants.SelectedThemeKey, (int)ThemeEnum.NonSelected);
            var themeEnum = (ThemeEnum)themeValue;
            Options.FirstOrDefault(option => option.Name == themeEnum)?.Select();
        }
    }
}
