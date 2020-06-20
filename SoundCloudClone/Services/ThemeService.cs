using System.Collections.Generic;
using SoundCloudClone.Enums;

namespace SoundCloudClone.Services
{
    public class ThemeService
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
