using System;
using System.Collections.Generic;
using System.Text;

namespace eShopApp
{
    public static class Global
    {
        private static bool IsPropertyExists(string key)
        {
            return App.Current.Properties.ContainsKey(key);
        }

        private static string GetProperty(string key)
        {
            if (IsPropertyExists(key))
            {
                return App.Current.Properties[key].ToString();
            }

            return null;
        }

        private static void SetProperty(string key, string value)
        {
            App.Current.Properties[key] = value;
            App.Current.SavePropertiesAsync();
        }

        public static string UserName
        {
            get
            {
                return GetProperty("Username");

            }
            set
            {
                SetProperty("Username", value);
            }
        }
    }
}
