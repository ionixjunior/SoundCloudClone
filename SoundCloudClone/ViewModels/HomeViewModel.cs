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

        public ObservableRangeCollection<AlbumGroup> AlbumGroups { get; private set; }

        public HomeViewModel(IApi api)
        {
            _api = api;
            AlbumGroups = new ObservableRangeCollection<AlbumGroup>();
        }

        public async Task InitializeAsync()
        {
            if (_alreadyInitialized)
                return;

            try
            {
                var home = await _api.GetAlbums();
                var albumGroups = home.ToAlbumGroups();

                AlbumGroups.AddRange(albumGroups);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            _alreadyInitialized = true;
        }
    }
}
