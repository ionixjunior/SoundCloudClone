using System;
using System.Collections.Generic;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Styles;
using SoundCloudClone.ViewModels;
using Xamarin.Forms;

namespace SoundCloudClone.Views.Library
{
    public partial class ThemeView : ContentPage
    {
        public ThemeView()
        {
            InitializeComponent();

            var theme = DependencyService.Get<ITheme>();
            var storage = DependencyService.Get<IStorage>();
            BindingContext = new ThemeViewModel(theme, storage);
        }

        private void OnLightThemeTapped(object sender, EventArgs e)
        {
            Application.Current.Resources = new LightStyle();
        }

        private void OnDarkThemeTapped(object sender, EventArgs e)
        {
            Application.Current.Resources = new DarkStyle();
        }
    }
}
