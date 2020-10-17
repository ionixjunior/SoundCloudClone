using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SoundCloudClone.Views;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Services;
using SoundCloudClone.Enums;
using FFImageLoading;
using FFImageLoading.Cache;
using System.Threading.Tasks;

namespace SoundCloudClone
{
    public partial class App : Application
    {
        private readonly IStorage _storage;
        private readonly ITheme _theme;

        public App()
        {
            Device.SetFlags(new[] { "Shapes_Experimental" });
            InitializeComponent();

            RegisterDependencies();

            _storage = DependencyService.Get<IStorage>();
            _theme = DependencyService.Get<ITheme>();

            MainPage = new MainPage();
        }

        private void RegisterDependencies()
        {
            DependencyService.Register<IApi, ApiService>();
            DependencyService.Register<ITheme, ThemeService>();
            DependencyService.Register<IStorage, StorageService>();
        }

        private void ChangeTheme()
        {
            var themeValue = _storage.Get(Constants.SelectedThemeKey, (int)ThemeEnum.NonSelected);
            var themeEnum = (ThemeEnum)themeValue;
            _theme.Change(themeEnum);
        }

        protected override async void OnStart()
        {
            ChangeTheme();
            await LoadSettingsAsync();
        }

        private async Task LoadSettingsAsync()
        {
            if (DependencyService.Get<ISettingsBundle>() is { } settingsBundleServide)
            {
                var cleanImageCache = settingsBundleServide.GetBoolValue("clean_image_cache_preference");

                if (cleanImageCache)
                {
                    settingsBundleServide.SetBoolValue(false, "clean_image_cache_preference");
                    await ImageService.Instance.InvalidateCacheAsync(CacheType.All);
                }
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            ChangeTheme();
        }
    }
}
