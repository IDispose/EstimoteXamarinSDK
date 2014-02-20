using System;

namespace ProximityDemo {
	public class BeaconManagerDelegate : EstimoteSDK.ESTBeaconManagerDelegate {

		public event EventHandler BeaconFound;


		public BeaconManagerDelegate() {
		}

		public override void DidRangeBeacons(EstimoteSDK.ESTBeaconManager manager, MonoTouch.Foundation.NSArray beacons, EstimoteSDK.ESTBeaconRegion region) {
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events

			if(beacons.Count > 0) {

				for(int i = 0; i < beacons.Count; i++) {
					var beacon = beacons.GetItem<EstimoteSDK.ESTBeacon>(i);
					OnBeaconFound(new BeaconFoundEventArgs(beacon));
				}
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

