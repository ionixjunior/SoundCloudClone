namespace SoundCloudClone.Models.App
{
    public class User
    {
        public string Username { get; }
        public string AvatarUrl { get; }
        public string AvatarUrlTemplate { get; }
        public int FollowersCount { get; }
        public string City { get; }
        public string Country { get; }

        public User(SoundCloudClone.Models.Api.User user)
        {
            Username = user.Username;
            AvatarUrl = user.AvatarUrl;
            AvatarUrlTemplate = user.AvatarUrlTemplate;
            FollowersCount = user.FollowersCount;
            City = user.City;
            Country = user.Country;
        }
    }
}
