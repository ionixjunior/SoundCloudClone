using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoundCloudClone.Models.Api
{
    public class SearchSuggestionCollection
    {
        [JsonProperty("output")]
        public string Output { get; set; }
    }

    public class SearchSuggestion
    {
        [JsonProperty("collection")]
        public IList<SearchSuggestionCollection> Collection { get; set; }
    }
}
