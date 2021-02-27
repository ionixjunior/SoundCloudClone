using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoundCloudClone.Models.Api
{
    public class Tracks
    {
        [JsonPropertyName("collection")]
        public IList<Track> Collection { get; set; }
    }

    public class PlaylistDetail
    {
        [JsonPropertyName("playlist")]
        public Playlist Playlist { get; set; }

        [JsonPropertyName("tracks")]
        public Tracks Tracks { get; set; }
    }
}
