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

        [JsonProperty("is_album")]
        public bool IsAlbum { get; set; }
    }
}
