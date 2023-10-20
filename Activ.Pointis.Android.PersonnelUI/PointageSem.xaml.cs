using Newtonsoft.Json;
using System.ComponentModel;
using Activ.Pointis.Android.PersonnelUI.Models;


namespace Activ.Pointis.Android.PersonnelUI;

public partial class PointageSem : ContentPage
{
    private List<V_Pointage> _data;
    public List<V_Pointage> Data
    {
        get => _data;
        set
        {
            _data = value;
            OnPropertyChanged(nameof(Data));
        }
    }

    public PointageSem()
	{
        InitializeComponent();
        BindingContext = this;
        //GetData();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        GetData();
        //ident = loginPage.identifiant;
        // Utilisez la variable "message" ici
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async void GetData()
    {
        //var lien = "https://face.activactions.net/api/Pointage/Jour/" + Id;

        long id = loginPage.identifiant;
        string lien = "https://face.activactions.net/api/Pointage/Semaine/" + id;

        var httpClientHandler = new HttpClientHandler();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        HttpResponseMessage response = await client.GetAsync(lien);
        //HttpResponseMessage response = await client.GetAsync("https://face.activactions.net/api/Pointage/Semaine/" + id);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            Data = JsonConvert.DeserializeObject<List<V_Pointage>>(json);
        }
    }

}