namespace ProjetScan;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private  void OnScannerEntreeClick(object sender, EventArgs e)
	{
        Navigation.PushAsync(new ScannerPage());
    }

	private  void OnScannerSortieClick(object sender, EventArgs e)
	{
        Navigation.PushAsync(new ScanSortiePage());
        //App.Current.MainPage = new NavigationPage(new ScannerPage());
        //App.Current.MainPage = new NavigationPage(new ScanSortiePage());
    }

	/*private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}*/
}

