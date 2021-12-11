using System;
using System.Collections.Generic;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Models.App;
using SoundCloudClone.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SoundCloudClone.Views
{
    public partial class SearchView : ContentPage, ITabPageIcons
    {
        public SearchView()
        {
            InitializeComponent();

            var api = DependencyService.Get<IApi>();
            BindingContext = new SearchViewModel(api);
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
            if (BindingContext is SearchViewModel viewModel)
                viewModel.SearchBy(text);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs args) => SearchBy(args.NewTextValue);

        private async void OnItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem is SearchSuggestion suggestion)
                if (BindingContext is SearchViewModel viewModel)
                    await viewModel.SelectSuggestionAsync(suggestion);
        }

        private void OnTextFocused(object _, FocusEventArgs __)
        {
            if (BindingContext is SearchViewModel viewModel)
                viewModel.ClearResults();
        }
    }
}
