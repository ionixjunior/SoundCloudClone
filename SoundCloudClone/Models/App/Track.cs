namespace SoundCloudClone.Models.App
{
    public class Track
    {
        public long FullDuration { get; set; }
        public string Title { get; set; }
        public int PlaybackCount { get; set; }
        public string Username { get; set; }
        public string ArtworkUrlTemplate { get; set; }
    }
}
