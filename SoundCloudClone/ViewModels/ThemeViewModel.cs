using System;
using MvvmHelpers;
using SoundCloudClone.Interfaces;

namespace SoundCloudClone.ViewModels
{
    public class ThemeViewModel : BaseViewModel
    {
        public ThemeViewModel(ITheme theme)
        {
            var options = theme.GetOptions();
        }
    }
}
