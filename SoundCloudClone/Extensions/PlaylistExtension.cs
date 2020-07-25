using System.Collections.Generic;
using SoundCloudClone.Models.App;

namespace SoundCloudClone.Extensions
{
    public static class PlaylistExtension
    {
        public static Playlist ToPlaylistApp(this SoundCloudClone.Models.Api.Playlist playlistApi)
        {
            return new Playlist(playlistApi);
        }

        public static IList<Track> ToTracksApp(this IList<SoundCloudClone.Models.Api.Track> tracksApi)
        {
            var tracks = new List<Track>();

            foreach (var trackApi in tracksApi)
                tracks.Add(new Track(trackApi));

            return tracks;
        }
    }
}
