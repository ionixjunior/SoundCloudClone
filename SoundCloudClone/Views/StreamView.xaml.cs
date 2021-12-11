using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SoundCloudClone.Interfaces;
using SoundCloudClone.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SoundCloudClone.Views
{
    public partial class StreamView : ContentPage, ITabPageIcons
    {
        public StreamView()
        {
            InitializeComponent();

            var api = DependencyService.Get<IApi>();
            BindingContext = new StreamViewModel(api);
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
            return "stream";
        }

        public string GetSelectedIcon()
        {
            return "stream_selected";
        }
    }
}
