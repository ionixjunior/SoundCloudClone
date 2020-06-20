using System;
using System.Collections.Generic;
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
            BindingContext = new ThemeViewModel();
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
