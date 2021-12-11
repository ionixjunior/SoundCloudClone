using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SoundCloudClone.Interfaces;
using SoundCloudClone.ViewModels;
using SoundCloudClone.Views.Playlist;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SoundCloudClone.Views
{
    public partial class HomeView : ContentPage, ITabPageIcons
    {
        public HomeView()
        {
            InitializeComponent();

            var api = DependencyService.Get<IApi>();
            BindingContext = new HomeViewModel(api);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await OnAppearingAsync();
        }

        private async Task OnAppearingAsync()
        {
            if (BindingContext is IInitialize viewModel)
                await viewModel.InitializeAsync();
        }

        public string GetIcon()
        {
            return "home";
        }

        public string GetSelectedIcon()
        {
            return "home_selected";
        }

        private async void OnPlaylistTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlaylistDetailView());
        }
    }
}
