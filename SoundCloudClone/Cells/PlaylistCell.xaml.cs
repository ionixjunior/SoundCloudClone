using System;
using System.Collections.Generic;
using SoundCloudClone.Models.App;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SoundCloudClone.Cells
{
    public partial class PlaylistCell : ContentView
    {
        public PlaylistCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is SearchResult searchResult && searchResult.Data is Playlist playlist && playlist.IsAlbum == false)
            {
                ArtworkUrlImage.Source = playlist.ArtworkUrl;
                UsernameLabel.Text = playlist.Username;
                TrackCountLabel.Text = $"{playlist.TrackCount} tracks";
                TitleLabel.Text = playlist.Title;
                LikesCountLabel.Text = playlist.LikesCount.ToString();
            }
        }
    }
}
