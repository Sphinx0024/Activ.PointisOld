using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Text;
using ZXing.Net.Maui.Controls;
using ProjetScan.Model;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Xamarin.Essentials;
using Microsoft.Maui.Controls;
//using Microsoft.Maui.Essentials;

namespace ProjetScan;

public partial class ScannerPage : ContentPage
{
    private long empID;
    private string donnees;
	public ScannerPage()
	{
		InitializeComponent();
	}

    public async void Post(PointageModel pointageModel) 
    {
        var httpClientHandler = new HttpClientHandler();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        
        //  using var client = new HttpClient();
        var content = new StringContent(JsonConvert.SerializeObject(pointageModel), Encoding.UTF8, "application/json");
        
        //var content = new StringContent(JsonSerializer.Serialize(employesModel), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://face.activactions.net/api/Pointage/Post", content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Enregistrement reussi!");
            Application.Current.MainPage.DisplayAlert("Success", donnees, "OK");
            Navigation.PushAsync(new MainPage());
        }
        else
        {
            Console.WriteLine("Echec de l'ajout: " + response.StatusCode);
            Application.Current.MainPage.DisplayAlert("Echec", "Le pointage a échoué", "OK");
        }
    }

    /*public async Task<string> GetImeiAsync()
    {
        try
        {
            var imei = await Microsoft.Maui.Devices.DeviceInfo.GetImeiAsync();
            return imei;
        }
        catch (Xamarin.Essentials.FeatureNotSupportedException ex)
        {
            // Gérer l'exception ici
            return null;
        }
    }*/


    

    /*public string GetImei()
   {
       if (DeviceInfo.Platform == DevicePlatform.Android)
       {
           var context = Android.App.Application.Context;
           var telephonyManager = (TelephonyManager)context.GetSystemService(Context.TelephonyService);
           if (telephonyManager != null)
           {
               var imei = telephonyManager.GetImei(0);
               return imei;
           }
           else
           {
               // Gérer l'exception ici
               return null;
           }
       }
       else
       {
           // La plateforme cible ne prend pas en charge l'accès au numéro IMEI
           return null;
       }
   }*/



    private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
		Dispatcher.Dispatch(() =>
		{
            //var resultat = $"{e.Results[0].Value} {e.Results[0].Format}";
            var resultat = $"{e.Results[0].Value}";
            var separer = resultat.Split('#');
            empID = long.Parse(separer[0]);
            donnees = separer[2] + " " + separer[3] + " a été pointé avec succès";
            //var donnees = separer[1] + " \n" + separer[2] + " \n" + separer[3] + " \n" + separer[4];
            //barcodeResult.Text = donnees;

            //DateTime Jour = DateTime.Today;
            DateTime now = DateTime.Now;
            DateTime Jour = now.Date;

            DateTime maintenant = DateTime.Now;


            PointageModel pointage = new PointageModel
            {
                Jour = Jour,
                HeureEntree = maintenant,
                EmployesID = empID,
                Imei_employe_entree = "nb014jhgg01hhgff12hgff",
                longitude_entree = "nb014jhgg01hhgff12hgff",
                latitude_entree = "nb014jhgg01hhgff12hgff"
            };
            Post(pointage);

            
        });

        barcodeReader.IsDetecting = false;
    }

    /*public async void ValiderClick(object sender, EventArgs e)
    {
        /*var r = barcodeResult.Text;
        var s = r.Split('#');
        long id = long.Parse(s[0]);*/

        /*DateTime Jour = DateTime.Today;
        DateTime maintenant = DateTime.Now;


        PointageModel pointage = new PointageModel
        {
            Jour = Jour,
            HeureEntree = maintenant,
            EmployesID = empID,
            Imei_employe_entree = "nb014jhgg01hhgff12hgff",
            Imei_verificateur_entree = "nb014jhgg01hhgff12hgff",
            Application_id_entree = "nb014jhgg01hhgff12hgff"
        };

        await Post(pointage);
        await Navigation.PushAsync(new MainPage());

    }*/
}