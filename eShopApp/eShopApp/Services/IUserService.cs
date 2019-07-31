using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopApp.Services
{
    public interface IUserService
    {
        Task<bool> IsUserExists(string username);

        Task<int> GetUserIdByUsername(string username);
    }
}
