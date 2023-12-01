using MauiSample.Services;

namespace MauiSample.UI
{
    public partial class DrawerMenu : ContentPage
    {
        public DrawerMenu()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            INavigationService navigationService = 
                ((App)App.Current).ServiceProvider.GetRequiredService<INavigationService>();

            Page page1 = 
                ((App)App.Current).ServiceProvider.GetRequiredService<Page1>() as Page;

            navigationService.LaunchPageRoot(page1);
        }
    }
}