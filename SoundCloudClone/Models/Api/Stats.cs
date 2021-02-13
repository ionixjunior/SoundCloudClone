using System.Text.Json.Serialization;

namespace SoundCloudClone.Models.Api
{
    public class Stats
    {
        [JsonPropertyName("playback_count")]
        public int PlaybackCount { get; set; }

        [JsonPropertyName("comments_count")]
        public int CommentsCount { get; set; }

        [JsonPropertyName("reposts_count")]
        public int RepostsCount { get; set; }

        [JsonPropertyName("likes_count")]
        public int LikesCount { get; set; }
    }
}
