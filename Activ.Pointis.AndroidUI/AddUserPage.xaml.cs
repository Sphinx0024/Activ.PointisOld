using Newtonsoft.Json;
using ProjetScan.Model;
using System.Text;

namespace ProjetScan;

public partial class AddUserPage : ContentPage
{
	public AddUserPage()
	{
		InitializeComponent();
        BindingContext = this;
	}

    

    public async Task Post(UtilisateurModel utilisateur)
    {
        var httpClientHandler = new HttpClientHandler();

        //long ident = 0;

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        var content = new StringContent(JsonConvert.SerializeObject(utilisateur), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://face.activactions.net/api/Connexion/Add", content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Enregistrement reussi!");
            Application.Current.MainPage.DisplayAlert("Sucess", "Enregistrement réussi !", "OK");
            Navigation.PushAsync(new user());
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("Echec", "Enregistrement échoué !", "OK");
            Console.WriteLine("Echec de l'ajout: " + response.StatusCode);

        }
    }

    public async void AjouterClick(object sender, EventArgs e)
    {

        UtilisateurModel utilisateur = new UtilisateurModel
        {
            Login = txtlogin.Text,
            Role = (string)txtrole.SelectedItem,
            SocieteID = LoginPage.identsociete,
            Verification = "First"
        };



        await Post(utilisateur);

        
    }
}