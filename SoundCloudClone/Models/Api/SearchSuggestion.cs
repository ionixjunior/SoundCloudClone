using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoundCloudClone.Models.Api
{
    public class SearchSuggestionCollection
    {
        [JsonPropertyName("output")]
        public string Output { get; set; }
    }

    public class SearchSuggestion
    {
        [JsonPropertyName("collection")]
        public IList<SearchSuggestionCollection> Collection { get; set; }
    }
}
