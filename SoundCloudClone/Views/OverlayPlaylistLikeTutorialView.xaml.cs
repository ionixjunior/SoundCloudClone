using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SoundCloudClone.Views
{
    public partial class OverlayPlaylistLikeTutorialView : ContentPage
    {
        public OverlayPlaylistLikeTutorialView(Rectangle likeContainerPosition)
        {
            InitializeComponent();

            Container.WidthRequest = likeContainerPosition.Width;
            Container.HeightRequest = likeContainerPosition.Height;
            Container.TranslationX = likeContainerPosition.X;
            //Container.TranslationY = likeContainerPosition.Y + 90;
            Container.TranslationY = likeContainerPosition.Y + 65;
        }
    }
}
