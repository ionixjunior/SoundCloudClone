using Humanizer;
using SoundCloudClone.Models.App;
using Xamarin.Forms;

namespace SoundCloudClone.Cells
{
    public partial class TrackCell : ContentView
    {
        public TrackCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is SearchResult searchResult && searchResult.Data is Track track)
            {
                ArtworkUrlImage.Source = track.ArtworkUrl;
                UsernameLabel.Text = track.Username;
                FullDurationTimeSpanLabel.Text = track.FullDurationTimeSpan.ToString(@"mm\:ss");
                TitleLabel.Text = track.Title;
                PlaybackCountLabel.Text = ConvertToNumeric(track.PlaybackCount);
            }
        }

        public string ConvertToNumeric(int value)
        {
            return value.ToMetric(decimals: 0);
        }
    }
}
