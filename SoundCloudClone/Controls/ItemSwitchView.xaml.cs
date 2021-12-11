using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SoundCloudClone.Controls
{
    public partial class ItemSwitchView : ItemBaseView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(ItemSwitchView),
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
            (bindable as ItemSwitchView).TextLabel.Text = (string)newValue;
        }

        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(
            nameof(IsToggled),
            typeof(bool),
            typeof(ItemSwitchView),
            false,
            propertyChanged: OnIsToggledChanged
        );

        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }

        private static void OnIsToggledChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as ItemSwitchView).ToggleSwitch.IsToggled = (bool)newValue;
        }

        public ItemSwitchView()
        {
            InitializeComponent();
        }
    }
}
