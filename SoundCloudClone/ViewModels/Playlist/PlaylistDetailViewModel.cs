using System;
using System.Threading.Tasks;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Extensions;

namespace SoundCloudClone.ViewModels.Playlist
{
    public class PlaylistDetailViewModel : IInitialize
    {
        private readonly IApi _api;

        public PlaylistDetailViewModel(IApi api)
        {
            _api = api;
        }

        public async Task InitializeAsync()
        {
            try
            {
                var playlistDetailApi = await _api.GetPlaylistDetail();
                var playlist = playlistDetailApi.ToPlaylistApp();
                var tracks = playlistDetailApi.ToTracksApp();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }
    }
}
