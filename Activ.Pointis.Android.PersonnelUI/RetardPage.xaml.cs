using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using Activ.Pointis.Android.PersonnelUI.Models;

namespace Activ.Pointis.Android.PersonnelUI;

public partial class RetardPage : ContentPage
{
    private double _data;
    //private List<V_Pointage> _data;
    public double Data
    {
        get => _data;
        set
        {
            _data = value;
            OnPropertyChanged(nameof(Data));
        }
    }


    public RetardPage()
	{
		InitializeComponent();
        BindingContext = GetData();
    }



    protected async override void OnAppearing()
    {
        base.OnAppearing();
        GetData();
    }

    //double recup = await GetData();

    private async Task<double> GetData()
    {
        //var lien = "https://face.activactions.net/api/Pointage/Jour/" + Id;
        double donnees = 0;

        long id = loginPage.identifiant;
        string lien = "https://face.activactions.net/api/Pointage/RetardJour/" + id;

        var httpClientHandler = new HttpClientHandler();

        //string test = "ghhghgh";

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        HttpResponseMessage response = await client.GetAsync(lien);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            donnees = double.Parse(responseContent);
            return donnees;

            /*string json = await response.Content.ReadAsStringAsync();
            Data = JsonConvert.DeserializeObject<List<V_Pointage>>(json);*/
        }
        else
        {
            return donnees;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}