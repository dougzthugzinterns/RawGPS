using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using System.Collections.Generic;

namespace RawGPS
{
	public partial class RawGPSViewController : UIViewController
	{
		//CLLocationManager myLocManager = null;
		List<CLLocation> distancePoints = new List<CLLocation> ();

		public RawGPSViewController () : base ("RawGPSViewController", null)
		{
		}

		partial void recLoc (NSObject sender)
		{
			//gets current latitude of the user and changes the "Recorded Latitude Label" to include the current latitude.
			double lat = this.getCurrentLatitude ();
			RecLatLabel.Text = lat.ToString ();
			//gets current longitude of the user and changes the "Recorded Longitude Label" to include the current longitude.
			double lon = this.getCurrentLongitude ();
			RecLongLabel.Text = lon.ToString ();

			double dis = convertMetersToKilometers(this.CalculateDistanceTraveled (distancePoints));
			DistLabel.Text = " Distance Traveled: " + dis.ToString ("0.00000");
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		//just a sample application that updates labels when the location is updated.
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			/**
			myLocManager = new CLLocationManager ();
			myLocManager.DesiredAccuracy = 10;
			myLocManager.HeadingFilter = 20;
			myLocManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) => {
				LatLabel.Text = "Latitude: " + e.Locations [e.Locations.Length - 1].Coordinate.Latitude.ToString () + "degrees";
				LongLabel.Text = "Longitude: " + e.Locations [e.Locations.Length - 1].Coordinate.Longitude.ToString () + "degrees";
				SpeedLabel.Text = "Speed: " + this.convertToKilometersPerHour (e.Locations [e.Locations.Length - 1].Speed).ToString () + "Km/hour";
			};

			myLocManager.UpdatedHeading += (object sender, CLHeadingUpdatedEventArgs e) => {
				MagHeadLabel.Text = e.NewHeading.MagneticHeading.ToString () + "º";
				TrueHeadLabel.Text = e.NewHeading.TrueHeading.ToString () + "º";
				CLLocation test = new CLLocation (this.getCurrentLatitude (), this.getCurrentLongitude ());
				distancePoints.Add (test);
				pointsLabel.Text = distancePoints.Count.ToString ();
			};
			
			if (CLLocationManager.LocationServicesEnabled) {
				myLocManager.StartUpdatingLocation ();
			}
			if (CLLocationManager.HeadingAvailable) {
				myLocManager.StartUpdatingHeading ();
			}
			**/

			this.createDistancePoints ();
		}
		//Gets the Latitude of the user.
		public double getCurrentLatitude ()
		{
			CLLocationManager myLocMan = new CLLocationManager ();
			myLocMan.DesiredAccuracy = 10; //accuracy within ten meters.
			if (CLLocationManager.LocationServicesEnabled) {
				myLocMan.StartUpdatingLocation (); //starts updating the location.
			}
			double latitude = myLocMan.Location.Coordinate.Latitude;
			myLocMan.StopUpdatingLocation (); //stops updating the location.
			return latitude;
		}
		//Gets the Longitude of the user.
		public double getCurrentLongitude ()
		{
			CLLocationManager myLocMan = new CLLocationManager ();
			myLocMan.DesiredAccuracy = 10; //accuracy within ten meters.
			if (CLLocationManager.LocationServicesEnabled) {
				myLocMan.StartUpdatingLocation (); //starts updating the location.
			}
			myLocMan.StopUpdatingLocation (); //stops updating the location.
			double longitude = myLocMan.Location.Coordinate.Longitude;
			return longitude;
		}
		//Gets the Speed of the user in meters/sec.
		public double getMetersPerSecond ()
		{
			CLLocationManager myLocMan = new CLLocationManager ();
			myLocMan.DesiredAccuracy = 10; //accuracy within ten meters.
			if (CLLocationManager.LocationServicesEnabled) {
				myLocMan.StartUpdatingLocation (); //starts updating the location.
			}
			double speed = myLocMan.Location.Speed;
			myLocMan.StopUpdatingLocation ();
			return speed;
		}
		//Gets the Speed of the user in Km/hour.
		public double convertToKilometersPerHour (double metersPerSecond)
		{
			double kmHour = ((metersPerSecond / 1000.0) * 3600);
			return kmHour;
		}
		public double convertMetersToKilometers (double meters){
			return meters / 1000.0;
		}
		public void createDistancePoints ()
		{
			CLLocationManager myLocMan = new CLLocationManager ();
			myLocMan.DesiredAccuracy = 10;
			myLocMan.HeadingFilter = 30;
			CLLocation temp;

			if (CLLocationManager.LocationServicesEnabled) {
				myLocMan.StartUpdatingLocation ();
			}
			if (CLLocationManager.HeadingAvailable) {
				myLocMan.StartUpdatingHeading ();
			}

			myLocMan.UpdatedHeading += (object sender, CLHeadingUpdatedEventArgs e) => {
				MagHeadLabel.Text = e.NewHeading.MagneticHeading.ToString () + "º";
				TrueHeadLabel.Text = e.NewHeading.TrueHeading.ToString () + "º";
				temp = new CLLocation (this.getCurrentLatitude (), this.getCurrentLongitude ());
				distancePoints.Add (temp);
				pointsLabel.Text = distancePoints.Count.ToString ();
			};


			//myLocMan.StopUpdatingHeading ();
		}
		//Calculates the distance traveled.
		public double CalculateDistanceTraveled (List<CLLocation> locations)
		{
			double distance = 0;
			double temp = 0;
			for (int i = 0; i<locations.Count; i++) {
				if (i+1 < locations.Count) {
					temp = locations [i].DistanceFrom (locations [i + 1]);
					distance = distance + temp;
				}
			}
			return distance;
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

