using Xamarin.Forms;

namespace SoundCloudClone.Controls
{
    public partial class ItemView : FlexLayout
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(ItemView),
            string.Empty
        );

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public ItemView()
        {
            InitializeComponent();
        }
    }
}
