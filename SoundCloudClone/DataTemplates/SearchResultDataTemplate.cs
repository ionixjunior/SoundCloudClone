using System;
using SoundCloudClone.Cells;
using SoundCloudClone.Models.App;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SoundCloudClone.DataTemplates
{
    public class SearchResultDataTemplate : DataTemplateSelector
    {
        private readonly DataTemplate _album;
        private readonly DataTemplate _people;
        private readonly DataTemplate _playlist;
        private readonly DataTemplate _track;

        public SearchResultDataTemplate()
        {
            _album = new DataTemplate(typeof(AlbumCell));
            _people = new DataTemplate(typeof(PeopleCell));
            _playlist = new DataTemplate(typeof(PlaylistCell));
            _track = new DataTemplate(typeof(TrackCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is SearchResult searchResult)
            {
                if (searchResult.Data is Playlist playlist)
                    return playlist.IsAlbum ? _album : _playlist;

                if (searchResult.Data is User)
                    return _people;

                if (searchResult.Data is Track)
                    return _track;
            }

            return new DataTemplate(typeof(ContentView));
        }
    }
}
