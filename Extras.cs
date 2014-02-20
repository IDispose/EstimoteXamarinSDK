using System;
using MonoTouch.Foundation;

namespace EstimoteSDK {
	public static class EstimoteUUIDs {
		public static readonly NSUuid ESTIMOTE_PROXIMITY_UUID = new NSUuid(@"B9407F30-F5F8-466E-AFF9-25556B57FE6D");
		public static readonly NSUuid ESTIMOTE_MACBEACON_PROXIMITY_UUID = new NSUuid(@"08D4A950-80F0-4D42-A14B-D53E063516E6");
		public static readonly NSUuid ESTIMOTE_IOSBEACON_PROXIMITY_UUID = new NSUuid(@"8492E75F-4FD6-469D-B132-043FE94921D8");
	}

	public partial class ESTBeacon {

		public override bool Equals(object obj) {

			if(obj == null)
				return false;

			ESTBeacon beacon = obj as ESTBeacon;
			if(beacon == null)
				return false;

			var isEqual = false;
			if(string.IsNullOrEmpty(this.MacAddress)) {
				isEqual = (this.Major == beacon.Major) &&
					(this.Minor == beacon.Minor);
			}else{
				isEqual = (string.Compare(this.MacAddress, beacon.MacAddress) == 0);
			}

			return isEqual;
		}

		public override int GetHashCode() {
			return this.MacAddress.GetHashCode();
		}
	}
}

