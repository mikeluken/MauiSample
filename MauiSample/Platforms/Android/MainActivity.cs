using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Activity;

namespace MauiSample.Platforms.Android;

[Activity(Label = "My App", Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        MainApplication.activity = this;

        OnBackPressedDispatcher.AddCallback(
            MainApplication.activity, 
            new BackPressedCallback(this)
        );
    }
}
