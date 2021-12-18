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

        private PlaylistApp _playlist;
        public PlaylistApp Playlist
        {
            get => _playlist;
            set
            {
                _playlist = value;
                OnPropertyChanged();
            }
        }

        private ObservableRangeCollection<Track> _tracks;
        public ObservableRangeCollection<Track> Tracks
        {
            get => _tracks;
            set => SetProperty(ref _tracks, value, nameof(Tracks));
        }
        
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

                //Tracks.Clear();
                //Tracks.AddRange(playlistDetailApi.ToTracksApp());
                Tracks = new ObservableRangeCollection<Track>(playlistDetailApi.ToTracksApp());
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }
    }
}
