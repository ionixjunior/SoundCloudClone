using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoundCloudClone.Models
{
    public class Album
    {
        [JsonProperty("artwork_url_template")]
        public string ArtworkUrlTemplate { get; set; }

        [JsonProperty("artwork_style")]
        public string ArtworkStyle { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("short_title")]
        public string ShortTitle { get; set; }

        [JsonProperty("short_subtitle")]
        public string ShortSubtitle { get; set; }
    }

    public class AlbumCollection
    {
        [JsonProperty("collection")]
        public IList<Album> Albums { get; set; }
    }

    public class AlgumGroup
    {
        [JsonProperty("style")]
        public string Style { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("selection_items")]
        public AlbumCollection AlbumCollection { get; set; }
    }

    public class AlbumGroupCollection
    {
        [JsonProperty("multiple_content_selection_card")]
        public AlgumGroup AlbumGroup { get; set; }
    }

    public class Home
    {
        [JsonProperty("collection")]
        public IList<AlbumGroupCollection> AlgumGroupsCollection { get; set; }
    }
}
