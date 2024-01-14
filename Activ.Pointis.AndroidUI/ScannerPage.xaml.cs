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
            Application.Current.MainPage.DisplayAlert("Echec", "Le pointage a �chou�", "OK");
        }
    }

    public async Task FullPointage(long id, string token, string support)
    {
        long i = await PointageID(id);

        //PointageModel pointage = new PointageModel
        //{
        //    HeureSortie = DateTime.Now,
        //    longitude_sortie = "nb014jhgg01hhgff12hgff",
        //    latitude_sortie = "nb014jhgg01hhgff12hgff"
        //};

        DateTime now = DateTime.Now;
        DateTime Jour = now.Date;

        PointageModel pointage = new PointageModel
        {
            Jour = Jour,
            HeureEntree = now,
            EmployesID = empID,
            Imei_employe_entree = "nb014jhgg01hhgff12hgff",
            longitude_entree = "nb014jhgg01hhgff12hgff",
            latitude_entree = "nb014jhgg01hhgff12hgff",
            userPointage = LoginPage.identconnexion.ToString(),
            token = token,
            support = support,
            Statut = 1
        };

        await Put(i, pointage);

    }

    public async Task<long> PointageID(long id)
    {
        var httpClientHandler = new HttpClientHandler();

        long pointID = 0;

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        //var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");

        var response = await client.GetAsync("https://face.activactions.net/api/Pointage/Point/" + id);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            pointID = long.Parse(responseContent);
            return pointID;
        }
        else
        {
            Console.WriteLine("Echec: " + response.StatusCode);
            return pointID;
        }
    }

    public async Task Put(long id, PointageModel pointageModel)
    {
        var httpClientHandler = new HttpClientHandler();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        var content = new StringContent(JsonConvert.SerializeObject(pointageModel), Encoding.UTF8, "application/json");
        //var content = new StringContent(JsonSerializer.Serialize(employesModel), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://face.activactions.net/api/Pointage/ModifierEntrer/" + id, content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Modification reussi!");
            Application.Current.MainPage.DisplayAlert("Success", donnees, "OK");
            Navigation.PushAsync(new MainPage());
        }
        else
        {
            Console.WriteLine("Echec: " + response.StatusCode);
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
            // G�rer l'exception ici
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
               // G�rer l'exception ici
               return null;
           }
       }
       else
       {
           // La plateforme cible ne prend pas en charge l'acc�s au num�ro IMEI
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
            donnees = separer[2] + " " + separer[3] + " a �t� point� avec succ�s";
            //var donnees = separer[1] + " \n" + separer[2] + " \n" + separer[3] + " \n" + separer[4];
            //barcodeResult.Text = donnees;

            //DateTime Jour = DateTime.Today;
            DateTime now = DateTime.Now;
            DateTime Jour = now.Date;

            //DateTime maintenant = DateTime.Now;

            FullPointage(empID, separer[6], separer[7]);


            //PointageModel pointage = new PointageModel
            //{
            //    Jour = Jour,
            //    HeureEntree = maintenant,
            //    EmployesID = empID,
            //    Imei_employe_entree = "nb014jhgg01hhgff12hgff",
            //    longitude_entree = "nb014jhgg01hhgff12hgff",
            //    latitude_entree = "nb014jhgg01hhgff12hgff",
            //    userPointage = LoginPage.identconnexion.ToString(),
            //    token = "",
            //    support = "",
            //    Statut = 1
            //};
            //Post(pointage);


        });

        barcodeReader.IsDetecting = false;
    }



    //   private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    //{
    //	Dispatcher.Dispatch(() =>
    //	{
    //           //var resultat = $"{e.Results[0].Value} {e.Results[0].Format}";
    //           var resultat = $"{e.Results[0].Value}";
    //           var separer = resultat.Split('#');
    //           empID = long.Parse(separer[0]);
    //           donnees = separer[2] + " " + separer[3] + " a �t� point� avec succ�s";
    //           //var donnees = separer[1] + " \n" + separer[2] + " \n" + separer[3] + " \n" + separer[4];
    //           //barcodeResult.Text = donnees;

    //           //DateTime Jour = DateTime.Today;
    //           DateTime now = DateTime.Now;
    //           DateTime Jour = now.Date;

    //           DateTime maintenant = DateTime.Now;


    //           PointageModel pointage = new PointageModel
    //           {
    //               Jour = Jour,
    //               HeureEntree = maintenant,
    //               EmployesID = empID,
    //               Imei_employe_entree = "nb014jhgg01hhgff12hgff",
    //               longitude_entree = "nb014jhgg01hhgff12hgff",
    //               latitude_entree = "nb014jhgg01hhgff12hgff",
    //               userPointage = "",
    //               token = "",
    //               support = "",
    //               Statut = 1
    //           };
    //           Post(pointage);


    //       });

    //       barcodeReader.IsDetecting = false;
    //   }

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