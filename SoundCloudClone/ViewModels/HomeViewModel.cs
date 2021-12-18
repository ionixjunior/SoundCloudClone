using System;
using System.Threading.Tasks;
using MvvmHelpers;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Models.App;
using SoundCloudClone.Extensions;

namespace SoundCloudClone.ViewModels
{
    public class HomeViewModel : BaseViewModel, IInitialize
    {
        private readonly IApi _api;
        private bool _alreadyInitialized = false;

        private ObservableRangeCollection<AlbumGroup> _albumGroups;
        public ObservableRangeCollection<AlbumGroup> AlbumGroups
        {
            get => _albumGroups;
            set => SetProperty(ref _albumGroups, value, nameof(AlbumGroups));
        }

        public HomeViewModel(IApi api)
        {
            _api = api;
            AlbumGroups = new ObservableRangeCollection<AlbumGroup>();
            Title = "Home";
        }

        public async Task InitializeAsync()
        {
            if (_alreadyInitialized)
                return;

            try
            {
                var home = await _api.GetAlbums();
                var albumGroups = home.ToAlbumGroups();

                //AlbumGroups.AddRange(albumGroups);
                AlbumGroups = new ObservableRangeCollection<AlbumGroup>(albumGroups);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            _alreadyInitialized = true;
        }
    }
}
