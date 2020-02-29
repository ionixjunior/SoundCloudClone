using System;
using System.Collections.Generic;
using SoundCloudClone.Interfaces;
using Xamarin.Forms;

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
    }
}
