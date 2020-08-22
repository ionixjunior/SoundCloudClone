using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SoundCloudClone.Views
{
    public partial class OverlayPlaylistLikeTutorialView : ContentPage
    {
        private readonly Rectangle _likeContainerPosition;

        public OverlayPlaylistLikeTutorialView(Rectangle likeContainerPosition)
        {
            InitializeComponent();
            _likeContainerPosition = likeContainerPosition;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Container.WidthRequest = _likeContainerPosition.Width;
            Container.HeightRequest = _likeContainerPosition.Height;
            Container.TranslationX = _likeContainerPosition.X;
            Container.TranslationY = _likeContainerPosition.Y + GetTopHeightSpacing();
            Container.IsVisible = true;
        }

        private double GetTopHeightSpacing()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                const double navbarHeight = 46;
                return GetSafeAreaInsetTop() + navbarHeight;
            }

            return 0;
        }

        private double GetSafeAreaInsetTop()
        {
            return On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets().Top;
        }
    }
}
