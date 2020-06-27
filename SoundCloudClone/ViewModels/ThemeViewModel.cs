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
        private readonly IStorage _storage;

        public IList<Theme> Options { get; private set; }
        public Theme SelectedOption { get; set; }
        public Command OptionSelectedCommand { get; private set; }

        public ThemeViewModel(ITheme theme, IStorage storage)
        {
            _storage = storage;

            Options = theme.GetOptions();
            OptionSelectedCommand = new Command(OptionSelected);

            var value = _storage.Get(Constants.SelectedThemeKey, (int)ThemeEnum.NonSelected);
        }

        private void OptionSelected()
        {
            Options.FirstOrDefault(option => option.IsSelected)?.UnSelect();
            SelectedOption?.Select();
            _storage.Set(Constants.SelectedThemeKey, (int)SelectedOption.Name);

        }
    }
}
