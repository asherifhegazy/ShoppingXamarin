using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eShopApp.iOS.Renderers;
using eShopApp.Renderers;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(Toast))]

namespace eShopApp.iOS.Renderers
{
    public class Toast : IToast
    {
        const double LONG_DELAY = 3.5;
        const double SHORT_DELAY = 2.0;

        NSTimer alertDelay;
        UIAlertController alert;

        public void ShowLongMessage(string message)
        {
            ShowAlert(message, LONG_DELAY);
        }

        public void ShowShortMessage(string message)
        {
            ShowAlert(message, SHORT_DELAY);
        }

        void ShowAlert(string message, double seconds)
        {
            var alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);

            var alertDelay = NSTimer.CreateScheduledTimer(seconds, obj =>
            {
                DismissMessage(alert, obj);
            });

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void DismissMessage(UIAlertController alert, NSTimer alertDelay)
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }

            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}