using System;
using System.Collections.Generic;
using SoundCloudClone.Interfaces;
using Xamarin.Forms;

namespace SoundCloudClone.Views
{
    public partial class StreamView : ContentPage, ITabPageIcons
    {
        public StreamView()
        {
            InitializeComponent();
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
