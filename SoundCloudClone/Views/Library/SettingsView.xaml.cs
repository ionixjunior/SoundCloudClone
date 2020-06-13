using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SoundCloudClone.Views.Library
{
    public partial class SettingsView : ContentPage
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private async void OnThemeOptionTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ThemeView());
        }
    }
}
