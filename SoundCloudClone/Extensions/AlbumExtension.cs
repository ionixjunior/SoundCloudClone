using System;
using System.Collections.Generic;
using SoundCloudClone.Models.App;

namespace SoundCloudClone.Extensions
{
    public static class AlbumExtension
    {
        public static IList<AlbumGroup> ToAlbumGroups(this SoundCloudClone.Models.Api.Home home)
        {
            var albumGroups = new List<AlbumGroup>();

            foreach (var algumGroupsCollection in home.AlgumGroupsCollection)
            {
                var albumGroupApi = algumGroupsCollection.AlbumGroup;
                var albumGroupApp = new AlbumGroup(
                    albumGroupApi.Title,
                    albumGroupApi.Description
                );

                var albumCollection = new AlbumCollection();

                foreach (var albumsApi in algumGroupsCollection.AlbumGroup.AlbumCollection.Albums)
                {
                    albumCollection.Add(
                        new Album(
                            albumsApi.ArtworkUrlTemplate,
                            albumsApi.ArtworkStyle,
                            albumsApi.Count,
                            albumsApi.ShortTitle,
                            albumsApi.ShortSubtitle
                        )
                    );
                }

                albumGroupApp.Add(albumCollection);
                albumGroups.Add(albumGroupApp);
            }

            return albumGroups;
        }
    }
}
