using Newtonsoft.Json;
using ProjetScan.Model;
using System.ComponentModel;
using System.Text;

namespace ProjetScan;

public partial class AccueilPage : ContentPage, INotifyPropertyChanged
{
	public AccueilPage()
	{
		InitializeComponent();
        BindingContext = this;
    }

    /*public void OnParametreClick(object sender, EventArgs e)
	{

	}*/

    /*public void OnDeconnexionClick(object sender, EventArgs e)
	{
		App.Current.MainPage = new NavigationPage(new MainPage());
	}*/

    public async Task Post(long id, Password password)
    {
        var httpClientHandler = new HttpClientHandler();

        //long ident = 0;

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        var content = new StringContent(JsonConvert.SerializeObject(password), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://face.activactions.net/api/Connexion/EditPasse/" + id, content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Modification reussi!");
            Application.Current.MainPage.DisplayAlert("Sucess", "Modification réussi !", "OK");
            Navigation.PushAsync(new MainPage());
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("Echec", "Modification échoué ! L'ancien mot de passe n'est pas correcte !", "OK");
            Console.WriteLine("Echec de la modification: " + response.StatusCode);
        }
    }
    private async void ModifierClick(object sender, EventArgs e)
    {
		string passe = Password.Text;
		string npasse = PasswordN.Text;
		string cpasse = PasswordC.Text;
        long id = LoginPage.identsociete;

        

		if (npasse == cpasse)
		{
            Password password = new Password()
            {
                Ancien = passe,
                Nouveau = npasse
            };
            await Post(id, password);
		}
        else
        {
            Application.Current.MainPage.DisplayAlert("Echec", "Les deux nouveaux mot de passe ne sont pas exacte !", "OK");
        }

        //App.Current.MainPage = new NavigationPage(new MainPage());
    }
}