# MauiSample

I have upgraded my Maui app to use .net8 and target Android 13.  In doing so, I am trying to eliminate the deprecated `base.OnBackPressed();` but I am running into an issue.

Old logic:
```
// MainActivity.cs
public override void OnBackPressed()
{
    if (someCondition() == true)
    {
        HandleBackPressMyself();
    }
    else
    {
        base.OnBackPressed();
    }
}
```

I am launching my page like this:

```
// App.xaml.cs
public App()
{
    InitializeComponent();
    Start();
}

private async void Start()
{
    var page = serviceProvider.GetRequiredService<MyFirstPage>();
    Application.Current?.Dispatcher.Dispatch(async () =>
    {
        ((App)Application.Current).MainPage = page;
        await Task.Delay(1);
    };
}
```

That is pretty straightforward and has always worked.  Now, I am trying to use the OnBackPressedDispatcher like this:

```
// MainActivity.cs
protected override void OnCreate(Bundle savedInstanceState)
{
    base.OnCreate(savedInstanceState);
    OnBackPressedDispatcher.AddCallback(this, new BackPressedCallback(this));
}
```

```
// BackPressedCallback.cs
public class BackPressedCallback : OnBackPressedCallback
{
    private readonly Activity activity;

    public BackPressedCallback(Activity activity) : base(true)
    {
        this.activity = activity;
    }

    public override void HandleOnBackPressed()
    {
        if (someCondition() == true)
        {
            HandleBackPressMyself();
        }
        else
        {
            var mainPage = ((App)Microsoft.Maui.Controls.Application.Current)?.MainPage;
            mainPage.SendBackButtonPressed();
        }
    }
}
```

This all works well as long as I push new pages to the stack using `await navigationPage.PushAsync(newPage);`.  

However, there are a couple of scenarios where I want to remove the MainPage and replace it with an altogether new page like so:

`((App)Application.Current).MainPage = loginPage;`

As soon as I do this, the `HandleOnBackPressed()` in the `BackPressedCallback` stops firing, and all my back navigation stops working entirely.  

Can anybody provide some insight on why the back handler would stop working after I set `Application.Current.MainPage = someNewPage`?

Thanks!
