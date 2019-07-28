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
        ObservableCollection<User> Users = new ObservableCollection<User>
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

        public ICollection<User> GetUsers()
        {
            return Users;
        }

        public bool IsUserExists(string username)
        {
            return Users.Any(u=>u.Username == username);
        }
    }
}
