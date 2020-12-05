using System;

namespace SoundCloudClone.Models.App
{
    public class SearchResult
    {
        public object Data { get; private set; }

        public SearchResult(Playlist playlist)
        {
            Data = playlist;
        }

        public SearchResult(Track track)
        {
            Data = track;
        }

        public SearchResult(User user)
        {
            Data = user;
        }
    }
}
