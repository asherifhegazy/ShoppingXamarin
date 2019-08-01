using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using eShopApp.Renderers;

[assembly: Xamarin.Forms.Dependency(typeof(Toast))]

namespace eShopApp.Droid.Renderers
{
    public class Toast : IToast
    {
        public void ShowLongMessage(string message)
        {
            Android.Widget.Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShowShortMessage(string message)
        {
            Android.Widget.Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}