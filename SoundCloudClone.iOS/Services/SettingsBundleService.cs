using Foundation;
using SoundCloudClone.Interfaces;

namespace SoundCloudClone.iOS.Services
{
    public class SettingsBundleService : ISettingsBundle
    {
        public bool GetBoolValue(string key)
        {
            return NSUserDefaults.StandardUserDefaults.BoolForKey(key);
        }

        public void SetBoolValue(bool value, string key)
        {
            NSUserDefaults.StandardUserDefaults.SetBool(value, key);
        }
    }
}
