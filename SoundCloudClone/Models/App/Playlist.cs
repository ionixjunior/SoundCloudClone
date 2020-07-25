namespace SoundCloudClone.Models.App
{
    public class Playlist
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public int TrackCount { get; set; }
        public long Duration { get; set; }
        public int LikesCount { get; set; }
        public string Username { get; set; }
        public string ArtworkUrlTemplate { get; set; }
    }
}
