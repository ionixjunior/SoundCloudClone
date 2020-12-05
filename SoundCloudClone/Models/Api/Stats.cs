using Newtonsoft.Json;

namespace SoundCloudClone.Models.Api
{
    public class Stats
    {
        [JsonProperty("playback_count")]
        public int PlaybackCount { get; set; }

        [JsonProperty("comments_count")]
        public int CommentsCount { get; set; }

        [JsonProperty("reposts_count")]
        public int RepostsCount { get; set; }

        [JsonProperty("likes_count")]
        public int LikesCount { get; set; }
    }
}
