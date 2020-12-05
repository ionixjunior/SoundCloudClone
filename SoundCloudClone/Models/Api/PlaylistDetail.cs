using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoundCloudClone.Models.Api
{
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
