using System;
using System.Collections.Generic;

using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SoundCloudClone.Views.Library
{
    public partial class MoreView : ContentPage
    {
        public MoreView()
        {
            InitializeComponent();
        }

        private async void OnSettingsTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsView());
        }
    }
}
