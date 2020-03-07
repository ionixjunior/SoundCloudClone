using System;
using System.Threading.Tasks;
using SoundCloudClone.Interfaces;

namespace SoundCloudClone.ViewModels
{
    public class HomeViewModel : IInitialize
    {
        private readonly IApi _api;
        private bool _alreadyInitialized = false;

        public HomeViewModel(IApi api)
        {
            _api = api;
        }

        public async Task InitializeAsync()
        {
            if (_alreadyInitialized)
                return;

            System.Diagnostics.Debug.WriteLine("DEVE INICIALIZAR A VIEWMODEL");
            _alreadyInitialized = true;
        }
    }
}
