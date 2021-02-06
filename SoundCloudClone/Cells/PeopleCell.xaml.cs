using System;
using System.Collections.Generic;
using SoundCloudClone.Models.App;
using Xamarin.Forms;

namespace SoundCloudClone.Cells
{
    public partial class PeopleCell : ContentView
    {
        public PeopleCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is SearchResult searchResult && searchResult.Data is User user)
            {
                AvatarUrlImage.Source = user.AvatarUrl;
                UsernameLabel.Text = user.Username;
                CityLabel.Text = user.City;
                FollowersCountLabel.Text = user.FollowersCount.ToString();
            }
        }
    }
}
