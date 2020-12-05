using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoundCloudClone.Models.Api
{
    public class Playlist
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("track_count")]
        public int TrackCount { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }

        [JsonProperty("artwork_url_template")]
        public string ArtworkUrlTemplate { get; set; }
    }

    public class Tracks
    {
        [JsonProperty("collection")]
        public IList<Track> Collection { get; set; }
    }

    public class PlaylistDetail
    {
        [JsonProperty("playlist")]
        public Playlist Playlist { get; set; }

        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }
    }
}
