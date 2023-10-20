namespace Activ.Pointis.Android.PersonnelUI;
using QRCoder;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.ComponentModel;
using Activ.Pointis.Android.PersonnelUI.Models;
using System.Net.Http.Json;

public partial class MainPage : ContentPage
{
    
    /*private List<Employes> _data;
    public List<Employes> Data
    {
        get => _data;
        set
        {
            _data = value;
            OnPropertyChanged(nameof(Data));
        }
    }*/

    private long ident;

    public MainPage()
	{
        InitializeComponent();
        BindingContext = this;
        OnAppearing();
        OnGenerate();
        
        //GetData(ident);
    }

    private async Task<List<Employes>> GetData(long id)
    {
        //var lien = "https://face.activactions.net/api/Employes/Get/" + id;

        var httpClientHandler = new HttpClientHandler();

        List<Employes> donnees = new List<Employes>();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        HttpResponseMessage response = await client.GetAsync("https://face.activactions.net/api/Employes/GetUn/" + id);

        if (response.IsSuccessStatusCode)
        {
            donnees = await response.Content.ReadFromJsonAsync<List<Employes>>();

            return donnees;
            /*string json = await response.Content.ReadAsStringAsync();
            Data = JsonConvert.DeserializeObject<List<Employes>>(json);*/
        }
        else
        {
            return donnees;
        }

    }


    /*protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }*/

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ident = loginPage.identifiant;
        // Utilisez la variable "message" ici
    }

    private async void GetDeviceId()
    {
        try
        {
            //var deviceId = DeviceInfo.DeviceId;
            //var installationId = DependencyService.Get<IMauiContext>().InstallationId;
        }
        catch (Exception ex)
        {
            // Gérer d'autres exceptions possibles
        }
    }

    private async void OnGenerate()
    {
        List<Employes> donnees;
        donnees = await GetData(ident);

        //var qr = "29#OUATTARA#YOUSSOUF#02147852";

        //var qr = item.EmployeID + "#" + item.Nom + "#" + item.Prenom + "#" + item.Telephone;
        /*QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(qr.ToString(), QRCodeGenerator.ECCLevel.L);
        PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeBytes = qRCode.GetGraphic(20);
        QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));*/

        foreach(var item in donnees)
        {
            var imei = "354341952889277";
            var qr= item.EmployeID + "#" + imei + "#" + item.Nom + "#" + item.Prenom + "#" + item.Telephone + "#" + item.Email;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qr.ToString(), QRCodeGenerator.ECCLevel.L);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(20);
            QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        }

    }
}

