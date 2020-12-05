using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoundCloudClone.Models.Api
{
    public class Track
    {
        [JsonProperty("full_duration")]
        public long FullDuration { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("artwork_url_template")]
        public string ArtworkUrlTemplate { get; set; }
    }

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
