using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoundCloudClone.Models.Api
{
    public class StatsSearch
    {
        [JsonProperty("likes_count")]
        public int LikesCount { get; set; }

        [JsonProperty("reposts_count")]
        public int RepostsCount { get; set; }

        [JsonProperty("playback_count")]
        public int PlaybackCount { get; set; }
    }

    public class EmbeddedSearch
    {
        [JsonProperty("stats")]
        public StatsSearch Stats { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class PlaylistSearch
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("track_count")]
        public int TrackCount { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedSearch Embedded { get; set; }

        [JsonProperty("is_album")]
        public bool IsAlbum { get; set; }

        [JsonProperty("artwork_url_template")]
        public string ArtworkUrlTemplate { get; set; }
    }

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

    public class TrackSearch
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("full_duration")]
        public int FullDuration { get; set; }
        
        [JsonProperty("artwork_url_template")]
        public string ArtworkUrlTemplate { get; set; }

        [JsonProperty("display_stats")]
        public bool DisplayStats { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedSearch Embedded { get; set; }
    }

    public class CollectionSearchResult
    {
        [JsonProperty("playlist")]
        public PlaylistSearch Playlist { get; set; }

        [JsonProperty("track")]
        public TrackSearch Track { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class SearchResult
    {
        [JsonProperty("collection")]
        public IList<CollectionSearchResult> Collection { get; set; }
    }
}
