using System;
using SoundCloudClone.Interfaces;

namespace SoundCloudClone.ViewModels
{
    public class StreamViewModel
    {
        private readonly IApi _api;

        public StreamViewModel(IApi api)
        {
            _api = api;
        }
    }
}
