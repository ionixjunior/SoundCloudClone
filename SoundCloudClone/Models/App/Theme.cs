using System.ComponentModel;
using System.Runtime.CompilerServices;
using SoundCloudClone.Enums;

namespace SoundCloudClone.Models.App
{
    public class Theme : INotifyPropertyChanged
    {
        public ThemeEnum Name { get; private set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            private set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public Theme(ThemeEnum name, bool isSelected)
        {
            Name = name;
            IsSelected = isSelected;
        }

        public void Select() => IsSelected = true;
        public void UnSelect() => IsSelected = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
