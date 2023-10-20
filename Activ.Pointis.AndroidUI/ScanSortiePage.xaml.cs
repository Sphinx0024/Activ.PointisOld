using Newtonsoft.Json;
using System.Text;
using ProjetScan.Model;
using System.Net.Http.Json;

namespace ProjetScan;

public partial class ScanSortiePage : ContentPage
{
    private long empID;
    private string donnees;
    public ScanSortiePage()
	{
		InitializeComponent();
	}



    /*public async void ValiderClick(object sender, EventArgs e)
    {
        /*DateTime maintenant = DateTime.Now;
        long idpoint = await PointageID();

        PointageModel pointage = new PointageModel
        {
            HeureSortie = maintenant,
            longitude_sortie = "nb014jhgg01hhgff12hgff",
            latitude_sortie = "nb014jhgg01hhgff12hgff"
        };

        await Put(empID, pointage);
        await Navigation.PushAsync(new MainPage());*/


    /*DateTime aujourdHui = DateTime.Today;
    string date = aujourdHui.ToString("D");*/

    /*var httpClientHandler = new HttpClientHandler();

    httpClientHandler.ServerCertificateCustomValidationCallback =
    (message, cert, chain, errors) => { return true; };
    HttpClient client = new HttpClient(httpClientHandler);

    HttpResponseMessage response = await client.GetAsync("https://face.activactions.net/api/Pointage/Get/5");

    if (response.IsSuccessStatusCode)
    {
        pointageModels = await response.Content.ReadFromJsonAsync<List<PointageModel>>();

        foreach( var pointageM in pointageModels)
        {
            model.EmployesID = pointageM.EmployesID;
            model.HeureEntree = pointageM.HeureEntree;
            model.HeureSortie = maintenant;
            model.Jour = pointageM.Jour;
        }
        await Put(empID,model);
    }

    /*PointageModel pointage = new PointageModel
    {
        Jour = maintenant,
        HeureEntree = heure,
        EmployesID = 1
    };*/

    //}

    public async Task FullPointage(long id)
    {
        long i = await PointageID(id);

        PointageModel pointage = new PointageModel
        {
            HeureSortie = DateTime.Now,
            longitude_sortie = "nb014jhgg01hhgff12hgff",
            latitude_sortie = "nb014jhgg01hhgff12hgff"
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
        var response = await client.PostAsync("https://face.activactions.net/api/Pointage/Modifier/" + id, content);

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

    private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
		 Dispatcher.Dispatch(() =>
		{ 
            var resultat = $"{e.Results[0].Value}";
            var separer = resultat.Split('#');
            empID = long.Parse(separer[0]);
            donnees = separer[2] + " " + separer[3] + " a été pointé avec succès";

            DateTime maintenant = DateTime.Now;
            FullPointage (empID);  //PointageID

            //PointageModel pointage = new PointageModel
            //{
            //    HeureSortie = maintenant,
            //    longitude_sortie = "nb014jhgg01hhgff12hgff",
            //    latitude_sortie = "nb014jhgg01hhgff12hgff"
            //};

            //await Put(idpoint, pointage);
            //barcodeReader.IsDetecting = false;

            //await Application.Current.MainPage.DisplayAlert("Success", donnees, "OK");
        });

        barcodeReader.IsDetecting = false;
    }



}