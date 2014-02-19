using System;

namespace ProximityDemo {
	public class BeaconFoundEventArgs : EventArgs {
		public BeaconFoundEventArgs(EstimoteSDK.ESTBeacon beacon) {
			this.Beacon = beacon;
		}

		public EstimoteSDK.ESTBeacon Beacon {
			get;
			private set;
		}
	}
}

