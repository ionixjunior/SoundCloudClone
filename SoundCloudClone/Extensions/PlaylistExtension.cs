using SoundCloudClone.Models.App;

namespace SoundCloudClone.Extensions
{
    public static class PlaylistExtension
    {
        public static Playlist ToPlaylistApp(this SoundCloudClone.Models.Api.Playlist playlistApi)
        {
            return new Playlist(playlistApi);
        }
    }
}
