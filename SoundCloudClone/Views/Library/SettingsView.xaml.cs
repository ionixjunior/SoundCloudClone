using System;
using System.Collections.Generic;
using SoundCloudClone.Interfaces;
using SoundCloudClone.ViewModels.Library;
using Xamarin.Forms;

namespace SoundCloudClone.Views.Library
{
    public partial class SettingsView : ContentPage
    {
        public SettingsView()
        {
            InitializeComponent();

            var storage = DependencyService.Get<IStorage>();
            BindingContext = new SettingsViewModel(storage);
        }

        private async void OnThemeOptionTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ThemeView());
        }
    }
}
