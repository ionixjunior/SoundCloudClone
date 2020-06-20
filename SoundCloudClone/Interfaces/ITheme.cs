using System.Collections.Generic;
using SoundCloudClone.Enums;

namespace SoundCloudClone.Interfaces
{
    public interface ITheme
    {
        IList<ThemeEnum> GetOptions();
    }
}
