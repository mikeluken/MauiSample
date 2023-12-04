using Android.App;
using Android.Runtime;
using AndroidX.Activity;
using Microsoft.Maui.Platform;

namespace MauiSample.Platforms.Android;

[Application]
public class MainApplication : MauiApplication
{
    public static MainApplication instance;
    public static MainActivity activity;

    public static MainApplication GetInstance()
    {
        return instance;
    }

    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    public override void OnCreate()
    {
        base.OnCreate();
        instance = this;
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
