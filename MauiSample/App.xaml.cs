using MauiSample.Services;
using MauiSample.UI;

namespace MauiSample;

public partial class App : Application
{
    public ServiceProvider ServiceProvider { get; set; }

    public App()
    {
        InitializeComponent();

        IServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

        Start();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddTransient<Page1>();
        services.AddTransient<Page2>();
        services.AddTransient<Page3>();
    }

    private void Start()
    {
        INavigationService navigationService = ServiceProvider.GetRequiredService<INavigationService>();

        ContentPage page = ServiceProvider.GetRequiredService<Page1>() as ContentPage;
        navigationService.LaunchPage(page);
    }

    protected override void OnResume()
    {
        Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
    }

    private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        // handle connectivity changed event here....
    }
}
