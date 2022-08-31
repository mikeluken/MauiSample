# MauiSample

It appears when I create a new MAUI app, the event OnSizeAllocated(double, double) is not being fired on screen rotation, when that page is a FlyoutPage.

Note: OnSizeAllocated is hit the first time the page is loaded. Just not on screen rotation.

Also note that this works perfectly on Android. So it appears to be limited to iOS.

Also note: if I just set ((App)Application.Current).MainPage = page without wrapping it in a FlyoutPage, the event is fired on iOS without a problem. So something about being a FlyoutPage doesn't work with the rotation on iOS.

