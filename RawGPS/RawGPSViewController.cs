using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace RawGPS
{
	public partial class RawGPSViewController : UIViewController
	{
		CLLocationManager myLocManager = null;


		public RawGPSViewController () : base ("RawGPSViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			myLocManager = new CLLocationManager ();

			myLocManager.DesiredAccuracy = 10;

			myLocManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) => {
				LatLabel.Text = e.Locations [e.Locations.Length - 1].Coordinate.Latitude.ToString() + "degrees";
				LongLabel.Text = e.Locations [e.Locations.Length - 1].Coordinate.Longitude.ToString() + "degrees";
				SpeedLabel.Text = e.Locations [e.Locations.Length - 1].Speed.ToString() + "meters/sec";
			};
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

