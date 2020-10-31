using SoundCloudClone.Interfaces;
using SoundCloudClone.iOS.Renderers;
using System;
using System.Linq;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
namespace SoundCloudClone.iOS.Renderers
{
    public class CustomTabbedPageRenderer : TabbedRenderer
    {
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            int x = 0;
            foreach (var item in TabBar.Items)
            {
                item.ImageInsets = new UIEdgeInsets(6, 0, -6, 0);
                if (Element is TabbedPage tabs)
                {
                    var page = tabs.Children[x].Navigation.NavigationStack.First();
                    item.AccessibilityLabel = page.Title ?? "Untitled";
                }
                x++;
            }
        }

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
