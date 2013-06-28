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
		List<CLLocation> listOfTripLocationCoordinates = new List<CLLocation> ();
		CLLocationManager commonLocationManager;

		public RawGPSViewController () : base ("RawGPSViewController", null)
		{
			commonLocationManager = new CLLocationManager();
		}

		partial void recordDistanceAction (NSObject sender)
		{
			double currentLatitude = this.getCurrentUserLatitude ();
			RecLatLabel.Text = currentLatitude.ToString ();

			double currentLongitude = this.getCurrentUserLongitude ();
			RecLongLabel.Text = currentLongitude.ToString ();
		
			double distanceTravelledinKilometers = convertMetersToKilometers(this.CalculateDistanceTraveled (listOfTripLocationCoordinates));
			DistLabel.Text = " Distance Traveled: " + distanceTravelledinKilometers.ToString ("0.00000");
			double currentSpeedInKilometers = convertToKilometersPerHour(this.getSpeedInMetersPerSecondUnits());
			SpeedLabel.Text = currentSpeedInKilometers.ToString ();
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
			this.createCoordinatesWhenHeadingChangesToAddToList ();
		}

		public double getCurrentUserLatitude ()
		{
			commonLocationManager.DesiredAccuracy = CLLocation.AccuracyBest;
			if (CLLocationManager.LocationServicesEnabled) {
				commonLocationManager.StartUpdatingLocation ();
			}
			commonLocationManager.StopUpdatingLocation ();
			return commonLocationManager.Location.Coordinate.Latitude;
		}

		public double getCurrentUserLongitude ()
		{
			commonLocationManager.DesiredAccuracy = CLLocation.AccuracyBest;
			if (CLLocationManager.LocationServicesEnabled) {
				commonLocationManager.StartUpdatingLocation ();
			}
			commonLocationManager.StopUpdatingLocation ();
			return commonLocationManager.Location.Coordinate.Longitude;
		}

		public double getSpeedInMetersPerSecondUnits ()
		{
			commonLocationManager.DesiredAccuracy = CLLocation.AccuracyBest;
			if (CLLocationManager.LocationServicesEnabled) {
				commonLocationManager.StartUpdatingLocation ();
			}
			return commonLocationManager.Location.Speed;
		}

		public double convertToKilometersPerHour (double metersPerSecond)
		{
			return (metersPerSecond / 1000.0) * 3600;
		}

		public double convertMetersToKilometers (double meters)
		{
			return meters / 1000.0;
		}

		public void createCoordinatesWhenHeadingChangesToAddToList ()
		{
			commonLocationManager.DesiredAccuracy = CLLocation.AccuracyBest;
			commonLocationManager.HeadingFilter = 30;
			CLLocation temp;

			if (CLLocationManager.LocationServicesEnabled) {
				commonLocationManager.StartUpdatingLocation ();
			}
			if (CLLocationManager.HeadingAvailable) {
				commonLocationManager.StartUpdatingHeading ();
			}

			commonLocationManager.UpdatedHeading += (object sender, CLHeadingUpdatedEventArgs e) => {
				MagHeadLabel.Text = e.NewHeading.MagneticHeading.ToString () + "º";
				TrueHeadLabel.Text = e.NewHeading.TrueHeading.ToString () + "º";
				temp = new CLLocation (this.getCurrentUserLatitude (), this.getCurrentUserLongitude ());
				listOfTripLocationCoordinates.Add (temp);
				pointsLabel.Text = listOfTripLocationCoordinates.Count.ToString ();
			};
		}

		public double CalculateDistanceTraveled (List<CLLocation> locations)
		{
			double distance = 0;
			double temp = 0;
			for (int i = 0; i<locations.Count; i++) {
				if (i+1 < locations.Count ) {
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

