using System;
using System.Linq;
using System.Reactive.Linq;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Extensions;
using System.Threading.Tasks;
using MvvmHelpers;
using SoundCloudClone.Models.App;

namespace SoundCloudClone.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public event EventHandler<string> SearchTextChanged;
        public ObservableRangeCollection<SearchSuggestion> Suggestions { get; private set; }

        private readonly IApi _api;

        public SearchViewModel(IApi api)
        {
            _api = api;
            Suggestions = new ObservableRangeCollection<SearchSuggestion>();

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
            // TEMPORÁRIO
            if (text == string.Empty)
            {
                Suggestions.Clear();
                return;
            }

            if (Suggestions.Any())
                return;

            try
            {
                var suggestionsApi = await _api.GetSearchSuggestions();
                var suggestionsApp = suggestionsApi.ToSearchSuggestionApp();

                Suggestions.AddRange(suggestionsApp);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }

        public void SearchBy(string text) => SearchTextChanged.Invoke(this, text);
    }
}
