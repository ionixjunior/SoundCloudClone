using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoundCloudClone.Models.Api
{
    public class TrackPost
    {
        [JsonProperty("track")]
        public Track Track { get; set; }
    }

    public class Collection
    {
        [JsonProperty("track_post")]
        public TrackPost TrackPost { get; set; }
    }

    public class Stream
    {
        [JsonProperty("collection")]
        public IList<Collection> Collection { get; set; }
    }
}
