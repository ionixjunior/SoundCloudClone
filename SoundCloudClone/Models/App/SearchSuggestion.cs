using SoundCloudClone.Models.Api;

namespace SoundCloudClone.Models.App
{
    public class SearchSuggestion
    {
        public string Description { get; private set; }

        public SearchSuggestion(SearchSuggestionCollection searchSuggestionApi)
        {
            Description = searchSuggestionApi.Output;
        }
    }
}
