using MauiSample.UI.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSample.Services
{
    public class NavigationService : INavigationService
    {
        public void LaunchPage(ContentPage page)
        {
            FlyoutPage FlyoutPage = new FlyoutPage
            {
                Detail = new NavigationPage(page)
                {
                    BarBackgroundColor = Color.FromArgb("#000000")
                },
                Flyout = new DrawerMenu(),
                FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover
            };
            ((App)Application.Current).MainPage = FlyoutPage;
        }
    }
}
