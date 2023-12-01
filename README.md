# MauiSample

I have started upgrading our Maui apps to use .net8 and target Android 13.  In doing so, I am trying to eliminate the deprecated `base.OnBackPressed();` but I am running into an issue.

# Background

Old logic:
```
// MainActivity.cs
public override void OnBackPressed()
{
    if (someCondition() == true)
    {
        HandleBackPressMyself();
    }
    else
    {
        base.OnBackPressed();
    }
}
```

That is pretty straightforward and has always worked.  Now, I am trying to use the OnBackPressedDispatcher like this:

```
// MainActivity.cs
protected override void OnCreate(Bundle savedInstanceState)
{
    base.OnCreate(savedInstanceState);
    OnBackPressedDispatcher.AddCallback(this, new BackPressedCallback(this));
}
```

```
// BackPressedCallback.cs
public class BackPressedCallback : OnBackPressedCallback
{
    private readonly Activity activity;

    public BackPressedCallback(Activity activity) : base(true)
    {
        this.activity = activity;
    }

    public override void HandleOnBackPressed()
    {
        if (someCondition() == true)
        {
            HandleBackPressMyself();
        }
        else
        {
            var mainPage = ((App)Microsoft.Maui.Controls.Application.Current)?.MainPage;
            if (mainPage != null)
            {
                bool backHandled = mainPage.SendBackButtonPressed();
                if (!backHandled)
                {
                    activity.FinishAndRemoveTask();
                }
            }
        }
    }
}
```

This all works well as long as I push new pages to the stack using `await navigationPage.PushAsync(newPage);`.  

However, there are a couple of scenarios where I want to remove the MainPage and replace it with an altogether new page like so:

`((App)Application.Current).MainPage = loginPage;`

As soon as I do this, the `HandleOnBackPressed()` in the `BackPressedCallback` stops firing, and all my back navigation stops working entirely.  

# How to Recreate

This is a pretty straight forward app that recreates the issue I am having.

1 - Launch the app on Android

2 - Test the navigation: Page 1 -> Page 2 -> Page 3.  
    Once on page three, press the physical back button on Android and navigate back to page 1.  So far, all is working.

3 - Expand the Drawer menu on the left.  Click on the LOGOUT button.  This will just take you back to page 1, but will do so by re-setting MainPage.

4 - Navigate to page 3.  

5 - Try to use the physical nack button again.  The back navigation no longer works.

# MASSIVE UPDATE

I did find that if I target Android SDK version 34, everything works as expected and this issue no longer presents itself.

However, I am not currently able to target SDK version 34, because there is a bug where the app crashes immediately if there is a ConnectivityChanged event registered, which I need in my app:

```
// App.xaml.cs
Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
```

![image](https://github.com/mikeluken/MauiSample/assets/63020895/1a241189-2979-4176-8100-f4212ed77993)

Here is information on that bug in github:
https://github.com/dotnet/maui/issues/17861

I am not sure if the solution is to wait until the fix for this bug is released and then just target SDK 34?  Or if there is some other way to get around my issue?
