using Newtonsoft.Json;
using System.ComponentModel;

namespace Activ.Pointis.Android.PersonnelUI;

public partial class AbsencePage : ContentPage
{
    private long _data;
    public long Data
    {
        get => _data;
        set
        {
            _data = value;
            OnPropertyChanged(nameof(Data));
        }
    }

    public AbsencePage()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        GetData();
        //ident = loginPage.identifiant;
        // Utilisez la variable "message" ici
    }

    private async void GetData()
    {
        //var lien = "https://face.activactions.net/api/Pointage/Jour/" + Id;

        long id = loginPage.identifiant;

        var httpClientHandler = new HttpClientHandler();

        //string test = "ghhghgh";

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        //var content = new StringContent(test);
        //HttpResponseMessage response = await client.PostAsync("https://face.activactions.net/api/Pointage/Jour/" + id, content);
        HttpResponseMessage response = await client.GetAsync("https://face.activactions.net/api/Pointage/AbsenceJour/" + id);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            Data = long.Parse(json);
            //Data = JsonConvert.DeserializeObject<long>(json);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}