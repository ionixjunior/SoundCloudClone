using System;
using System.Threading.Tasks;
using MvvmHelpers;
using SoundCloudClone.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Devices;

namespace SoundCloudClone.Views
{
    public partial class OverlayPlaylistLikeTutorialView : ContentPage
    {
        private readonly Microsoft.Maui.Graphics.Rect _likeContainerPosition;
        private readonly int _totalLikes;

        public OverlayPlaylistLikeTutorialView(Microsoft.Maui.Graphics.Rect likeContainerPosition, int totalLikes)
        {
            InitializeComponent();
            _likeContainerPosition = likeContainerPosition;
            _totalLikes = totalLikes;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(100);
            Build();
        }

        private void Build()
        {
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                BuildiOS();
                return;
            }

            if (DeviceInfo.Platform == DevicePlatform.Android)
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
                                    Rect = new Microsoft.Maui.Graphics.Rect(0, 0, Width, Height)
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
                        Stroke = new SolidColorBrush(Color.FromArgb("F4570B")),
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
                                TextColor = Colors.White,
                                FontSize = 28
                            },
                            new Label
                            {
                                HorizontalTextAlignment = TextAlignment.End,
                                Text = "Tap the heart to save it to your library.",
                                TextColor = Colors.White,
                                FontSize = 22
                            }
                        }
                    },
                    new BoxView { BackgroundColor = Colors.Transparent }
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
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                const double navbarHeight = 46;
                return GetSafeAreaInsetTop() + navbarHeight;
            }

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                const double navbarHeight = 66;
                return navbarHeight;
            }

            return 0;
        }

        private double GetSafeAreaInsetTop()
        {
            return On<Microsoft.Maui.Controls.PlatformConfiguration.iOS>().SafeAreaInsets().Top;
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
                Fill = new SolidColorBrush(Color.FromArgb("F4570B")),
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
                Fill = new SolidColorBrush(Color.FromArgb("F4570B")),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                TranslationX = translationXEllipse,
                TranslationY = _likeContainerPosition.Y + GetTopHeightSpacing() - ellipseRadius
            };

            var ellipseBackgroundWidth = Width;
            var ellipseBackground = new Ellipse
            {
                Scale = 0,
                Opacity = 0,
                WidthRequest = ellipseBackgroundWidth,
                HeightRequest = ellipseBackgroundWidth,
                Fill = new SolidColorBrush((Color)App.Current.Resources["ContentItemBackground"]),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                TranslationX = (Width / 2) - (ellipseBackgroundWidth / 2) + 20,
                TranslationY = (Height / 2) - (ellipseBackgroundWidth / 2) + 40
            };

            var mainLayer = new BoxView
            {
                WidthRequest = Width,
                Opacity = 0,
                HeightRequest = Height,
                BackgroundColor = Colors.Black
            };

            var stackLayoutDescription = new StackLayout
            {
                Opacity = 0,
                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(60, 0),
                TranslationY = (Height / 2),
                Children =
                {
                    new Label
                    {
                        Text = "Like this playlist?",
                        TextColor = (Color)App.Current.Resources["TextPrimaryColor"],
                        FontSize = 28
                    },
                    new Label
                    {
                        Text = "Tap the heart to save it to your library.",
                        TextColor = (Color)App.Current.Resources["TextSecondaryColor"],
                        FontSize = 22
                    }
                }
            };

            var playlistLikeControl = new PlaylistLikeControl
            {
                Total = _totalLikes,
                TextColor = (Color)App.Current.Resources["PlaylistControlTextColor"],
                Source = (FileImageSource)App.Current.Resources["playlist_control_source"],
                Opacity = 0,
                TranslationX = heartEllipse.TranslationX,
                TranslationY = heartEllipse.TranslationY,
                HorizontalOptions = heartEllipse.HorizontalOptions,
                VerticalOptions = heartEllipse.VerticalOptions,
                WidthRequest = heartEllipse.WidthRequest,
                HeightRequest = heartEllipse.HeightRequest
            };

            var grid = new Grid
            {
                Children =
                {
                    mainLayer,
                    ellipseBackground,
                    stackLayoutDescription,
                    heartEllipse,
                    pulseEllipse,
                    playlistLikeControl,
                    new BoxView { BackgroundColor = Colors.Transparent }
                }
            };

            var tap = new TapGestureRecognizer();
            tap.Tapped += async (object sender, System.EventArgs e) =>
            {
                this.AbortAnimation(ParentAnimationName);
                pulseEllipse.IsVisible = false;
                heartEllipse.Scale = 1;
                heartEllipse.Opacity = 1;

                await Task.WhenAll(
                    ellipseBackground.ScaleTo(0, 300),
                    ellipseBackground.FadeTo(0, 300),
                    stackLayoutDescription.FadeTo(0, 300, Easing.CubicOut),
                    heartEllipse.ScaleTo(0, 300),
                    heartEllipse.FadeTo(0, 300),
                    playlistLikeControl.FadeTo(0, 300)
                );

                await mainLayer.FadeTo(0, 100, easing: Easing.CubicInOut);

                await Navigation.PopModalAsync(false);
            };
            grid.GestureRecognizers.Add(tap);

            Content = grid;

            Task.WhenAny(
                StartAndroidAnimationAsync(
                    mainLayer,
                    ellipseBackground,
                    heartEllipse,
                    pulseEllipse,
                    stackLayoutDescription,
                    playlistLikeControl
                )
            ).SafeFireAndForget(AnimationException);
        }

        private void AnimationException(Exception exception)
        {
            System.Diagnostics.Debug.WriteLine(exception.Message);
        }

        private Animation _parentAnimation;
        private const string ParentAnimationName = "ParentAnimation";

        private async Task StartAndroidAnimationAsync(
            View mainLayer, View ellipseBackground, View heartEllipse,
            View pulseEllipse, View stackLayoutDescription, View playlistLikeControl)
        {
            await mainLayer.FadeTo(0.4, 500, easing: Easing.CubicInOut);

            await Task.WhenAll(
                ellipseBackground.ScaleTo(1.4, 100),
                ellipseBackground.FadeTo(0.97, 100),
                stackLayoutDescription.FadeTo(1, 100, Easing.CubicIn),
                heartEllipse.ScaleTo(1, 100),
                heartEllipse.FadeTo(1, 100),
                playlistLikeControl.FadeTo(1, 100)
            );

            pulseEllipse.IsVisible = true;

            _parentAnimation = new Animation();
            var heartEllipseStartAnimation = new Animation(x => heartEllipse.ScaleTo(x), 1, 1.1, Easing.CubicInOut, () => pulseEllipse.Scale = 1.1);
            var heartEllipseEndAnimation = new Animation(x => heartEllipse.ScaleTo(x), 1.1, 1, Easing.CubicInOut);
            var pulseEllipseScaleStartAnimation = new Animation(x => pulseEllipse.ScaleTo(x), 1.1, 2, Easing.CubicInOut);
            var pulseEllipseFadeStartAnimation = new Animation(x => pulseEllipse.FadeTo(x), 1, 0, Easing.CubicInOut);

            _parentAnimation.Add(0, 0.2, heartEllipseStartAnimation);
            _parentAnimation.Add(0.3, 1, heartEllipseEndAnimation);
            _parentAnimation.Add(0.3, 0.7, pulseEllipseScaleStartAnimation);
            _parentAnimation.Add(0.3, 0.7, pulseEllipseFadeStartAnimation);

            _parentAnimation.Commit(
                this,
                ParentAnimationName,
                100,
                1000,
                finished: (_, __) =>
                {
                    pulseEllipse.Scale = 1;
                    pulseEllipse.Opacity = 1;
                },
                repeat: () => true
            );
        }
    }
}
