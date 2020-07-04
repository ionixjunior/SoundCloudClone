using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SoundCloudClone.Views;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Services;
using SoundCloudClone.Enums;

namespace SoundCloudClone
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            RegisterDependencies();
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
            var storage = DependencyService.Get<IStorage>();
            var themeValue = storage.Get(Constants.SelectedThemeKey, (int)ThemeEnum.NonSelected);

            var themeEnum = (ThemeEnum)themeValue;
            var theme = DependencyService.Get<ITheme>();
            theme.Change(themeEnum);
        }

        protected override void OnStart()
        {
            ChangeTheme();
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
