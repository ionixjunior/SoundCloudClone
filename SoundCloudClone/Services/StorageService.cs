using SoundCloudClone.Interfaces;
using Microsoft.Maui.Essentials;

namespace SoundCloudClone.Services
{
    public class StorageService : IStorage
    {
        public int Get(string name, int defaultValue)
        {
            return Preferences.Get(name, defaultValue);
        }

        public void Set(string name, int value)
        {
            Preferences.Set(name, value);
        }
    }
}
