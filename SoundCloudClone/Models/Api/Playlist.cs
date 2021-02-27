using System.Text.Json.Serialization;

namespace SoundCloudClone.Models.Api
{
    public class Playlist
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("track_count")]
        public int TrackCount { get; set; }

        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        [JsonPropertyName("_embedded")]
        public Embedded Embedded { get; set; }

        [JsonPropertyName("artwork_url_template")]
        public string ArtworkUrlTemplate { get; set; }

        [JsonPropertyName("is_album")]
        public bool IsAlbum { get; set; }
    }
}
