using System;
using System.Collections.Generic;
using SoundCloudClone.Interfaces;
using Xamarin.Forms;

namespace SoundCloudClone.Views
{
    public partial class SearchView : ContentPage, ITabPageIcons
    {
        public SearchView()
        {
            InitializeComponent();
        }

        public string GetIcon()
        {
            return "search";
        }

        public string GetSelectedIcon()
        {
            return "search_selected";
        }
    }
}
