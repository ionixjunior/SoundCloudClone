using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmHelpers;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Models.App;

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
                var albumGroups = new List<AlbumGroup>();

                foreach (var algumGroupsCollection in home.AlgumGroupsCollection)
                {
                    var albumGroupApi = algumGroupsCollection.AlbumGroup;
                    var albumGroupApp = new AlbumGroup(
                        albumGroupApi.Title,
                        albumGroupApi.Description
                    );

                    var albumCollection = new AlbumCollection();

                    foreach (var albumsApi in algumGroupsCollection.AlbumGroup.AlbumCollection.Albums)
                    {
                        albumCollection.Add(
                            new Album(
                                albumsApi.ArtworkUrlTemplate,
                                albumsApi.ArtworkStyle,
                                albumsApi.Count,
                                albumsApi.ShortTitle,
                                albumsApi.ShortSubtitle
                            )
                        );
                    }

                    albumGroupApp.Add(albumCollection);
                    albumGroups.Add(albumGroupApp);
                }

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
