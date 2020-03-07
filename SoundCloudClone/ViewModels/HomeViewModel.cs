using System;
using System.Threading.Tasks;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Models.Api;

namespace SoundCloudClone.ViewModels
{
    public class HomeViewModel : IInitialize
    {
        private readonly IApi _api;
        private bool _alreadyInitialized = false;

        public Home Home { get; private set; }

        public HomeViewModel(IApi api)
        {
            _api = api;
        }

        public async Task InitializeAsync()
        {
            if (_alreadyInitialized)
                return;

            try
            {
                Home = await _api.GetAlbums();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            _alreadyInitialized = true;
        }
    }
}
