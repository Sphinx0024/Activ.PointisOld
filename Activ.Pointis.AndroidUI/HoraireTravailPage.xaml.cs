using Newtonsoft.Json;
using System.ComponentModel;
using ProjetScan.Model;

namespace ProjetScan;

public partial class HoraireTravailPage : ContentPage, INotifyPropertyChanged
{
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
    public HoraireTravailPage()
    {
        InitializeComponent();
        BindingContext = this;
        GetData();
    }

    private async void GetData()
    {
        long idsoc = LoginPage.identsociete;

        var httpClientHandler = new HttpClientHandler();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        HttpResponseMessage response = await client.GetAsync("https://face.activactions.net/api/EquipeTravail/Get/" + idsoc);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            Data = JsonConvert.DeserializeObject<List<EquipeTravailModel>>(json);
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void AddClick(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddHorairePage());
    }
}