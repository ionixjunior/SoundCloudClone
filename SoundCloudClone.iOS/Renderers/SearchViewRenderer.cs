using System;
using SoundCloudClone.iOS.Renderers;
using SoundCloudClone.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchView), typeof(SearchViewRenderer))]
namespace SoundCloudClone.iOS.Renderers
{
    public class SearchViewRenderer : PageRenderer
    {
    }
}
