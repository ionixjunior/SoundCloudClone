using System;
using System.Threading.Tasks;
using Refit;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Models.Api;

namespace SoundCloudClone.Services
{
    public class ApiService : IApi
    {
        private readonly IApi _api;

        public ApiService()
        {
            _api = RestService.For<IApi>("https://soundcloudclone.getsandbox.com");
        }

        public async Task<Home> GetAlbums()
        {
            return await _api.GetAlbums();
        }

        public async Task<SearchSuggestion> GetSearchSuggestions()
        {
            return await _api.GetSearchSuggestions();
        }

        public async Task<Stream> GetStreams()
        {
            return await _api.GetStreams();
        }
    }
}
