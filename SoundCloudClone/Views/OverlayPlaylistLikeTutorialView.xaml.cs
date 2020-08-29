using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Shapes;

namespace SoundCloudClone.Views
{
    public partial class OverlayPlaylistLikeTutorialView : ContentPage
    {
        private readonly Xamarin.Forms.Rectangle _likeContainerPosition;

        public OverlayPlaylistLikeTutorialView(Xamarin.Forms.Rectangle likeContainerPosition)
        {
            InitializeComponent();
            _likeContainerPosition = likeContainerPosition;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Build();


            //Container.WidthRequest = _likeContainerPosition.Width;
            //Container.HeightRequest = _likeContainerPosition.Height;
            //Container.TranslationX = _likeContainerPosition.X;
            //Container.TranslationY = _likeContainerPosition.Y + GetTopHeightSpacing();
            //Container.IsVisible = true;


            //RectangleOverlay.SetValue(Xamarin.Forms.Shapes.RectangleGeometry.RectProperty, new Rect(0, 0, Width, Height))
        }

        private void Build()
        {
            var ellipseRadius = 60;

            var grid = new Grid
            {
                Children =
                {
                    new Path
                    {
                        Fill = Brush.Black,
                        Opacity = 0.8,
                        Data = new GeometryGroup
                        {
                            Children =
                            {
                                new RectangleGeometry
                                {
                                    Rect = new Rect(0, 0, Width, Height)
                                },
                                new EllipseGeometry
                                {
                                    RadiusX = ellipseRadius,
                                    RadiusY = ellipseRadius,
                                    Center = new Point(_likeContainerPosition.X, _likeContainerPosition.Y + GetTopHeightSpacing())
                                }
                            }
                        }
                    },
                    new Ellipse
                    {
                        Stroke = new SolidColorBrush(Color.FromHex("F4570B")),
                        WidthRequest = ellipseRadius * 2,
                        HeightRequest = ellipseRadius * 2,
                        StrokeThickness = 5,
                        TranslationX = _likeContainerPosition.X - ellipseRadius,
                        TranslationY = _likeContainerPosition.Y + GetTopHeightSpacing() - ellipseRadius,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Start
                    }
                }
            };


            Content = grid;
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
