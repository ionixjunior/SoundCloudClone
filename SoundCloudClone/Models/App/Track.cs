using System;

namespace SoundCloudClone.Models.App
{
    public class Track
    {
        public long FullDuration { get; }
        public string Title { get; }
        public int PlaybackCount { get; }
        public string Username { get; }
        public string ArtworkUrlTemplate { get; }

        public string ArtworkUrl => ArtworkUrlTemplate?.Replace("{size}", "t50x50");
        public TimeSpan FullDurationTimeSpan => TimeSpan.FromMilliseconds(FullDuration);

        public Track() { }

        public Track(long fullDuration, string title, int playbackCount, string username, string artworkUrlTemplate)
        {
            FullDuration = fullDuration;
            Title = title;
            PlaybackCount = playbackCount;
            Username = username;
            ArtworkUrlTemplate = artworkUrlTemplate;
        }

        public Track(SoundCloudClone.Models.Api.Track trackApi)
        {
            FullDuration = trackApi.FullDuration;
            Title = trackApi.Title;
            PlaybackCount = trackApi.Embedded.Stats.PlaybackCount;
            Username = trackApi.Embedded.User.Username;
            ArtworkUrlTemplate = trackApi.ArtworkUrlTemplate;
        }
    }
}
