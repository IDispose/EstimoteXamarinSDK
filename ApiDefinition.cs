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

	/**
 

	 */
	/// <summary>
	/// ESTBeaconDelegate defines beacon connection delegate mathods. 
	/// Connection is asynchronous operation so you need to be prepared that 
	/// eg. beaconDidDisconnectWith: method can be invoked without previous action.
	/// </summary>
	[Model, BaseType (typeof (NSObject))]
	public partial interface ESTBeaconDelegate {

		[Export ("beaconConnectionDidFail:withError:")]
		void BeaconConnectionDidFail(ESTBeacon beacon, NSError error);

		[Export ("beaconConnectionDidSucceeded:")]
		void beaconConnectionDidSucceeded(ESTBeacon beacon);

		[Export ("beaconDidDisconnect:withError:")]
		void beaconDidDisconnect(ESTBeacon beacon, NSError error);
	}

	public delegate void ESTStringCompletionBlock();
	public delegate void ESTUnsignedShortCompletionBlock();
	public delegate void ESTPowerCompletionBlock();
	public delegate void ESTFirmwareUpdateCompletionBlock();
	public delegate void ESTCompletionBlock();

	[BaseType (typeof (NSObject))]
	public partial interface ESTBeacon {

		[Export ("firmwareState")]
		ESTBeaconFirmwareState FirmwareState { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		ESTBeaconDelegate Delegate { get; set; }

		[Export ("macAddress", ArgumentSemantic.Retain)]
		string MacAddress { get; set; }

		[Export ("proximityUUID", ArgumentSemantic.Retain)]
		NSUuid ProximityUUID { get; set; }

		[Export ("major", ArgumentSemantic.Retain)]
		NSNumber Major { get; set; }

		[Export ("minor", ArgumentSemantic.Retain)]
		NSNumber Minor { get; set; }

		[Export ("rssi")]
		int Rssi { get; set; }

		[Export ("distance", ArgumentSemantic.Retain)]
		NSNumber Distance { get; set; }

		[Export ("proximity")]
		CLProximity Proximity { get; set; }

		[Export ("measuredPower", ArgumentSemantic.Retain)]
		NSNumber MeasuredPower { get; set; }

		[Export ("peripheral", ArgumentSemantic.Retain)]
		CBPeripheral Peripheral { get; set; }

		[Export ("isConnected")]
		bool IsConnected { get; }

		[Export ("power", ArgumentSemantic.Retain)]
		NSNumber Power { get; set; }

		[Export ("advInterval", ArgumentSemantic.Retain)]
		NSNumber AdvInterval { get; set; }

		[Export ("batteryLevel", ArgumentSemantic.Retain)]
		NSNumber BatteryLevel { get; set; }

		[Export ("hardwareVersion", ArgumentSemantic.Retain)]
		string HardwareVersion { get; set; }

		[Export ("firmwareVersion", ArgumentSemantic.Retain)]
		string FirmwareVersion { get; set; }

		[Export ("firmwareUpdateInfo")]
		ESTBeaconFirmwareUpdate FirmwareUpdateInfo { get; }

		[Export ("connectToBeacon")]
		void ConnectToBeacon ();

		[Export ("disconnectBeacon")]
		void DisconnectBeacon ();

		[Export ("readBeaconProximityUUIDWithCompletion:")]
		void ReadBeaconProximityUUIDWithCompletion (ESTStringCompletionBlock completion);

		[Export ("readBeaconMajorWithCompletion:")]
		void ReadBeaconMajorWithCompletion (ESTUnsignedShortCompletionBlock completion);

		[Export ("readBeaconMinorWithCompletion:")]
		void ReadBeaconMinorWithCompletion (ESTUnsignedShortCompletionBlock completion);

		[Export ("readBeaconAdvIntervalWithCompletion:")]
		void ReadBeaconAdvIntervalWithCompletion (ESTUnsignedShortCompletionBlock completion);

		[Export ("readBeaconPowerWithCompletion:")]
		void ReadBeaconPowerWithCompletion (ESTPowerCompletionBlock completion);

		[Export ("readBeaconBatteryWithCompletion:")]
		void ReadBeaconBatteryWithCompletion (ESTUnsignedShortCompletionBlock completion);

		[Export ("readBeaconFirmwareVersionWithCompletion:")]
		void ReadBeaconFirmwareVersionWithCompletion (ESTStringCompletionBlock completion);

		[Export ("readBeaconHardwareVersionWithCompletion:")]
		void ReadBeaconHardwareVersionWithCompletion (ESTStringCompletionBlock completion);

		[Export ("writeBeaconProximityUUID:withCompletion:")]
		void WriteBeaconProximityUUID (string pUUID, ESTStringCompletionBlock completion);

		[Export ("writeBeaconMajor:withCompletion:")]
		void WriteBeaconMajor (ushort major, ESTUnsignedShortCompletionBlock completion);

		[Export ("writeBeaconMinor:withCompletion:")]
		void WriteBeaconMinor (ushort minor, ESTUnsignedShortCompletionBlock completion);

		[Export ("writeBeaconAdvInterval:withCompletion:")]
		void WriteBeaconAdvInterval (ushort interval, ESTUnsignedShortCompletionBlock completion);

		[Export ("writeBeaconPower:withCompletion:")]
		void WriteBeaconPower (ESTBeaconPower power, ESTPowerCompletionBlock completion);

		[Export ("checkFirmwareUpdateWithCompletion:")]
		void CheckFirmwareUpdateWithCompletion (ESTFirmwareUpdateCompletionBlock completion);

		[Export ("updateBeaconFirmwareWithProgress:andCompletion:")]
		void UpdateBeaconFirmwareWithProgress (ESTStringCompletionBlock progress, ESTCompletionBlock completion);
	}

	/*
	[BaseType (typeof (NSObject))]
	public partial interface ESTBeaconUpdateInfo {

		[Export ("currentFirmwareVersion", ArgumentSemantic.Retain)]
		string CurrentFirmwareVersion { get; set; }

		[Export ("supportedHardware", ArgumentSemantic.Retain)]
		NSArray SupportedHardware { get; set; }
	}


	public enum ESTBeaconPower {
		Level1 = -30,
		Level2 = -20,
		Level3 = -16,
		Level4 = -12,
		Level5 = -8,
		Level6 = -4,
		Level7 = 0,
		Level8 = 4
	}

	public enum ESTBeaconFirmwareState {
		Boot,
		App
	}

	public enum ESTBeaconFirmwareUpdate {
		None,
		Available,
		NotAvailable
	}

	[BaseType (typeof (NSObject))]
	public partial interface ESTBeaconUpdateInfo {

		[Export ("currentFirmwareVersion", ArgumentSemantic.Retain)]
		string CurrentFirmwareVersion { get; set; }

		[Export ("supportedHardware", ArgumentSemantic.Retain)]
		NSArray SupportedHardware { get; set; }
	}

	public enum ESTBeaconPower {
		Level1 = -30,
		Level2 = -20,
		Level3 = -16,
		Level4 = -12,
		Level5 = -8,
		Level6 = -4,
		Level7 = 0,
		Level8 = 4
	}

	public enum ESTBeaconFirmwareState {
		Boot,
		App
	}

	public enum ESTBeaconFirmwareUpdate {
		None,
		Available,
		NotAvailable
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface ESTBeaconDelegate {

		[Export ("beaconConnectionDidFail:withError:")]
		void WithError (ESTBeacon beacon, NSError error);

		[Export ("beaconConnectionDidSucceeded:")]
		void WithError (ESTBeacon beacon);

		[Export ("beaconDidDisconnect:withError:")]
		void WithError (ESTBeacon beacon, NSError error);
	}

	[BaseType (typeof (NSObject))]
	public partial interface ESTBeacon {

		[Export ("firmwareState")]
		ESTBeaconFirmwareState FirmwareState { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		ESTBeaconDelegate Delegate { get; set; }

		[Export ("macAddress", ArgumentSemantic.Retain)]
		string MacAddress { get; set; }

		[Export ("proximityUUID", ArgumentSemantic.Retain)]
		NSUuid ProximityUUID { get; set; }

		[Export ("major", ArgumentSemantic.Retain)]
		NSNumber Major { get; set; }

		[Export ("minor", ArgumentSemantic.Retain)]
		NSNumber Minor { get; set; }

		[Export ("rssi")]
		int Rssi { get; set; }

		[Export ("distance", ArgumentSemantic.Retain)]
		NSNumber Distance { get; set; }

		[Export ("proximity")]
		CLProximity Proximity { get; set; }

		[Export ("measuredPower", ArgumentSemantic.Retain)]
		NSNumber MeasuredPower { get; set; }

		[Export ("peripheral", ArgumentSemantic.Retain)]
		CBPeripheral Peripheral { get; set; }

		[Export ("isConnected")]
		bool IsConnected { get; }

		[Export ("power", ArgumentSemantic.Retain)]
		NSNumber Power { get; set; }

		[Export ("advInterval", ArgumentSemantic.Retain)]
		NSNumber AdvInterval { get; set; }

		[Export ("batteryLevel", ArgumentSemantic.Retain)]
		NSNumber BatteryLevel { get; set; }

		[Export ("hardwareVersion", ArgumentSemantic.Retain)]
		string HardwareVersion { get; set; }

		[Export ("firmwareVersion", ArgumentSemantic.Retain)]
		string FirmwareVersion { get; set; }

		[Export ("firmwareUpdateInfo")]
		ESTBeaconFirmwareUpdate FirmwareUpdateInfo { get; }

		[Export ("connectToBeacon")]
		void ConnectToBeacon ();

		[Export ("disconnectBeacon")]
		void DisconnectBeacon ();

		[Export ("readBeaconProximityUUIDWithCompletion:")]
		void ReadBeaconProximityUUIDWithCompletion (ESTStringCompletionBlock completion);

		[Export ("readBeaconMajorWithCompletion:")]
		void ReadBeaconMajorWithCompletion (ESTUnsignedShortCompletionBlock completion);

		[Export ("readBeaconMinorWithCompletion:")]
		void ReadBeaconMinorWithCompletion (ESTUnsignedShortCompletionBlock completion);

		[Export ("readBeaconAdvIntervalWithCompletion:")]
		void ReadBeaconAdvIntervalWithCompletion (ESTUnsignedShortCompletionBlock completion);

		[Export ("readBeaconPowerWithCompletion:")]
		void ReadBeaconPowerWithCompletion (ESTPowerCompletionBlock completion);

		[Export ("readBeaconBatteryWithCompletion:")]
		void ReadBeaconBatteryWithCompletion (ESTUnsignedShortCompletionBlock completion);

		[Export ("readBeaconFirmwareVersionWithCompletion:")]
		void ReadBeaconFirmwareVersionWithCompletion (ESTStringCompletionBlock completion);

		[Export ("readBeaconHardwareVersionWithCompletion:")]
		void ReadBeaconHardwareVersionWithCompletion (ESTStringCompletionBlock completion);

		[Export ("writeBeaconProximityUUID:withCompletion:")]
		void WriteBeaconProximityUUID (string pUUID, ESTStringCompletionBlock completion);

		[Export ("writeBeaconMajor:withCompletion:")]
		void WriteBeaconMajor (ushort major, ESTUnsignedShortCompletionBlock completion);

		[Export ("writeBeaconMinor:withCompletion:")]
		void WriteBeaconMinor (ushort minor, ESTUnsignedShortCompletionBlock completion);

		[Export ("writeBeaconAdvInterval:withCompletion:")]
		void WriteBeaconAdvInterval (ushort interval, ESTUnsignedShortCompletionBlock completion);

		[Export ("writeBeaconPower:withCompletion:")]
		void WriteBeaconPower (ESTBeaconPower power, ESTPowerCompletionBlock completion);

		[Export ("checkFirmwareUpdateWithCompletion:")]
		void CheckFirmwareUpdateWithCompletion (ESTFirmwareUpdateCompletionBlock completion);

		[Export ("updateBeaconFirmwareWithProgress:andCompletion:")]
		void UpdateBeaconFirmwareWithProgress (ESTStringCompletionBlock progress, ESTCompletionBlock completion);

	}
	*/

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

	/*
	[BaseType (typeof (NSObject))]
	public partial interface ESTBeaconUpdateInfo {

		[Export ("currentFirmwareVersion", ArgumentSemantic.Retain)]
		string CurrentFirmwareVersion { get; set; }

		[Export ("supportedHardware", ArgumentSemantic.Retain)]
		NSArray SupportedHardware { get; set; }
	}
	*/

	[BaseType (typeof (CLBeaconRegion))]
	public partial interface ESTBeaconRegion{
	
	}
}
