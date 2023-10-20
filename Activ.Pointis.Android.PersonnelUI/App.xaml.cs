using Activ.Pointis.Android.PersonnelUI.Views;

namespace Activ.Pointis.Android.PersonnelUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		//Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
	}
}
