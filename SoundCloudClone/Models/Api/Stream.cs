using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoundCloudClone.Models.Api
{
    public class TrackPost
    {
        [JsonPropertyName("track")]
        public Track Track { get; set; }
    }

    public class Collection
    {
        [JsonPropertyName("track_post")]
        public TrackPost TrackPost { get; set; }
    }

    public class Stream
    {
        [JsonPropertyName("collection")]
        public IList<Collection> Collection { get; set; }
    }
}
