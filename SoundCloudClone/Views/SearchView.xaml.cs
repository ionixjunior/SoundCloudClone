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

        public void SearchBy(string text)
        {
            System.Diagnostics.Debug.WriteLine($"Vai procurar por {text}");
        }

        private void OnTextChanged(object sender, TextChangedEventArgs args) => SearchBy(args.NewTextValue);
    }
}
