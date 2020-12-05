using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoundCloudClone.Models.Api
{
    public class Related
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class Links
    {
        [JsonProperty("related")]
        public Related Related { get; set; }
    }

    public class Format
    {
        [JsonProperty("protocol")]
        public string Protocol { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }
    }

    public class Transcoding
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("preset")]
        public string Preset { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("snipped")]
        public bool Snipped { get; set; }

        [JsonProperty("format")]
        public Format Format { get; set; }

        [JsonProperty("quality")]
        public string Quality { get; set; }
    }

    public class Media
    {
        [JsonProperty("transcodings")]
        public IList<Transcoding> Transcodings { get; set; }
    }

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
