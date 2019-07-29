﻿using eShopApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace eShopApp.Services
{
    public interface IUserService
    {
        ObservableCollection<User> GetUsers();

        bool IsUserExists(string username);
    }
}
