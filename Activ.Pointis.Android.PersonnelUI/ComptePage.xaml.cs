namespace Activ.Pointis.Android.PersonnelUI;
using Activ.Pointis.Android.PersonnelUI.Models;
using Activ.Pointis.Android.PersonnelUI.Recuperation;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Text.RegularExpressions;


public partial class ComptePage : ContentPage
{
    private long ident;
    private string telephone;
    private AuthService authService;
    public ComptePage()
	{
		InitializeComponent();
        authService = new AuthService();
    }

    public async Task Modifier(long id, Employes employes)
    {
        var httpClientHandler = new HttpClientHandler();


        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        var content = new StringContent(JsonConvert.SerializeObject(employes), Encoding.UTF8, "application/json");
        //var content = new StringContent(connexion);
        var response = await client.PostAsync("https://face.activactions.net/api/Employes/Passe/" + id, content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Enregistrement reussi!");
        }
        else
        {
            Console.WriteLine("Echec de l'ajout: " + response.StatusCode);

        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ident = loginPage.identifiant;
        // Utilisez la variable "message" ici
    }

    private async void valierClick(object sender, EventArgs e)
    {
        string passe = password.Text;
        string conf = passwordconfirm.Text;

        //App.Current.MainPage = new NavigationPage(new MainPage());

        if(passe == conf)
        {
            bool isPasswordValid = Regex.IsMatch(passe, @"^\d{4}$");

            Employes employes = new Employes()
            {
                Password = passe,
            };

            if (isPasswordValid)
            {
                await Modifier(ident, employes);

                string login = ident.ToString();
                string tel = telephone;

                authService.SetUserLoggedIn();
                authService.SaveID("ID", login);
                //authService.SaveTel("Tel", tel);

                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Echec", "Votre mot de passe ne correspond pas à 4 chiffres", "OK");
            }

            

            //string filePath = "Pointis\\Activ.Pointis.Android.PersonnelUI\\DétailConnexion\\connexion.txt";

            // Récupère les informations de connexion de l'utilisateur (login et IMEI)
            

            // Crée le fichier de connexion et stocke les informations de connexion de l'utilisateur
            /*using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(login);
                writer.WriteLine(tel);
            }*/

            //await Shell.Current.GoToAsync("//MainPage");
        }

        else
        {
            await Application.Current.MainPage.DisplayAlert("Echec", "Les deux mots de passe ne correspondent pas", "OK");
        }
    }
}