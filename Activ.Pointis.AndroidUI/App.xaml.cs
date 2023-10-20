using System.Net;

namespace ProjetScan;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

        MainPage = new AppShell();

		//MainPage = new NavigationPage(new MainPage());
	}
}
