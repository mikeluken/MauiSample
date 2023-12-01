using Android.App;
using AndroidX.Activity;

namespace MauiSample.Platforms.Android
{
    public class BackPressedCallback : OnBackPressedCallback
    {
        private readonly Activity activity;

        public BackPressedCallback(Activity activity) : base(true)
        {
            this.activity = activity;
        }

        public override void HandleOnBackPressed()
        {
            if (1 == 2)
            {
                // this is irrelevant to this example, but this is where i would
                // be handling my custom back handling logic.
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
}
