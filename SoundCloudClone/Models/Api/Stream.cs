using System;
using System.Collections.Generic;
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

    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }

    public class Embedded
    {
        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class Track
    {
        [JsonProperty("full_duration")]
        public int FullDuration { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

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
