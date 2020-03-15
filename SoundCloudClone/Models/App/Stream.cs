using System;
namespace SoundCloudClone.Models.App
{
    public class Stream
    {
        private long FullDuration { get; set; }
        public DateTime CreatedAt { get; private set; }
        public string Title { get; private set; }
        public int PlaybackCount { get; private set; }
        public int CommentsCount { get; private set; }
        public int RepostsCount { get; private set; }
        public int LikesCount { get; private set; }
        public string Username { get; private set; }
        public string AvatarUrl { get; private set; }
        public string Genre { get; private set; }
        private string ArtworkUrlTemplate { get; set; }

        public string ArtworkUrl => ArtworkUrlTemplate?.Replace("{size}", "t250x250");
        public TimeSpan FullDurationTimeSpan => TimeSpan.FromMilliseconds(FullDuration);

        public Stream(SoundCloudClone.Models.Api.Collection collection)
        {
            var track = collection.TrackPost.Track;
            var stat = track.Embedded.Stats;
            var user = track.Embedded.User;

            FullDuration = track.FullDuration;
            CreatedAt = track.CreatedAt;
            Title = track.Title;
            PlaybackCount = stat.PlaybackCount;
            CommentsCount = stat.CommentsCount;
            RepostsCount = stat.RepostsCount;
            LikesCount = stat.LikesCount;
            Username = user.Username;
            AvatarUrl = user.AvatarUrl;
            Genre = track.Genre;
            ArtworkUrlTemplate = track.ArtworkUrlTemplate;
        }
    }
}
