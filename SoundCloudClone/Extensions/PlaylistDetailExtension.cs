using System.Collections.Generic;
using SoundCloudClone.Models.App;

namespace SoundCloudClone.Extensions
{
    public static class PlaylistDetailExtension
    {
        public static Playlist ToPlaylistApp(this SoundCloudClone.Models.Api.PlaylistDetail playlistDetailApi)
        {
            return new Playlist(playlistDetailApi.Playlist);
        }

        public static IList<Track> ToTracksApp(this SoundCloudClone.Models.Api.PlaylistDetail playlistDetailApi)
        {
            var tracks = new List<Track>();

            foreach (var trackApi in playlistDetailApi.Tracks.Collection)
            {
                tracks.Add(
                    new Track(
                        trackApi.FullDuration,
                        trackApi.Title,
                        trackApi.Embedded.Stats.PlaybackCount,
                        trackApi.Embedded.User.Username,
                        trackApi.ArtworkUrlTemplate
                    )
                );
            }

            return tracks;
        }
    }
}
