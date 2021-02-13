using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoundCloudClone.Models.Api
{
    public class CollectionSearchResult
    {
        [JsonPropertyName("playlist")]
        public Playlist Playlist { get; set; }

        [JsonPropertyName("track")]
        public Track Track { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }
    }

    public class SearchResult
    {
        [JsonPropertyName("collection")]
        public IList<CollectionSearchResult> Collection { get; set; }
    }
}
