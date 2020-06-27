namespace SoundCloudClone.Interfaces
{
    public interface IStorage
    {
        int Get(string name, int defaultValue);
        void Set(string name, int value);
    }
}
