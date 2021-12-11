using System.Threading.Tasks;
using SoundCloudClone.Interfaces;
using SoundCloudClone.ViewModels.Playlist;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

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
            {
                await viewModel.InitializeAsync();
                var likeContainerPosition = GetLikeContainerPosition();
                await Navigation.PushModalAsync(new OverlayPlaylistLikeTutorialView(likeContainerPosition, LikeContainer.Total), false);
            }

            _dataAlreadyLoaded = true;

        }

        private Rectangle GetLikeContainerPosition()
        {
            var parent = LikeContainer.Parent;
            var likeY = LikeContainer.Bounds.Y;

            while (parent is View parentView)
            {
                likeY += parentView.Bounds.Y;
                parent = parentView.Parent;
            }

            return new Rectangle(
                LikeContainer.Bounds.X + (LikeContainer.Bounds.Width / 2),
                likeY + (LikeContainer.Bounds.Height / 2),
                LikeContainer.Bounds.Width,
                LikeContainer.Bounds.Height
            );
        }
    }
}
