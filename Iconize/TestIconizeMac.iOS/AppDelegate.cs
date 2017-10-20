using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace TestIconizeMac.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{

			global::Xamarin.Forms.Forms.Init();



			FormsPlugin.Iconize.iOS.IconControls.Init();
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.MaterialModule());
            

            LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}

