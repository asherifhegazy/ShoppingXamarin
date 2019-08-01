using eShopApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eShopApp.Services
{
    public class OrderService : BaseService, IOrderService
    {
        const string url = "Orders";

        public async Task<bool> SubmitOrder(int uid)
        {
            var response = await Client.PostAsync($"{url}/{uid}", 
                new StringContent(
                    JsonConvert.SerializeObject(new CartItem()),
                    Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
