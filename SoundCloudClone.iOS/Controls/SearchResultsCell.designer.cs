// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SoundCloudClone.iOS.Controls
{
	[Register ("SearchResultsCell")]
	partial class SearchResultsCell
	{
		[Outlet]
		UIKit.UIImageView Icon { get; set; }

		[Outlet]
		UIKit.UILabel Name { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Name != null) {
				Name.Dispose ();
				Name = null;
			}

			if (Icon != null) {
				Icon.Dispose ();
				Icon = null;
			}
		}
	}
}
