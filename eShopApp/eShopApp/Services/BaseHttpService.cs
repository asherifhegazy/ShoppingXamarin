using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eShopApp.Services
{
    public static class BaseHttpService
    {
        const string BaseUrl = "https://eshopserviceahmed.azurewebsites.net/api/";

        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }


    }
}
