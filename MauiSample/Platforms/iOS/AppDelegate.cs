using Foundation;
using UIKit;

namespace MauiSample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        UINavigationBar.Appearance.BarTintColor = UIColor.Black;
        UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White });

        return base.FinishedLaunching(app, options);
    }
}
