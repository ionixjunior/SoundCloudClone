using System;
namespace SoundCloudClone.Models.App
{
    public class Stream
    {
        public long FullDuration { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public int PlaybackCount { get; set; }
        public int CommentsCount { get; set; }
        public int RepostsCount { get; set; }
        public int LikesCount { get; set; }
        public string Username { get; set; }
        public string AvatarUrl { get; set; }
        public string Genre { get; set; }
        public string ArtworkUrlTemplate { get; set; }
    }
}
