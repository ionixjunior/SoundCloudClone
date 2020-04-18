using System;
using Foundation;
using SoundCloudClone.iOS.Renderers;
using SoundCloudClone.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchView), typeof(SearchViewRenderer))]
namespace SoundCloudClone.iOS.Renderers
{
    public class SearchViewRenderer : PageRenderer, IUISearchBarDelegate
    {
        private UISearchController _searchController;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var storyboard = UIStoryboard.FromName("SearchResults", null);
            var searchResultsController = storyboard.InstantiateInitialViewController();

            _searchController = new UISearchController(searchResultsController)
            {
                AutomaticallyShowsCancelButton = false
            };
            _searchController.SearchBar.Delegate = this;
        }

        public override void WillMoveToParentViewController(UIViewController parent)
        {
            base.WillMoveToParentViewController(parent);

            parent.NavigationItem.SearchController = _searchController;
            parent.NavigationItem.HidesSearchBarWhenScrolling = false;
        }

        [Export("searchBar:textDidChange:")]
        public void TextChanged(UISearchBar searchBar, string searchText)
        {
            if (Element is SearchView searchView)
                searchView.SearchBy(searchText);
        }
    }
}
