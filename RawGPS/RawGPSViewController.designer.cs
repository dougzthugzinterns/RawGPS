// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace RawGPS
{
	[Register ("RawGPSViewController")]
	partial class RawGPSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel DistLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LatLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LongLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel MagHeadLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel pointsLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel RecLatLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel RecLongLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel SpeedLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel TrueHeadLabel { get; set; }

		[Action ("recLoc:")]
		partial void recordDistanceAction (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (LatLabel != null) {
				LatLabel.Dispose ();
				LatLabel = null;
			}

			if (LongLabel != null) {
				LongLabel.Dispose ();
				LongLabel = null;
			}

			if (SpeedLabel != null) {
				SpeedLabel.Dispose ();
				SpeedLabel = null;
			}

			if (RecLatLabel != null) {
				RecLatLabel.Dispose ();
				RecLatLabel = null;
			}

			if (RecLongLabel != null) {
				RecLongLabel.Dispose ();
				RecLongLabel = null;
			}

			if (DistLabel != null) {
				DistLabel.Dispose ();
				DistLabel = null;
			}

			if (MagHeadLabel != null) {
				MagHeadLabel.Dispose ();
				MagHeadLabel = null;
			}

			if (TrueHeadLabel != null) {
				TrueHeadLabel.Dispose ();
				TrueHeadLabel = null;
			}

			if (pointsLabel != null) {
				pointsLabel.Dispose ();
				pointsLabel = null;
			}
		}
	}
}
