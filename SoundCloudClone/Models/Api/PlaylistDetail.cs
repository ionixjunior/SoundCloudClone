using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoundCloudClone.Models.Api
{
    public class PlaylistEmbeddedStats
    {
        [JsonProperty("likes_count")]
        public int LikesCount { get; set; }
    }

    public class PlaylistEmbedded
    {
        [JsonProperty("stats")]
        public PlaylistEmbeddedStats Stats { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

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
        public PlaylistEmbedded Embedded { get; set; }

        [JsonProperty("artwork_url_template")]
        public string ArtworkUrlTemplate { get; set; }
    }

    public class CollectionTrackEmbeddedStats
    {
        [JsonProperty("playback_count")]
        public int PlaybackCount { get; set; }
    }

    public class CollectionTrackEmbeddedUser
    {
        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public class CollectionTrackEmbedded
    {
        [JsonProperty("stats")]
        public CollectionTrackEmbeddedStats Stats { get; set; }

        [JsonProperty("user")]
        public CollectionTrackEmbeddedUser User { get; set; }
    }

    public class CollectionTrack
    {
        [JsonProperty("full_duration")]
        public long FullDuration { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("_embedded")]
        public CollectionTrackEmbedded Embedded { get; set; }

        [JsonProperty("artwork_url_template")]
        public string ArtworkUrlTemplate { get; set; }
    }

    public class Tracks
    {
        [JsonProperty("collection")]
        public IList<CollectionTrack> Collection { get; set; }
    }

    public class PlaylistDetail
    {
        [JsonProperty("playlist")]
        public Playlist Playlist { get; set; }

        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }
    }
}
