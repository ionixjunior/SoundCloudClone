using System;
using System.Reactive.Linq;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Extensions;
using System.Threading.Tasks;

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
                .Subscribe(async (x) => await OnSearchTextChangedAsync(x));
        }

        private async Task OnSearchTextChangedAsync(string text)
        {
            try
            {
                var suggestionsApi = await _api.GetSearchSuggestions();
                var suggestionsApp = suggestionsApi.ToSearchSuggestionApp();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }

        public void SearchBy(string text) => SearchTextChanged.Invoke(this, text);
    }
}
