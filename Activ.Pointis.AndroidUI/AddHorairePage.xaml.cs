using Newtonsoft.Json;
using System.Text;
using ProjetScan.Model;

namespace ProjetScan;

public partial class AddHorairePage : ContentPage
{
	public AddHorairePage()
	{
		InitializeComponent();
        BindingContext = this;
	}

    public async Task Post(EquipeModel equipeModel)
    {
        var httpClientHandler = new HttpClientHandler();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        var content = new StringContent(JsonConvert.SerializeObject(equipeModel), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://face.activactions.net/api/EquipeTravail/Post", content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Enregistrement reussi!");
            Application.Current.MainPage.DisplayAlert("Sucess", "Enregistrement réussi !", "OK");
            Navigation.PushAsync(new HoraireTravailPage());
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("Echec", "Enregistrement échoué !", "OK");
            Console.WriteLine("Echec de l'ajout: " + response.StatusCode);

        }
    }

    public async void AjouterClick(object sender, EventArgs e)
    {


        EquipeModel equipe = new EquipeModel()
        {
            Title = titre.Text,
            HeureDebutService = heure_debut.Text,
            HeureFinService = heure_fin.Text,
            SocieteID = LoginPage.identsociete,
        };



        await Post(equipe);


    }
}