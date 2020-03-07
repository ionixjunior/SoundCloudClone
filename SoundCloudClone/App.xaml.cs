using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SoundCloudClone.Views;
using SoundCloudClone.Interfaces;
using SoundCloudClone.Services;

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
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
