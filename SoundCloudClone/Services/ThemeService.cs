using System.Collections.Generic;
using SoundCloudClone.Enums;
using SoundCloudClone.Interfaces;

namespace SoundCloudClone.Services
{
    public class ThemeService : ITheme
    {
        public IList<ThemeEnum> GetOptions()
        {
            return new List<ThemeEnum>
            {
                ThemeEnum.Light,
                ThemeEnum.Dark
            };
        }
    }
}
