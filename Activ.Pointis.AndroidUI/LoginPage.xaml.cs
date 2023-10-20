using Newtonsoft.Json;
using System.Text;

namespace ProjetScan;

public partial class LoginPage : ContentPage
{
    public static long identconnexion { get; set; }
    public static long identsociete { get; set; }

    public LoginPage()
	{
		InitializeComponent();
	}

    public async Task<string> Connexion(string login, string passe)
    {
        var httpClientHandler = new HttpClientHandler();

        string ident = "";
        //string url = "https://face.activactions.net/api/Connexion/connect/" + login+"/"+passe;

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        var content = new StringContent(JsonConvert.SerializeObject(passe), Encoding.UTF8, "application/json");
        //var content = new StringContent(telephone);
        var response = await client.PostAsync("https://face.activactions.net/api/Connexion/connect/"+login+"/"+passe, content);

        if (response.IsSuccessStatusCode)
        {
            //Console.WriteLine("Enregistrement reussi!");
            var responseContent = await response.Content.ReadAsStringAsync();
            //ident = long.Parse(responseContent);
            ident = responseContent;
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Echec", "Le numéro de téléphone est incorrect !", "OK");
            Console.WriteLine("Echec de l'ajout: " + response.StatusCode);

        }

        return ident;
    }

    private async void ConnexionClick(object sender, EventArgs e)
	{
        string login = User.Text;
        string passe = Password.Text;
        string valeur = await Connexion(login,passe);

        if(valeur != "\"\"")
        {
            var recuperer = valeur.Split('#');

            string con = recuperer[0].Replace("\"", "");
            long idConnexion = long.Parse(con);

            string soc = recuperer[1].Replace("\"", "");
            long idSociete = long.Parse(soc);

            identconnexion = idConnexion;

            identsociete = idSociete;

            await Shell.Current.GoToAsync("//MainPage");

        }

        else
        {
            await Application.Current.MainPage.DisplayAlert("Erreur", "Le login ou le mot de passe est incorrect !", "OK");
        }

		//App.Current.MainPage = new NavigationPage(new MainPage());
		
	}
}