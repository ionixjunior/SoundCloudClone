using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoundCloudClone.Models.Api
{
    public class CollectionSearchResult
    {
        [JsonProperty("playlist")]
        public Playlist Playlist { get; set; }

        [JsonProperty("track")]
        public Track Track { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class SearchResult
    {
        [JsonProperty("collection")]
        public IList<CollectionSearchResult> Collection { get; set; }
    }
}
