namespace MauiSample.UI;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	protected override void OnSizeAllocated(double width, double height)
	{
		// BUG: This gets hit on page load.
		// But does not get hit when changing the screen orientation
		base.OnSizeAllocated(width, height);
	}
}

