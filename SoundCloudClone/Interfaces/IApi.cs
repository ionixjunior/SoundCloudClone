using System;
using System.Threading.Tasks;
using Refit;
using SoundCloudClone.Models.Api;

namespace SoundCloudClone.Interfaces
{
    public interface IApi
    {
        [Get("/home")]
        Task<Home> GetAlbums();
    }
}
