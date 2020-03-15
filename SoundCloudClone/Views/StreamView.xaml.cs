using System;
using System.Collections.Generic;
using SoundCloudClone.Interfaces;
using SoundCloudClone.ViewModels;
using Xamarin.Forms;

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
