using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoundCloudClone.Models.Api
{
    public class Album
    {
        [JsonPropertyName("artwork_url_template")]
        public string ArtworkUrlTemplate { get; set; }

        [JsonPropertyName("artwork_style")]
        public string ArtworkStyle { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("short_title")]
        public string ShortTitle { get; set; }

        [JsonPropertyName("short_subtitle")]
        public string ShortSubtitle { get; set; }
    }

    public class AlbumCollection
    {
        [JsonPropertyName("collection")]
        public IList<Album> Albums { get; set; }
    }

    public class AlgumGroup
    {
        [JsonPropertyName("style")]
        public string Style { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("selection_items")]
        public AlbumCollection AlbumCollection { get; set; }
    }

    public class AlbumGroupCollection
    {
        [JsonPropertyName("multiple_content_selection_card")]
        public AlgumGroup AlbumGroup { get; set; }
    }

    public class Home
    {
        [JsonPropertyName("collection")]
        public IList<AlbumGroupCollection> AlgumGroupsCollection { get; set; }
    }
}
