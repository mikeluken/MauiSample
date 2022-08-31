using Droid = Android;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MauiSample;

[Activity(Label = "My App", Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        Window.SetStatusBarColor(Droid.Graphics.Color.Argb(255, 0, 0, 0));
        base.OnCreate(savedInstanceState);
        MainApplication.activity = this;
    }
}
