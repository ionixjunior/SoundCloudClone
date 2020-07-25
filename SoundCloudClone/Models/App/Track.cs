namespace SoundCloudClone.Models.App
{
    public class Track
    {
        public long FullDuration { get; }
        public string Title { get; }
        public int PlaybackCount { get; }
        public string Username { get; }
        public string ArtworkUrlTemplate { get; }

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
