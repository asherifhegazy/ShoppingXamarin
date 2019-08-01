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

        private static object GetProperty(string key)
        {
            if (IsPropertyExists(key))
            {
                return App.Current.Properties[key];
            }

            return null;
        }

        private static void SetProperty(string key, object value)
        {
            App.Current.Properties[key] = value;
            App.Current.SavePropertiesAsync();
        }

        public static object UserName
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

        public static object FilterMinPrice
        {
            get
            {
                return GetProperty("FilterMinPrice");

            }
            set
            {
                SetProperty("FilterMinPrice", value);
            }
        }

        public static object FilterMaxPrice
        {
            get
            {
                return GetProperty("FilterMaxPrice");

            }
            set
            {
                SetProperty("FilterMaxPrice", value);
            }
        }
    }
}
