using System.Threading.Tasks;
using SoundCloudClone.Interfaces;
using SoundCloudClone.ViewModels.Playlist;
using Xamarin.Forms;

namespace SoundCloudClone.Views.Playlist
{
    public partial class PlaylistDetailView : ContentPage
    {
        private bool _dataAlreadyLoaded = false;

        public PlaylistDetailView()
        {
            InitializeComponent();

            var api = DependencyService.Get<IApi>();
            BindingContext = new PlaylistDetailViewModel(api);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await OnAppearingAsync();
        }

        private async Task OnAppearingAsync()
        {
            if (_dataAlreadyLoaded)
                return;

            if (BindingContext is IInitialize viewModel)
                await viewModel.InitializeAsync();

            _dataAlreadyLoaded = true;
        }
    }
}
