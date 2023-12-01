using MauiSample.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSample.Services
{
    public class NavigationService : INavigationService
    {
        public async Task LaunchPage(Page page) 
        {
            var mainPage = ((App)Application.Current).MainPage;
            if (mainPage != null && mainPage.GetType() == typeof(FlyoutPage))
            {
                Page mdp = (mainPage as FlyoutPage).Detail;
                NavigationPage np = (NavigationPage)mdp;

                await np.PushAsync(page);
            }
            else
            {
                FlyoutPage FlyoutPage = new FlyoutPage
                {
                    Detail = new NavigationPage(page),
                    Flyout = new DrawerMenu(),
                    FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover,
                };
                ((App)Application.Current).MainPage = FlyoutPage;
            }
        }

        public void LaunchPageRoot(Page page)
        {
            FlyoutPage FlyoutPage = new FlyoutPage
            {
                Detail = new NavigationPage(page),
                Flyout = new DrawerMenu(),
                FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover,
            };
            ((App)Application.Current).MainPage = FlyoutPage;
        }
    }
}
