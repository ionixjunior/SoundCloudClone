using System;
using System.Linq;
using System.Reactive.Linq;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Extensions;
using System.Threading.Tasks;
using MvvmHelpers;
using SoundCloudClone.Models.App;
using System.Threading;
using System.Collections.Generic;

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
                .Select(async (texto) => await LoadSuggestions(texto))
                .Switch()
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(ShowSuggestions);
        }

        private async Task<IList<SearchSuggestion>> LoadSuggestions(string x)
        {
            try
            {
                var suggestionsApi = await _api.GetSearchSuggestions();
                return suggestionsApi.ToSearchSuggestionApp();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
                return new List<SearchSuggestion>();
            }
        }

        private void ShowSuggestions(IList<SearchSuggestion> suggestions)
        {
            Suggestions.Clear();
            Suggestions.AddRange(suggestions);
        }

        public void SearchBy(string text) => SearchTextChanged.Invoke(this, text);

        public void SelectSuggestionAsync(SearchSuggestion suggestion)
        {
            // TODO FAZER A BUSCA BASEADO NO ITEM SELECIONADO
            System.Diagnostics.Debug.WriteLine($"Item selecionado na viewmodel: {suggestion.Description}");
            Suggestions.Clear();
        }
    }
}
