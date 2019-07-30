using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using eShopApp.Models;

namespace eShopApp.Services
{
    public class UserService : IUserService
    {
        IList<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                Username = "ahmed"
            },
            new User
            {
                Id = 2,
                Username = "basma"
            },
            new User
            {
                Id = 3,
                Username = "youssef"
            }
        };

        public int GetUserIdByUsername(string username)
        {
            return Users.SingleOrDefault(u => u.Username == username).Id;
        }

        public IList<User> GetUsers()
        {
            return Users;
        }

        public bool IsUserExists(string username)
        {
            return Users.Any(u=>u.Username == username);
        }
    }
}
