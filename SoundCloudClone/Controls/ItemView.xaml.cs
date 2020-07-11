using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SoundCloudClone.Controls
{
    public partial class ItemView : FlexLayout
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(ItemView),
            string.Empty,
            propertyChanged: OnTextChanged
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

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as ItemView).TextLabel.Text = (string)newValue;
        }
    }
}
