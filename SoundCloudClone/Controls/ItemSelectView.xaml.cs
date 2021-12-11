using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SoundCloudClone.Controls
{
    public partial class ItemSelectView : ItemBaseView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(ItemSelectView),
            string.Empty,
            propertyChanged: OnTextChanged
        );

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as ItemSelectView).TextLabel.Text = (string)newValue;
        }

        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
            nameof(IsSelected),
            typeof(bool),
            typeof(ItemSelectView),
            false,
            propertyChanged: OnIsSelectedChanged);

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        private static void OnIsSelectedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as ItemSelectView).SelectImage.IsVisible = (bool)newValue;
        }

        public ItemSelectView()
        {
            InitializeComponent();
        }
    }
}
