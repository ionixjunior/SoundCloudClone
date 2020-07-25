using System;
using System.Threading.Tasks;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Extensions;
using PlaylistApp = SoundCloudClone.Models.App.Playlist;
using SoundCloudClone.Models.App;
using MvvmHelpers;

namespace SoundCloudClone.ViewModels.Playlist
{
    public class PlaylistDetailViewModel : BaseViewModel, IInitialize
    {
        private readonly IApi _api;

        public PlaylistApp Playlist { get; private set; }
        public ObservableRangeCollection<Track> Tracks { get; private set; }
        
        public PlaylistDetailViewModel(IApi api)
        {
            _api = api;
            Tracks = new ObservableRangeCollection<Track>();
        }

        public async Task InitializeAsync()
        {
            try
            {
                var playlistDetailApi = await _api.GetPlaylistDetail();
                Playlist = playlistDetailApi.ToPlaylistApp();

                Tracks.Clear();
                Tracks.AddRange(playlistDetailApi.ToTracksApp());
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }
    }
}
