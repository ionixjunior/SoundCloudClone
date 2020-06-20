using System.Collections.Generic;
using SoundCloudClone.Models.App;

namespace SoundCloudClone.Interfaces
{
    public interface ITheme
    {
        IList<Theme> GetOptions();
    }
}
