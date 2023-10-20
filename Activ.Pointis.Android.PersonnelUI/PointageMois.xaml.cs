using Newtonsoft.Json;
using System.ComponentModel;
using Activ.Pointis.Android.PersonnelUI.Models;
using System.Threading.Tasks;

namespace Activ.Pointis.Android.PersonnelUI;


public partial class PointageMois : ContentPage
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
    public PointageMois()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        GetData();
    }

    private async void GetData()
    {
        //var lien = "https://face.activactions.net/api/Pointage/Jour/" + Id;

        long id = loginPage.identifiant;
        string lien = "https://face.activactions.net/api/Pointage/Mois/" + id;

        var httpClientHandler = new HttpClientHandler();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        HttpResponseMessage response = await client.GetAsync(lien);
        //HttpResponseMessage response = await client.GetAsync("https://face.activactions.net/api/Pointage/Mois/" + id);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            Data = JsonConvert.DeserializeObject<List<V_Pointage>>(json);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}