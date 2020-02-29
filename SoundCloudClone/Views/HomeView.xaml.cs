using System;
using System.Collections.Generic;
using SoundCloudClone.Interfaces;
using Xamarin.Forms;

namespace SoundCloudClone.Views
{
    public partial class HomeView : ContentPage, ITabPageIcons
    {
        public HomeView()
        {
            InitializeComponent();
        }

        public string GetIcon()
        {
            return "home";
        }

        public string GetSelectedIcon()
        {
            return "home_selected";
        }
    }
}
