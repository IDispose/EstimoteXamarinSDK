using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ProximityDemo {
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate {
		// class-level declarations

		private MonoTouch.Dialog.RootElement Root {
			get;
			set;
		}

		private MonoTouch.Dialog.DialogViewController RootDVC {
			get;
			set;
		}

		private UINavigationController RootNav {
			get;
			set;
		}

		public override UIWindow Window {
			get;
			set;
		}
		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation(UIApplication application) {
		}
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground(UIApplication application) {
		}
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground(UIApplication application) {
		}
		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate(UIApplication application) {
		}

		private BeaconFinder MyBeaconFinder {
			get;
			set;
		}
		public override void FinishedLaunching(UIApplication application) {
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events
			SetupDVC();
			this.MyBeaconFinder = new BeaconFinder(this.RootDVC);

			this.Window.RootViewController = this.RootNav;
			this.Window.MakeKeyAndVisible();

		}

		private void SetupDVC(){
			this.Root = new MonoTouch.Dialog.RootElement("Estimote Beacons"){ new MonoTouch.Dialog.Section() };
			this.RootDVC = new MonoTouch.Dialog.DialogViewController(UITableViewStyle.Plain, this.Root);
			this.RootNav = new UINavigationController(this.RootDVC);

		}
	}
}

