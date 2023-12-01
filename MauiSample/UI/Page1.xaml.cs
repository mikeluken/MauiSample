using MauiSample.Services;

namespace MauiSample.UI
{
    public partial class Page1 : ContentPage
    {
        private readonly INavigationService navigationService;
        private readonly IServiceProvider serviceProvider;

        public Page1(INavigationService navigationService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.navigationService = navigationService;
            this.serviceProvider = serviceProvider;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Page page2 = serviceProvider.GetRequiredService<Page2>() as Page;
            navigationService.LaunchPage(page2);
        }
    }
}