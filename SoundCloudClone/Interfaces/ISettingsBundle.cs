namespace SoundCloudClone.Interfaces
{
    public interface ISettingsBundle
    {
        bool GetBoolValue(string key);
        void SetBoolValue(bool value, string key);
    }
}
