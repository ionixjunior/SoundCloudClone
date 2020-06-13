using System;
using System.Collections.Generic;

using Xamarin.Forms;

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
