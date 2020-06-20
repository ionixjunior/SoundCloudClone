using System;
using System.Collections.Generic;
using MvvmHelpers;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Models.App;

namespace SoundCloudClone.ViewModels
{
    public class ThemeViewModel : BaseViewModel
    {
        public IList<Theme> Options { get; private set; }

        public ThemeViewModel(ITheme theme)
        {
            Options = theme.GetOptions();
        }
    }
}
