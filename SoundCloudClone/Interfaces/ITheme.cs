using System.Collections.Generic;
using SoundCloudClone.Enums;
using SoundCloudClone.Models.App;

namespace SoundCloudClone.Interfaces
{
    public interface ITheme
    {
        IList<Theme> GetOptions();
        void Change(ThemeEnum theme);
    }
}
