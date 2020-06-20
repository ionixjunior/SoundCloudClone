using SoundCloudClone.Enums;

namespace SoundCloudClone.Models.App
{
    public class Theme
    {
        public ThemeEnum Name { get; private set; }
        public bool IsSelected { get; private set; }

        public Theme(ThemeEnum name, bool isSelected)
        {
            Name = name;
            IsSelected = isSelected;
        }
    }
}
