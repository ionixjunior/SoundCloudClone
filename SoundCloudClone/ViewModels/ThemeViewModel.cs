using System;
using System.Collections.Generic;
using MvvmHelpers;
using SoundCloudClone.Enums;
using SoundCloudClone.Interfaces;

namespace SoundCloudClone.ViewModels
{
    public class ThemeViewModel : BaseViewModel
    {
        public IList<ThemeEnum> Options { get; private set; }

        public ThemeViewModel(ITheme theme)
        {
            Options = theme.GetOptions();
        }
    }
}
