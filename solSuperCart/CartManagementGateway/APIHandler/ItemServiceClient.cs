using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CartManagementGateway.APIHandler
{ 
    public class ItemServiceClient : IItemServiceClient
    {
        private readonly HttpClient _httpClient; 
        private const string _remoteServiceBaseUrl = "http://localhost:57437/Catalog";
        public ItemServiceClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(_remoteServiceBaseUrl);
            httpClient.DefaultRequestHeaders.Add("Accept","application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent","HttpClientFactory-Sample");

            _httpClient = httpClient;
        }
        public async Task<IEnumerable<dynamic>> GetAllItems()
        {
            string apiPath = _remoteServiceBaseUrl + "/GetAllItems";
            var response = await _httpClient.GetAsync(apiPath);
            //
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
           
            return await JsonSerializer.DeserializeAsync<IEnumerable<dynamic>>(responseStream);
        }

        public async Task BlockItemsAsync()
        {
            var items = new List<int> { 1234 };
            var jsonItems = JsonSerializer.Serialize<List<int>>(items);
            var data = new StringContent(jsonItems, Encoding.UTF8, "application/json");

            
            string url = _remoteServiceBaseUrl + "/blockitem";
            var response =  _httpClient.PostAsync(url, data).Result;


            

        }
    }

}
