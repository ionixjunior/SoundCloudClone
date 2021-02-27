using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SoundCloudClone.Models.Api
{
    public class Track
    {
        [JsonPropertyName("full_duration")]
        public long FullDuration { get; set; }

        [JsonPropertyName("created_at"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("_embedded")]
        public Embedded Embedded { get; set; }

        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("artwork_url_template")]
        public string ArtworkUrlTemplate { get; set; }

        [JsonPropertyName("display_stats")]
        public bool DisplayStats { get; set; }
    }

    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), "yyyy/MM/dd HH:mm:ss K", CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
