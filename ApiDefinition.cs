using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using MonoTouch.CoreBluetooth;

namespace EstimoteSDK {

	[BaseType (typeof (NSObject))]
	public partial interface ESTBeaconUpdateInfo {

		[Export ("currentFirmwareVersion", ArgumentSemantic.Retain)]
		string CurrentFirmwareVersion { get; set; }

		[Export ("supportedHardware", ArgumentSemantic.Retain)]
		NSArray SupportedHardware { get; set; }
	}

	/// <summary>
	/// ESTBeaconDelegate defines beacon connection delegate mathods. 
	/// Connection is asynchronous operation so you need to be prepared that 
	/// eg. beaconDidDisconnectWith: method can be invoked without previous action.
	/// </summary>
	[Model, BaseType (typeof (NSObject))]
	public partial interface ESTBeaconDelegate {

		/// <summary>
		/// Delegate method that indicates error in beacon connection.
		/// </summary>
		/// <param name="beacon">Reference to the Beacon.</param>
		/// <param name="error">Error Reason.</param>
		[Export ("beaconConnectionDidFail:withError:")]
		void BeaconConnectionDidFail(ESTBeacon beacon, NSError error);

		/// <summary>
		/// Delegate method that indicates success in beacon connection.
		/// </summary>
		/// <param name="beacon">Reference to the Beacon.</param>
		[Export ("beaconConnectionDidSucceeded:")]
		void beaconConnectionDidSucceeded(ESTBeacon beacon);

		/// <summary>
		///  Delegate method that beacon did disconnect with device.
		/// </summary>
		/// <param name="beacon">Beacon.</param>
		/// <param name="error">Error.</param>
		[Export ("beaconDidDisconnect:withError:")]
		void beaconDidDisconnect(ESTBeacon beacon, NSError error);
	}

	/// <summary>
	/// Delegate declarations for blocks (C# lambdas
	/// </summary>
	public delegate void ESTStringCompletionBlock();
	public delegate void ESTUnsignedShortCompletionBlock();
	public delegate void ESTPowerCompletionBlock();
	public delegate void ESTFirmwareUpdateCompletionBlock();
	public delegate void ESTCompletionBlock();

	/// <summary>
	/// The ESTBeacon class represents a beacon that was encountered during region monitoring. 
	/// You do not create instances of this class directly. 
	/// The ESTBeaconManager object reports encountered beacons to its associated delegate object. 
	/// You can use the information in a beacon object to identify which beacon was encountered.
	/// ESTBeacon class contains basic Apple CLBeacon object reference as well as some additional functionality. 
	/// It allows to  connect with Estimote beacon to read / write its characteristics.
	/// </summary>
	[BaseType (typeof (NSObject))]
	public partial interface ESTBeacon {

		[Export ("firmwareState")]
		ESTBeaconFirmwareState FirmwareState { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		ESTBeaconDelegate Delegate { get; set; }

		/// <summary>
		/// Hardware MAC Address of the Beacon
		/// </summary>
		/// <value>The mac address.</value>
		[Export ("macAddress", ArgumentSemantic.Retain)]
		string MacAddress { get; set; }

		/// <summary>
		/// Proximity identifier associated with the beacon.
		/// </summary>
		/// <value>The proximity UUI.</value>
		[Export ("proximityUUID", ArgumentSemantic.Retain)]
		NSUuid ProximityUUID { get; set; }

		/// <summary>
		/// Most significant value associated with the region. 
		/// If a major value wasn't specified, this will be nil.
		/// </summary>
		/// <value>The major.</value>
		[Export ("major", ArgumentSemantic.Retain)]
		NSNumber Major { get; set; }

		/// <summary>
		/// Least significant value associated with the region. 
		/// If a minor value wasn't specified, this will be nil.
		/// </summary>
		/// <value>The minor.</value>
		[Export ("minor", ArgumentSemantic.Retain)]
		NSNumber Minor { get; set; }

		/// <summary>
		/// Received signal strength in decibels of the specified beacon.
		/// This value is an average of the RSSI samples collected since this beacon was last reported.
		/// </summary>
		/// <value>The rssi.</value>
		[Export ("rssi")]
		int ReceivedSignalStrength { get; set; }

		/// <summary>
		/// Distance between phone and beacon calculated based on rssi and measured power.
		/// </summary>
		/// <value>The distance.</value>
		[Export ("distance", ArgumentSemantic.Retain)]
		NSNumber Distance { get; set; }

		/// <summary>
		/// The value in this property gives a general sense of the relative distance to the beacon. 
		/// Use it to quickly identify beacons that are nearer to the user rather than farther away.
		/// </summary>
		/// <value>The proximity.</value>
		[Export ("proximity")]
		CLProximity Proximity { get; set; }

		/// <summary>
		/// Received Signal Strength in dB (rssi) value measured from 1m. 
		/// This value is used for device calibration.
		/// </summary>
		/// <value>The measured power.</value>
		[Export ("measuredPower", ArgumentSemantic.Retain)]
		NSNumber MeasuredPower { get; set; }

		/// <summary>
		/// Reference of the device peripheral object.
		/// </summary>
		/// <value>The peripheral.</value>
		[Export ("peripheral", ArgumentSemantic.Retain)]
		CBPeripheral Peripheral { get; set; }

		/// <summary>
		/// Flag indicating connection status.
		/// </summary>
		/// <value><c>true</c> if this instance is connected; otherwise, <c>false</c>.</value>
		[Export ("isConnected")]
		bool IsConnected { get; }

		/// <summary>
		/// Power of signal in dBm. 
		/// Value available after connection with the beacon. 
		/// It takes one of the values represented by ESTBeaconPower .
		/// </summary>
		/// <value>The power.</value>
		[Export ("power", ArgumentSemantic.Retain)]
		NSNumber Power { get; set; }

		/// <summary>
		/// Advertising interval of the beacon. Value change from 50ms to 2000ms. 
		/// Value available after connection with the beacon
		/// </summary>
		/// <value>The adv interval.</value>
		[Export ("advInterval", ArgumentSemantic.Retain)]
		NSNumber AdvInterval { get; set; }

		/// <summary>
		/// Battery strength in %. Battery level change from 100% - 0%. 
		/// Value available after connection with the beacon
		/// </summary>
		/// <value>The battery level.</value>
		[Export ("batteryLevel", ArgumentSemantic.Retain)]
		NSNumber BatteryLevel { get; set; }

		/// <summary>
		/// Version of device hardware. Value available after connection with the beacon
		/// </summary>
		/// <value>The hardware version.</value>
		[Export ("hardwareVersion", ArgumentSemantic.Retain)]
		string HardwareVersion { get; set; }

		/// <summary>
		/// Version of device firmware. Value available after connection with the beacon
		/// </summary>
		/// <value>The firmware version.</value>
		[Export ("firmwareVersion", ArgumentSemantic.Retain)]
		string FirmwareVersion { get; set; }

		/// <summary>
		/// Firmware update availability status. 
		/// Value available after connection with the beacon and firmware version check.
		/// </summary>
		/// <value>The firmware update info.</value>
		[Export ("firmwareUpdateInfo")]
		ESTBeaconFirmwareUpdate FirmwareUpdateInfo { get; }

		/// <summary>
		/// Connect to particular beacon using bluetooth.
		/// Connection is required to change values like
		/// Major, Minor, Power and Advertising interval.
		/// </summary>
		[Export ("connectToBeacon")]
		void ConnectToBeacon ();

		/// <summary>
		/// Disconnect device with particular beacon
		/// </summary>
		[Export ("disconnectBeacon")]
		void DisconnectBeacon ();

		/// <summary>
		/// Read Proximity UUID of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Callback function</param>
		[Export ("readBeaconProximityUUIDWithCompletion:")]
		void ReadBeaconProximityUUIDWithCompletion (ESTStringCompletionBlock completion);

		/// <summary>
		/// Read major of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Callback function</param>
		[Export ("readBeaconMajorWithCompletion:")]
		void ReadBeaconMajorWithCompletion (ESTUnsignedShortCompletionBlock completion);

		/// <summary>
		/// Read minor of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Callback function.</param>
		[Export ("readBeaconMinorWithCompletion:")]
		void ReadBeaconMinorWithCompletion (ESTUnsignedShortCompletionBlock completion);

		/// <summary>
		/// Read advertising interval of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Callback function.</param>
		[Export ("readBeaconAdvIntervalWithCompletion:")]
		void ReadBeaconAdvIntervalWithCompletion (ESTUnsignedShortCompletionBlock completion);

		/// <summary>
		/// Read power of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Callback function.</param>
		[Export ("readBeaconPowerWithCompletion:")]
		void ReadBeaconPowerWithCompletion (ESTPowerCompletionBlock completion);

		/// <summary>
		/// Read battery level of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Callback function</param>
		[Export ("readBeaconBatteryWithCompletion:")]
		void ReadBeaconBatteryWithCompletion (ESTUnsignedShortCompletionBlock completion);

		/// <summary>
		/// Read firmware version of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Callback function.</param>
		[Export ("readBeaconFirmwareVersionWithCompletion:")]
		void ReadBeaconFirmwareVersionWithCompletion (ESTStringCompletionBlock completion);

		/// <summary>
		/// Read hardware version of connected beacon (Previous connection required).
		/// </summary>
		/// <param name="completion">Callback function.</param>
		[Export ("readBeaconHardwareVersionWithCompletion:")]
		void ReadBeaconHardwareVersionWithCompletion (ESTStringCompletionBlock completion);

		/// <summary>
		/// Writes Proximity UUID param to bluetooth connected beacon. 
		/// Please  remember that If you change the UUID to your very own value anyone can read it, 
		/// copy it and spoof your beacons. So if you are working on a mission critical application 
		/// where security is an issue - be sure to implement it on your end. 
		/// We are also working on a secure mode for our beacons and it will be included in one of the next firmware updates.
		/// </summary>
		/// <param name="pUUID">P UUI.</param>
		/// <param name="completion">Completion.</param>
		[Export ("writeBeaconProximityUUID:withCompletion:")]
		void WriteBeaconProximityUUID (string pUUID, ESTStringCompletionBlock completion);

		/// <summary>
		/// Writes major param to bluetooth connected beacon.
		/// </summary>
		/// <param name="major">Major.</param>
		/// <param name="completion">Completion.</param>
		[Export ("writeBeaconMajor:withCompletion:")]
		void WriteBeaconMajor (ushort major, ESTUnsignedShortCompletionBlock completion);

		/// <summary>
		///  Writes minor param to bluetooth connected beacon.
		/// </summary>
		/// <param name="minor">Minor.</param>
		/// <param name="completion">Callback function.</param>
		[Export ("writeBeaconMinor:withCompletion:")]
		void WriteBeaconMinor (ushort minor, ESTUnsignedShortCompletionBlock completion);

		/// <summary>
		/// Writes advertising interval (in milisec) of connected beacon.
		/// </summary>
		/// <param name="interval">Interval.</param>
		/// <param name="completion">Callback function.</param>
		[Export ("writeBeaconAdvInterval:withCompletion:")]
		void WriteBeaconAdvInterval (ushort interval, ESTUnsignedShortCompletionBlock completion);

		/// <summary>
		/// Writes power of bluetooth connected beacon.
		/// </summary>
		/// <param name="power">Power.</param>
		/// <param name="completion">Callback function.</param>
		[Export ("writeBeaconPower:withCompletion:")]
		void WriteBeaconPower (ESTBeaconPower power, ESTPowerCompletionBlock completion);

		/// <summary>
		/// Verifies if new firmware version is available for download
		/// without any additional action. Internet connection
		/// is required to pass this process.
		/// </summary>
		/// <param name="completion">Callback function.</param>
		[Export ("checkFirmwareUpdateWithCompletion:")]
		void CheckFirmwareUpdateWithCompletion (ESTFirmwareUpdateCompletionBlock completion);

		/// <summary>
		/// Verifies if new firmware version is available for download 
		/// and updates firmware of connected beacon. Internet connection 
		/// is required to pass this process.
		/// </summary>
		/// <param name="progress">Progress.</param>
		/// <param name="completion">Completion.</param>
		[Export ("updateBeaconFirmwareWithProgress:andCompletion:")]
		void UpdateBeaconFirmwareWithProgress (ESTStringCompletionBlock progress, ESTCompletionBlock completion);
	}
		
	[Model, BaseType (typeof (NSObject))]
	public partial interface ESTBeaconManagerDelegate {

		[Export ("beaconManager:didRangeBeacons:inRegion:")]
		void DidRangeBeacons (ESTBeaconManager manager, NSArray beacons, ESTBeaconRegion region);

		[Export ("beaconManager:rangingBeaconsDidFailForRegion:withError:")]
		void RangingBeaconsDidFailForRegion (ESTBeaconManager manager, ESTBeaconRegion region, NSError error);

		[Export ("beaconManager:monitoringDidFailForRegion:withError:")]
		void MonitoringDidFailForRegion (ESTBeaconManager manager, ESTBeaconRegion region, NSError error);

		[Export ("beaconManager:didEnterRegion:")]
		void DidEnterRegion (ESTBeaconManager manager, ESTBeaconRegion region);

		[Export ("beaconManager:didExitRegion:")]
		void DidExitRegion (ESTBeaconManager manager, ESTBeaconRegion region);

		[Export ("beaconManager:didDetermineState:forRegion:")]
		void DidDetermineState (ESTBeaconManager manager, CLRegionState state, ESTBeaconRegion region);

		[Export ("beaconManagerDidStartAdvertising:error:")]
		void Error (ESTBeaconManager manager, NSError error);

		[Export ("beaconManager:didDiscoverBeacons:inRegion:")]
		void DidDiscoverBeacons (ESTBeaconManager manager, NSArray beacons, ESTBeaconRegion region);

		[Export ("beaconManager:didFailDiscoveryInRegion:")]
		void DidFailDiscoveryInRegion (ESTBeaconManager manager, ESTBeaconRegion region);
	}

	[BaseType (typeof (CLLocationManagerDelegate))]
	public partial interface ESTBeaconManager  {

		[Export ("delegate", ArgumentSemantic.Assign)]
		ESTBeaconManagerDelegate Delegate { get; set; }

		[Export ("avoidUnknownStateBeacons")]
		bool AvoidUnknownStateBeacons { get; set; }

		[Export ("virtualBeaconRegion", ArgumentSemantic.Retain)]
		ESTBeaconRegion VirtualBeaconRegion { get; set; }

		[Export ("startRangingBeaconsInRegion:")]
		void StartRangingBeaconsInRegion (ESTBeaconRegion region);

		[Export ("startMonitoringForRegion:")]
		void StartMonitoringForRegion (ESTBeaconRegion region);

		[Export ("stopRangingBeaconsInRegion:")]
		void StopRangingBeaconsInRegion (ESTBeaconRegion region);

		[Export ("stopMonitoringForRegion:")]
		void StopMonitoringForRegion (ESTBeaconRegion region);

		[Export ("requestStateForRegion:")]
		void RequestStateForRegion (ESTBeaconRegion region);

		[Export ("startAdvertisingWithProximityUUID:major:minor:identifier:")]
		void StartAdvertisingWithProximityUUID (NSUuid proximityUUID, NSNumber major, NSNumber minor, string identifier);

		//void StartAdvertisingWithProximityUUID (NSUuid proximityUUID, CLBeaconMajorValue major, CLBeaconMinorValue minor, string identifier);

		[Export ("stopAdvertising")]
		void StopAdvertising ();

		[Export ("startEstimoteBeaconsDiscoveryForRegion:")]
		void StartEstimoteBeaconsDiscoveryForRegion (ESTBeaconRegion region);

		[Export ("stopEstimoteBeaconDiscovery")]
		void StopEstimoteBeaconDiscovery ();
	}



	[BaseType (typeof (CLBeaconRegion))]
	public partial interface ESTBeaconRegion{
		[Export("initWithProximityUUID:identifier:")]
		IntPtr Constructor(NSUuid proximityUUID, NSString identifier);

		[Export("initWithProximityUUID:major:identifier:")]
		IntPtr Constructor(NSUuid proximityUUID, NSNumber major, NSString identifier);

		[Export("initWithProximityUUID:major:minor:identifier:")]
		IntPtr Constructor(NSUuid proximityUUID, NSNumber major, NSNumber minor, NSString identifier);
	}
}
