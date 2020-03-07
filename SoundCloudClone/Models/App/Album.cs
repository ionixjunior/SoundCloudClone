using System;
using System.Collections.Generic;

namespace SoundCloudClone.Models.App
{
    public class Album
    {
        public string ArtworkUrlTemplate { get; private set; }
        public string ArtworkStyle { get; private set; }
        public int Count { get; private set; }
        public string ShortTitle { get; private set; }
        public string ShortSubtitle { get; private set; }

        public Album(
            string artworkUrlTemplate,
            string artworkStyle,
            int count,
            string shortTitle,
            string shortSubtitle)
        {
            ArtworkUrlTemplate = artworkUrlTemplate;
            ArtworkStyle = artworkStyle;
            Count = count;
            ShortTitle = shortTitle;
            ShortSubtitle = shortSubtitle;
        }
    }

    public class AlbumCollection
    {
        public List<Album> Albums { get; private set; }

        public AlbumCollection()
        {
            Albums = new List<Album>();
        }

        public void Add(Album album)
        {
            Albums.Add(album);
        }
    }

    public class AlbumGroup : List<AlbumCollection>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public AlbumGroup(
            string title,
            string description)
        {
            Title = title;
            Description = description;
        }
    }
}
