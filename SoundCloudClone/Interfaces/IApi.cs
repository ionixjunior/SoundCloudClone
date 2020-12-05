using System;
using System.Threading.Tasks;
using Refit;
using SoundCloudClone.Models.Api;

namespace SoundCloudClone.Interfaces
{
    public interface IApi
    {
        [Get("/home")]
        Task<Home> GetAlbums();

        [Get("/stream")]
        Task<Stream> GetStreams();

        [Get("/search_suggestion")]
        Task<SearchSuggestion> GetSearchSuggestions();

        [Get("/search")]
        Task<SearchResult> GetSearchResults();

        [Get("/playlist/id")]
        Task<PlaylistDetail> GetPlaylistDetail();
    }
}
