using System;
using System.Collections.Generic;
using SoundCloudClone.Models.App;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SoundCloudClone.Cells
{
    public partial class AlbumCell : ContentView
    {
        public AlbumCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is SearchResult searchResult && searchResult.Data is Playlist playlist && playlist.IsAlbum)
            {
                ArtworkUrlImage.Source = playlist.ArtworkUrl;
                UsernameLabel.Text = playlist.Username;
                TrackCountLabel.Text = $"{playlist.TrackCount} tracks";
                TitleLabel.Text = playlist.Title;
                //DescriptionLabel.Text = playlist.Description;
                LikesCountLabel.Text = playlist.LikesCount.ToString();
            }
        }
    }
}
