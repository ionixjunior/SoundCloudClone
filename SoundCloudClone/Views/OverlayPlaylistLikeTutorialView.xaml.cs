using System;
using System.Threading.Tasks;
using MvvmHelpers;
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
            if (Device.RuntimePlatform == Device.iOS)
            {
                BuildiOS();
                return;
            }

            if (Device.RuntimePlatform == Device.Android)
            {
                BuildAndroid();
                return;
            }
        }

        private void BuildiOS()
        {
            var ellipseRadius = 60;

            var grid = new Grid
            {
                Opacity = 0,
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
            tap.Tapped += async (object sender, System.EventArgs e) =>
            {
                await grid.FadeTo(0, 100);
                await Navigation.PopModalAsync(false);
            };
            grid.GestureRecognizers.Add(tap);

            Content = grid;

            grid.FadeTo(1);
        }

        private double GetTopHeightSpacing()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                const double navbarHeight = 46;
                return GetSafeAreaInsetTop() + navbarHeight;
            }

            if (Device.RuntimePlatform == Device.Android)
            {
                const double navbarHeight = 66;
                return navbarHeight;
            }

            return 0;
        }

        private double GetSafeAreaInsetTop()
        {
            return On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets().Top;
        }

        private void BuildAndroid()
        {
            var ellipseRadius = 60;
            var translationXEllipse = _likeContainerPosition.X - ellipseRadius + 10;

            var heartEllipse = new Ellipse
            {
                Scale = 0,
                Opacity = 0,
                WidthRequest = 100,
                HeightRequest = 100,
                Fill = new SolidColorBrush(Color.FromHex("F4570B")),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                TranslationX = translationXEllipse,
                TranslationY = _likeContainerPosition.Y + GetTopHeightSpacing() - ellipseRadius
            };

            var pulseEllipse = new Ellipse
            {
                IsVisible = false,
                Scale = 1,
                Opacity = 1,
                WidthRequest = 100,
                HeightRequest = 100,
                Fill = new SolidColorBrush(Color.FromHex("F4570B")),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                TranslationX = translationXEllipse,
                TranslationY = _likeContainerPosition.Y + GetTopHeightSpacing() - ellipseRadius
            };

            var grid = new Grid
            {
                Children =
                {
                    heartEllipse,
                    pulseEllipse,
                    new BoxView { BackgroundColor = Color.Transparent }
                }
            };

            var tap = new TapGestureRecognizer();
            tap.Tapped += async (object sender, System.EventArgs e) =>
            {
                _animationCanBeExecuted = false;
                await Navigation.PopModalAsync(false);
            };
            grid.GestureRecognizers.Add(tap);

            Content = grid;

            Task.WhenAny(StartAndroidAnimationAsync(heartEllipse, pulseEllipse)).SafeFireAndForget(AnimationException);
        }

        private void AnimationException(Exception exception)
        {
            System.Diagnostics.Debug.WriteLine(exception.Message);
        }

        private bool _animationCanBeExecuted = true;

        private async Task StartAndroidAnimationAsync(View heartEllipse, View pulseEllipse)
        {
            await Task.WhenAll(
                heartEllipse.ScaleTo(1, 100),
                heartEllipse.FadeTo(1, 100)
            );

            pulseEllipse.IsVisible = true;

            while (_animationCanBeExecuted)
            {
                await heartEllipse.ScaleTo(1.1, 600, Easing.CubicInOut);
                pulseEllipse.Scale = 1.1;

                await Task.WhenAll(
                    heartEllipse.ScaleTo(1.0, 600, Easing.CubicInOut),
                    pulseEllipse.ScaleTo(2, 600, Easing.CubicInOut),
                    pulseEllipse.FadeTo(0, 600, Easing.CubicInOut)
                );

                pulseEllipse.Scale = 1;
                pulseEllipse.Opacity = 1;
            }
        }
    }
}
