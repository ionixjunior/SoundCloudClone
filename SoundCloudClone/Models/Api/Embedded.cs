using Newtonsoft.Json;

namespace SoundCloudClone.Models.Api
{
    public class Embedded
    {
        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
