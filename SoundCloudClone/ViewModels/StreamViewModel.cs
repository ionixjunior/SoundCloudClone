using System;
using System.Threading.Tasks;
using SoundCloudClone.Interfaces;

namespace SoundCloudClone.ViewModels
{
    public class StreamViewModel : IInitialize
    {
        private readonly IApi _api;
        private bool _alreadyInitialized = false;

        public StreamViewModel(IApi api)
        {
            _api = api;
        }

        public async Task InitializeAsync()
        {
            if (_alreadyInitialized)
                return;

            // TODO CARREGAR AS INFORMAÇÕES

            _alreadyInitialized = true;
        }
    }
}
