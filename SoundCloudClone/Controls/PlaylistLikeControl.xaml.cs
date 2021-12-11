using SoundCloudClone.Converters;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SoundCloudClone.Controls
{
    public partial class PlaylistLikeControl : FlexLayout
    {
        public static readonly BindableProperty TotalProperty = BindableProperty.Create(
            nameof(Total),
            typeof(int),
            typeof(PlaylistLikeControl),
            0,
            BindingMode.OneWay,
            propertyChanged: OnTotalChanged);

        public int Total
        {
            get => (int)GetValue(TotalProperty);
            set => SetValue(TotalProperty, value);
        }

        private static void OnTotalChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is PlaylistLikeControl control)
            {
                if (control.FindByName("TotalLabel") is Label totalLabel)
                {
                    var converter = new NumericalToMetricConverter();
                    totalLabel.Text = converter.Convert(newValue);
                }
            }
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(PlaylistLikeControl),
            Colors.Black,
            BindingMode.OneWay,
            propertyChanged: OnTextColorChanged);

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        private static void OnTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is PlaylistLikeControl control)
                if (control.FindByName("TotalLabel") is Label totalLabel)
                    totalLabel.TextColor = (Color)newValue;
        }

        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
            nameof(Source),
            typeof(ImageSource),
            typeof(IImageElement),
            default(ImageSource),
            propertyChanged: OnImageSourceChanged);

        public ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        private static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is PlaylistLikeControl control)
                if (control.FindByName("Icon") is Image icon)
                    icon.Source = (ImageSource)newValue;
        }

        public PlaylistLikeControl()
        {
            InitializeComponent();
        }
    }
}
