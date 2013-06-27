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
		CLLocationManager myLocManager = null;
		List<CLLocation> distancePoints = new List<CLLocation>();

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

			double dis = this.CalculateDistanceTraveled(distancePoints);
			DistLabel.Text = " Distance Traveled: " + dis.ToString();
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
			myLocManager = new CLLocationManager ();
			myLocManager.DesiredAccuracy = 10;
			myLocManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) => {
				LatLabel.Text = "Latitude: " + e.Locations [e.Locations.Length - 1].Coordinate.Latitude.ToString () + "degrees";
				LongLabel.Text = "Longitude: " + e.Locations [e.Locations.Length - 1].Coordinate.Longitude.ToString () + "degrees";
				SpeedLabel.Text = "Speed: " + this.getKilometersPerHour (e.Locations [e.Locations.Length - 1].Speed).ToString () + "Km/hour";
			};
			myLocManager.UpdatedHeading += (object sender, CLHeadingUpdatedEventArgs e) => {
				MagHeadLabel.Text = e.NewHeading.MagneticHeading.ToString () + "º";
				TrueHeadLabel.Text = e.NewHeading.TrueHeading.ToString () + "º";
				pointsLabel.Text = distancePoints.Capacity.ToString();
			};
			if (CLLocationManager.LocationServicesEnabled) {
				myLocManager.StartUpdatingLocation ();
			}
			if(CLLocationManager.HeadingAvailable){
				myLocManager.StartUpdatingHeading ();
			}
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
		public double getKilometersPerHour (double metersPerSecond)
		{
			double kmHour = ((metersPerSecond / 1000) * 3600);
			return kmHour;
		}

		public List<CLLocation> createDistancePoints ()
		{
			CLLocationManager myLocMan = new CLLocationManager ();
			myLocMan.DesiredAccuracy = 10;
			CLLocation temp;
			double latitude;
			double longitude;
			if(CLLocationManager.LocationServicesEnabled){
				myLocMan.StartUpdatingHeading ();
			}
			myLocMan.UpdatedHeading += (object sender, CLHeadingUpdatedEventArgs e) => {
				latitude = this.getCurrentLatitude();
				longitude = this.getCurrentLongitude();
				temp = new CLLocation(latitude,longitude);
				distancePoints.Add(temp);
			};
			//myLocMan.StopUpdatingHeading ();
			return distancePoints;
		}
		//Calculates the distance traveled.
		public double CalculateDistanceTraveled (List<CLLocation> locations)
		{
			double distance = 0;
			for (int i = 0; i<locations.Capacity; i++) {
				distance += locations [i].DistanceFrom (locations[i+1]);
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

