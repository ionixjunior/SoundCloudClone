using System;
using System.Reactive.Linq;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Extensions;

namespace SoundCloudClone.ViewModels
{
    public class SearchViewModel
    {
        public event EventHandler<string> SearchTextChanged;

        private readonly IApi _api;

        public SearchViewModel(IApi api)
        {
            _api = api;

            Observable
                .FromEventPattern<string>(
                    x => SearchTextChanged += x,
                    x => SearchTextChanged -= x)
                .Throttle(TimeSpan.FromSeconds(1))
                .Select(x => x.EventArgs)
                .Subscribe(OnSearchTextChanged);
        }

        private async void OnSearchTextChanged(string text)
        {
            var suggestionsApi = await _api.GetSearchSuggestions();
            var suggestionsApp = suggestionsApi.ToSearchSuggestionApp();
        }

        public void SearchBy(string text) => SearchTextChanged.Invoke(this, text);
    }
}
