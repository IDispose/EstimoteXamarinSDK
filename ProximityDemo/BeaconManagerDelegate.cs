using System;

namespace ProximityDemo {
	public class BeaconManagerDelegate : EstimoteSDK.ESTBeaconManagerDelegate {

		public event EventHandler BeaconFound;

		public EstimoteSDK.ESTBeacon SelectedBeacon {
			get;
			private set;
		}

		public BeaconManagerDelegate() {
		}

		public override void DidRangeBeacons(EstimoteSDK.ESTBeaconManager manager, MonoTouch.Foundation.NSArray beacons, EstimoteSDK.ESTBeaconRegion region) {
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events

			if(beacons.Count > 0) {

				if(this.SelectedBeacon == null) {
					// initialy pick closest beacon
					this.SelectedBeacon = beacons.GetItem<EstimoteSDK.ESTBeacon>(0);// [beacons objectAtIndex:0];
				} else {
					for(int i = 0; i < beacons.Count; i++) {
						var beacon = beacons.GetItem<EstimoteSDK.ESTBeacon>(i);
						if((SelectedBeacon.Major == beacon.Major) &&
							(SelectedBeacon.Minor == beacon.Minor)) {
							SelectedBeacon = beacon;
							break;
						}
					}
				}
				OnBeaconFound(new BeaconFoundEventArgs(this.SelectedBeacon));
			}
		}

		protected virtual void OnBeaconFound(BeaconFoundEventArgs args){
			EventHandler handler = BeaconFound;

			if(handler != null) {
				handler(this, args);
			}
		}
	}
}

