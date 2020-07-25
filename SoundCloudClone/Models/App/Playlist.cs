namespace SoundCloudClone.Models.App
{
    public class Playlist
    {
        public string Description { get; }
        public string Title { get; }
        public int TrackCount { get; }
        public long Duration { get; }
        public int LikesCount { get; }
        public string Username { get; }
        public string ArtworkUrlTemplate { get; }

        public Playlist(SoundCloudClone.Models.Api.Playlist playlistApi)
        {
            Description = playlistApi.Description;
            Title = playlistApi.Title;
            TrackCount = playlistApi.TrackCount;
            Duration = playlistApi.Duration;
            LikesCount = playlistApi.Embedded.Stats.LikesCount;
            Username = playlistApi.Embedded.User.Username;
            ArtworkUrlTemplate = playlistApi.ArtworkUrlTemplate;
        }
    }
}
