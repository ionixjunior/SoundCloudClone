using System;
using System.Collections.Generic;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Views.Library;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SoundCloudClone.Views
{
    public partial class LibraryView : ContentPage, ITabPageIcons
    {
        public LibraryView()
        {
            InitializeComponent();
        }

        public string GetIcon()
        {
            return "library";
        }

        public string GetSelectedIcon()
        {
            return "library_selected";
        }

        private async void OnProfileTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoreView());
        }
    }
}
