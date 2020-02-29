using System;
using System.Linq;
using System.Threading.Tasks;
using SoundCloudClone.Interfaces;
using SoundCloudClone.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
namespace SoundCloudClone.iOS.Renderers
{
    public class CustomTabbedPageRenderer : TabbedRenderer
    {
        protected override async Task<Tuple<UIImage, UIImage>> GetIcon(Page page)
        {
            if (page?.Navigation?.NavigationStack?.FirstOrDefault() is ITabPageIcons tabPage)
                return await Task.FromResult(
                    new Tuple<UIImage, UIImage>(
                        GetImageFromFile(tabPage.GetIcon()),
                        GetImageFromFile(tabPage.GetSelectedIcon())
                    )
                );

            return await base.GetIcon(page);
        }

        private UIImage GetImageFromFile(string fileName)
        {
            return UIImage
                .FromFile(fileName)
                .ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
        }
    }
}
