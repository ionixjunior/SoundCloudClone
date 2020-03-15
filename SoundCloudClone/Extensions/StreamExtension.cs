using System.Collections.Generic;
using SoundCloudClone.Models.App;

namespace SoundCloudClone.Extensions
{
    public static class StreamExtension
    {
        public static IList<Stream> ToStreamApp(this SoundCloudClone.Models.Api.Stream streamApi)
        {
            var streams = new List<Stream>();

            foreach (var collection in streamApi.Collection)
                streams.Add(new Stream(collection));

            return streams;
        }
    }
}
