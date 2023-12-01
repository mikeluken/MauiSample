using MauiSample.Services;

namespace MauiSample.UI
{
    public partial class Page2 : ContentPage
    {
        private readonly INavigationService navigationService;
        private readonly IServiceProvider serviceProvider;

        public Page2(INavigationService navigationService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.navigationService = navigationService;
            this.serviceProvider = serviceProvider;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Page page3 = serviceProvider.GetRequiredService<Page3>() as Page;
            navigationService.LaunchPage(page3);
        }
    }
}