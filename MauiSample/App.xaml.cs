using MauiSample.Services;
using MauiSample.UI;

namespace MauiSample;

public partial class App : Application
{
    public ServiceProvider serviceProvider { get; set; }

    public App()
	{
        InitializeComponent();

        IServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        serviceProvider = services.BuildServiceProvider();

        Start();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddTransient<MainPage>();
    }

    private void Start()
    {
        INavigationService navigationService = serviceProvider.GetRequiredService<INavigationService>();

        // await navigationService.LaunchLoadingPage();

        ContentPage page = serviceProvider.GetRequiredService<MainPage>() as ContentPage;
        navigationService.LaunchPage(page);
    }
}
