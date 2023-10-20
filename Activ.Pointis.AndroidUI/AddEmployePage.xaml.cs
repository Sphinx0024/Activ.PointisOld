using Microsoft.Maui.Controls.Shapes;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using ProjetScan.Model;
using ProjetScan.Services.Employes;
using System.Text;
using System.Net.Http.Json;
using ZXing.QrCode.Internal;
using ZXing.QrCode;
using ZXing;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Xamarin.Essentials;
using Newtonsoft.Json.Linq;
using Json.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;

namespace ProjetScan;

public partial class AddEmployePage : ContentPage, INotifyPropertyChanged
{
    //private long societe;
    private List<EquipeTravailModel> _data;
    
    public List<EquipeTravailModel> Data
    {
        get => _data;
        set
        {
            _data = value;
            OnPropertyChanged(nameof(Data));
        }
    }

    /*private List<EmployesModel> _dataa;
    public List<EmployesModel> Dataa
    {
        get => _dataa;
        set
        {
            _dataa = value;
            OnPropertyChanged(nameof(Dataa));
        }
    }*/

    private EquipeTravailModel _selectedItem;
    
    public EquipeTravailModel SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
        }
    }

    /*private EmployesModel _selected;
    public EmployesModel Selected
    {
        get { return _selected; }
        set
        {
            _selected = value;
            OnPropertyChanged();
        }
    }*/

    public AddEmployePage()
	{
		InitializeComponent();
        BindingContext = this;
        //GetDataEquipe();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        GetDataEquipe();
    }

    private async void GetDataEquipe()
    {
        long id = LoginPage.identsociete;
        string lien = "https://face.activactions.net/api/EquipeTravail/Get/" + id;

        var httpClientHandler = new HttpClientHandler();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        HttpResponseMessage response = await client.GetAsync(lien);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            Data = JsonConvert.DeserializeObject<List<EquipeTravailModel>>(json);
        }
    }

    /*private async void GetDataEmployes()
    {
        var id = LoginPage.identsociete;

        var httpClientHandler = new HttpClientHandler();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        HttpResponseMessage response = await client.GetAsync("https://face.activactions.net/api/Employes/Get/"+id);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            Dataa = JsonConvert.DeserializeObject<List<EmployesModel>>(json);
        }
    }*/

    private async Task<long> GetIDEquipe()
    {
        var id = LoginPage.identsociete;
        long ident = 0;

        //string selectedItemText = SelectedItem.ToString();
        //string[] parts = selectedItemText.Split(new string[] { " - " }, StringSplitOptions.None);

        /*if (parts.Length == 2)
        {
            // Accéder aux valeurs des propriétés en utilisant la méthode GetValue()
            string propriete1 = (string)_selectedItem.GetType().GetProperty("HeureDebutService").GetValue(_selectedItem);
            string propriete2 = (string)_selectedItem.GetType().GetProperty("HeureFinService").GetValue(_selectedItem);

            // Utiliser les valeurs des propriétés
            // ...
        }*/

        // Accéder aux valeurs des propriétés en utilisant la méthode GetValue()
        //string entree = (string)_selectedItem.GetType().GetProperty("HeureDebutService").GetValue(_selectedItem);
        //string sortie = (string)_selectedItem.GetType().GetProperty("HeureFinService").GetValue(_selectedItem);

        string entree = "08h00";
        string sortie = "16h30";

        var httpClientHandler = new HttpClientHandler();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        HttpResponseMessage response = await client.GetAsync("https://face.activactions.net/api/EquipeTravail/GetID/" + id+"/"+entree+"/"+sortie);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            ident = long.Parse(responseContent);
            return ident;
        }
        else
        {
            Console.WriteLine("Echec: " + response.StatusCode);
            return ident;
        }
    }

    public async Task Post(EmployesModel employesModel)
    {
        var httpClientHandler = new HttpClientHandler();

        //long ident = 0;

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        var content = new StringContent(JsonConvert.SerializeObject(employesModel), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://face.activactions.net/api/Employes/Post", content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Enregistrement reussi!");
            Application.Current.MainPage.DisplayAlert("Sucess", "Enregistrement réussi !", "OK");
            Navigation.PushAsync(new UtilisateurPage());
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("Echec", "Enregistrement échoué !", "OK");
            Console.WriteLine("Echec de l'ajout: " + response.StatusCode);
            
        }

        //return ident;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public async void AjouterClick(object sender, EventArgs e)
    {
        long id = await GetIDEquipe();
        string sexe = "Non défini";

        EmployesModel employes = new EmployesModel
        {
            Nom = txtnom.Text,
            Prenom = txtprenom.Text,
            Email = txtemail.Text,
            Telephone = txttelephone.Text,
            //Sexe = (string)txtsexe.SelectedItem,
            Sexe = sexe,
            SocieteID = LoginPage.identsociete,
            Titre = txttitre.Text,
            Matricule = txtmatricule.Text,
            EquipeID = id,
            //Responsable = Selected.ToString()
        };

        await Post(employes);

    }


}