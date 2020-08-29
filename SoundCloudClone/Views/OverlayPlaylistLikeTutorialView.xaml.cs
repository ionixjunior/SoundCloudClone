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
                    },
                    new StackLayout
                    {
                        Padding = new Thickness(20, 0),
                        WidthRequest = _likeContainerPosition.X - ellipseRadius - 40,
                        HorizontalOptions = LayoutOptions.Start,
                        TranslationX = 0,
                        TranslationY = _likeContainerPosition.Y + GetTopHeightSpacing() - 15,
                        Children =
                        {
                            new Label
                            {
                                HorizontalTextAlignment = TextAlignment.End,
                                Text = "Like this playlist?",
                                TextColor = Color.White,
                                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label))
                            },
                            new Label
                            {
                                HorizontalTextAlignment = TextAlignment.End,
                                Text = "Tap the heart to save it to your library.",
                                TextColor = Color.White,
                                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                            }
                        }
                    },
                    new BoxView { BackgroundColor = Color.Transparent }
                }
            };

            var tap = new TapGestureRecognizer();
            tap.Tapped += async (object sender, System.EventArgs e) => await Navigation.PopModalAsync(false);
            grid.GestureRecognizers.Add(tap);

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
