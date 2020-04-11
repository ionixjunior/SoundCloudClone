using System.Collections.Generic;
using SoundCloudClone.Models.App;

namespace SoundCloudClone.Extensions
{
    public static class SearchSuggestionExtension
    {
        public static IList<SearchSuggestion> ToSearchSuggestionApp(this SoundCloudClone.Models.Api.SearchSuggestion searchSuggestionApi)
        {
            var suggestionsApp = new List<SearchSuggestion>();

            foreach (var suggestion in searchSuggestionApi.Collection)
                suggestionsApp.Add(new SearchSuggestion(suggestion));

            return suggestionsApp;
        }
    }
}
