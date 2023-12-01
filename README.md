# MauiSample 2

It appears when I create a new MAUI app, the event OnSizeAllocated(double, double) is not being fired on screen rotation, when that page is a FlyoutPage.

Note: OnSizeAllocated is hit the first time the page is loaded. Just not on screen rotation.

Also note that this works perfectly on Android. So it appears to be limited to iOS.

Also note: if I just set ((App)Application.Current).MainPage = page without wrapping it in a FlyoutPage, the event is fired on iOS without a problem. So something about being a FlyoutPage doesn't work with the rotation on iOS.

Place a breakpoint on MauiSample.UI.MainPage..OnSizeAllocated():

![image](https://user-images.githubusercontent.com/63020895/187729047-5f7d756e-7438-4bf3-8c07-cf6fac2081b1.png)

It is hit when the page loads. But is not hit when the screen on an iPad rotates.
