using SoundCloudClone.Converters;
using Xamarin.Forms;

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

        public PlaylistLikeControl()
        {
            InitializeComponent();
        }
    }
}
