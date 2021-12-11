using System;
using SoundCloudClone.Interfaces;
using SoundCloudClone.ViewModels.Library;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is SettingsViewModel viewModel)
                viewModel.LoadSelectedTheme();
        }

        private async void OnThemeOptionTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ThemeView());
        }
    }
}
