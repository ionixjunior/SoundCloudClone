using System.Collections.Generic;
using SoundCloudClone.Models.App;

namespace SoundCloudClone.Extensions
{
    public static class SearchResultExtension
    {
        public static IList<SearchResult> ToSearchResultListApp(this Models.Api.SearchResult searchResultApi)
        {
            var searchResults = new List<SearchResult>();

            foreach (var collectionSearchResultApi in searchResultApi.Collection)
            {
                if (collectionSearchResultApi.Playlist is { })
                {
                    searchResults.Add(new SearchResult(collectionSearchResultApi.Playlist.ToPlaylistApp()));
                    continue;
                }

                if (collectionSearchResultApi.Track is { })
                {
                    searchResults.Add(new SearchResult(collectionSearchResultApi.Track.ToTrackApp()));
                    continue;
                }

                if (collectionSearchResultApi.User is { })
                {
                    searchResults.Add(new SearchResult(collectionSearchResultApi.User.ToUserApp()));
                    continue;
                }
            }

            return searchResults;
        }

        private static Playlist ToPlaylistApp(this Models.Api.Playlist playlistApi)
        {
            return new Playlist(playlistApi);
        }

        private static Track ToTrackApp(this Models.Api.Track trackApi)
        {
            return new Track(trackApi);
        }

        private static User ToUserApp(this Models.Api.User userApi)
        {
            return new User(userApi);
        }
    }
}
