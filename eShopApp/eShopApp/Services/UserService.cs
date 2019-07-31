using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eShopApp.Models;
using Newtonsoft.Json;

namespace eShopApp.Services
{
    public class UserService : IUserService
    {
        HttpClient Client { get; set; }

        User User { get; set; } = new User();

        const string url = "Users/";

        public UserService()
        {
            Client = BaseHttpService.GetClient();
        }

        public async Task<int> GetUserIdByUsername(string username)
        {
            if(await IsUserExists(username))
                return User.Id;

            return -1;
        }

        public async Task<bool> IsUserExists(string username)
        {
            var response = await Client.GetAsync($"{url}/user/{username}");
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                User = JsonConvert.DeserializeObject<User>(message);

                return true;
            }

            return false;
        }
    }
}
