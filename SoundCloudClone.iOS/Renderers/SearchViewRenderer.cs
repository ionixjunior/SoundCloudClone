using System;
using SoundCloudClone.iOS.Renderers;
using SoundCloudClone.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchView), typeof(SearchViewRenderer))]
namespace SoundCloudClone.iOS.Renderers
{
    public class SearchViewRenderer : PageRenderer
    {
        private UISearchController _searchController;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _searchController = new UISearchController();
        }

        public override void WillMoveToParentViewController(UIViewController parent)
        {
            base.WillMoveToParentViewController(parent);

            parent.NavigationItem.SearchController = _searchController;
            parent.NavigationItem.HidesSearchBarWhenScrolling = false;
        }
    }
}
