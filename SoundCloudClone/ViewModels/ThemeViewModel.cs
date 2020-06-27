using System.Linq;
using System.Collections.Generic;
using MvvmHelpers;
using MvvmHelpers.Commands;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Models.App;
using Xamarin.Essentials;
using SoundCloudClone.Enums;

namespace SoundCloudClone.ViewModels
{
    public class ThemeViewModel : BaseViewModel
    {
        public IList<Theme> Options { get; private set; }
        public Theme SelectedOption { get; set; }
        public Command OptionSelectedCommand { get; private set; }

        public ThemeViewModel(ITheme theme, IStorage storage)
        {
            Options = theme.GetOptions();
            OptionSelectedCommand = new Command(OptionSelected);
        }

        private void OptionSelected()
        {
            Options.FirstOrDefault(option => option.IsSelected)?.UnSelect();
            SelectedOption?.Select();
        }
    }
}
