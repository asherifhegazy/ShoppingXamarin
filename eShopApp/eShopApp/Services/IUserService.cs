using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopApp.Services
{
    public interface IUserService
    {
        IList<User> GetUsers();

        bool IsUserExists(string username);
    }
}
