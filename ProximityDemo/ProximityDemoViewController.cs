using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using EstimoteSDK;

namespace ProximityDemo {
	public partial class ProximityDemoViewController : UIViewController {

		public ProximityDemoViewController(IntPtr handle) : base(handle) {
		}

		#region Private Properties

		private ESTBeaconManager BeaconManager {
			get;
			set;
		}

		private ESTBeacon SelectedBeacon {
			get;
			set;
		}

		private BeaconManagerDelegate BeaconManagerDelegate {
			get;
			set;
		}

		#endregion

		public override void DidReceiveMemoryWarning() {
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad() {
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.

			SetupEstimote();
		}
			
		public override void ViewWillAppear(bool animated) {
			base.ViewWillAppear(animated);
		}

		public override void ViewDidAppear(bool animated) {
			base.ViewDidAppear(animated);
		}

		public override void ViewWillDisappear(bool animated) {
			base.ViewWillDisappear(animated);
		}

		public override void ViewDidDisappear(bool animated) {
			base.ViewDidDisappear(animated);
		}

		#endregion

		private void SetupEstimote(){
			// setup Estimote beacon manager

			// craete manager instance
			this.BeaconManager = new ESTBeaconManager(); // [[ESTBeaconManager alloc] init];
			this.BeaconManager.Delegate = GetBeaconManagerDelegate();
			this.BeaconManager.AvoidUnknownStateBeacons = true;

			// create sample region object (you can additionaly pass major / minor values)
			var region = new EstimoteSDK.ESTBeaconRegion(EstimoteUUIDs.ESTIMOTE_PROXIMITY_UUID, new NSString(@"EstimoteSampleRegion"));

			//ESTBeaconRegion* region = [[ESTBeaconRegion alloc] initWithProximityUUID:ESTIMOTE_PROXIMITY_UUID
			//	identifier:@"EstimoteSampleRegion"];

			// start looking for estimote beacons in region
			// when beacon ranged beaconManager:didRangeBeacons:inRegion: invoked
			this.BeaconManager.StartRangingBeaconsInRegion(region);
		}

		private ESTBeaconManagerDelegate GetBeaconManagerDelegate(){
			if(BeaconManagerDelegate == null) {
				BeaconManagerDelegate = new BeaconManagerDelegate();
				BeaconManagerDelegate.BeaconFound += OnBeaconFound;
			}
			return BeaconManagerDelegate;
		}

		private void OnBeaconFound (object sender, EventArgs e) {
			// beacon array is sorted based on distance
			// closest beacon is the first one

			var args = (BeaconFoundEventArgs)e;
			var beacon = args.Beacon;

			var beaconProximity = GetProximityText(beacon.Proximity);

			//distanceLabel.Text = string.Format("Major: {0}, \nMinor: {1} \nRegion: {2}",beacon.Major, beacon.Minor, beaconProximity);

		}

		private string GetProximityText(CLProximity proximity){
			var beaconProximity = string.Empty;
			// calculate and set new y position
			switch (proximity){
			case CLProximity.Unknown:
				beaconProximity = @"Unknown";
				break;
			case CLProximity.Immediate:
				beaconProximity = @"Immediate";
				break;
			case CLProximity.Near:
				beaconProximity = @"Near";
				break;
			case CLProximity.Far:
				beaconProximity = @"Far";
				break;

			default:
				break;
			}
			return beaconProximity;
		}
	}
}

