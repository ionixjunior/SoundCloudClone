using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SoundCloudClone.Interfaces;
using SoundCloudClone.ViewModels;
using Xamarin.Forms;

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
    }
}
