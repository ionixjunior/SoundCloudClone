using System.Text.Json.Serialization;

namespace SoundCloudClone.Models.Api
{
    public class Embedded
    {
        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}
