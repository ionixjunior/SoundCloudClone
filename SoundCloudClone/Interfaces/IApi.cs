using System;
using System.Threading.Tasks;
using SoundCloudClone.Models;

namespace SoundCloudClone.Interfaces
{
    public interface IApi
    {
        Task<Home> GetAlbums();
    }
}
