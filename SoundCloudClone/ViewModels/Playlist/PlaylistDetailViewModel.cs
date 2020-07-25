using System;
using System.Threading.Tasks;
using SoundCloudClone.Interfaces;

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
                var data = await _api.GetPlaylistDetail();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }
    }
}
