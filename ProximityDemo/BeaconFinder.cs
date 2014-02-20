using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using EstimoteSDK;
using MonoTouch.CoreLocation;
using System.Collections.Generic;
using MonoTouch.Foundation;

namespace ProximityDemo {
	public class BeaconFinder {

		public DialogViewController RootDVC {
			get;
			private set;
		}

		public BeaconFinder(DialogViewController dialogViewController) {
			RootDVC = dialogViewController;
			AddFindButton();
			SetupEstimote();
			this.Beacons = new List<ESTBeacon>();
		}

		private UIBarButtonItem FindBeaconsButton {
			get;
			set;
		}

		private void AddFindButton(){
			this.FindBeaconsButton = new UIBarButtonItem(UIBarButtonSystemItem.Search);
			this.RootDVC.NavigationItem.RightBarButtonItem = this.FindBeaconsButton;

			this.FindBeaconsButton.Clicked += OnFindBeaconsClicked;
		}

		private void OnFindBeaconsClicked (object sender, EventArgs e) {
			// start looking for estimote beacons in region
			// when beacon ranged beaconManager:didRangeBeacons:inRegion: invoked
			this.BeaconManager.StartRangingBeaconsInRegion(this.Region);
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

		private EstimoteSDK.ESTBeaconRegion Region {
			get; 
			set;
		}

		private List<EstimoteSDK.ESTBeacon> Beacons {
			get;
			set;
		}

		#endregion

		private void SetupEstimote(){
			// setup Estimote beacon manager

			// craete manager instance
			this.BeaconManager = new ESTBeaconManager(); // [[ESTBeaconManager alloc] init];
			this.BeaconManager.Delegate = GetBeaconManagerDelegate();
			this.BeaconManager.AvoidUnknownStateBeacons = true;

			// create sample region object (you can additionaly pass major / minor values)
			this.Region = new EstimoteSDK.ESTBeaconRegion(EstimoteUUIDs.ESTIMOTE_PROXIMITY_UUID, new NSString(@"EstimoteSampleRegion"));

			//ESTBeaconRegion* region = [[ESTBeaconRegion alloc] initWithProximityUUID:ESTIMOTE_PROXIMITY_UUID
			//	identifier:@"EstimoteSampleRegion"];


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

			if(Beacons.Contains(beacon)) {
				var index = Beacons.IndexOf(beacon);
				var b = Beacons[index];
				b.Proximity = beacon.Proximity;
			} else {
				Beacons.Add(beacon);
			}
			RefreshDisplayList();
		}

		private void RefreshDisplayList(){
			RootDVC.Root.Clear();
			foreach(var beacon in Beacons) {
				RootDVC.Root.Add(new Section(){
					GetBeaconDisplayElement(beacon)
				});
			}

		}

		private StyledStringElement GetBeaconDisplayElement(ESTBeacon beacon){
			return new StyledStringElement(string.Format("Major: {0}, Minor: {1}", beacon.Major, beacon.Minor),
				string.Format("Proximity: {0}", GetProximityText(beacon.Proximity)));
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

