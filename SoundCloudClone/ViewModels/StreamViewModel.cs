using System;
using System.Threading.Tasks;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Extensions;
using MvvmHelpers;
using SoundCloudClone.Models.App;

namespace SoundCloudClone.ViewModels
{
    public class StreamViewModel : BaseViewModel, IInitialize
    {
        private readonly IApi _api;
        private bool _alreadyInitialized = false;

        private ObservableRangeCollection<Stream> _streams;
        public ObservableRangeCollection<Stream> Streams
        {
            get => _streams;
            set => SetProperty(ref _streams, value, nameof(Streams));
        }

        public StreamViewModel(IApi api)
        {
            _api = api;

            Title = "Stream";
            Streams = new ObservableRangeCollection<Stream>();
        }

        public async Task InitializeAsync()
        {
            if (_alreadyInitialized)
                return;

            try
            {
                var streamApi = await _api.GetStreams();
                var streamApp = streamApi.ToStreamApp();

                //Streams.AddRange(streamApp);
                Streams = new ObservableRangeCollection<Stream>(streamApp);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            _alreadyInitialized = true;
        }
    }
}
