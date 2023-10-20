using Newtonsoft.Json;
using ProjetScan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetScan.Services.Employes
{
    public class EmployesService : EmployesRepository
    {
        public static readonly string lien = "https://face.activactions.net/api/";
        public async Task<bool> DeleteEmployes(long EmployesID)
        {
            HttpClient client = new HttpClient();
            string url = lien + "/Employes/Delete/" +EmployesID;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.DeleteAsync("");

            if (responseMessage.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }

            else
            {
                return await Task.FromResult(false);
            }
        }

        public Task<IEnumerable<EmployesModel>> DeleteEmployes()
        {
            throw new NotImplementedException();
        }

        public Task<EmployesModel> GetEmployes(long EmployesID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployesModel>> GetEmployes()
        {
            var EmployesList = new List<EmployesModel>();
            HttpClient client = new HttpClient();
            string url = lien + "/Employes/Get";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync("");

            if (responseMessage.IsSuccessStatusCode)
            {
                EmployesList = await responseMessage.Content.ReadFromJsonAsync<List<EmployesModel>>();
            }
            return await Task.FromResult(EmployesList);
        }

        public async Task<bool> SaveEmployes(EmployesModel employesModel)
        {
            string json = JsonConvert.SerializeObject(employesModel);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8,"Application/json");

            HttpClient client = new HttpClient();
            string url = lien + "/Employes/Post";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.PostAsync("", content);
            
            if(responseMessage.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }

            else
            {
                return await Task.FromResult(false);
            }

            //return await Task.FromResult(true);
        }
    }
}
