using System;
using System.Collections.Generic;
using System.Text;

namespace eShopApp.Renderers
{
    public interface IToast
    {
        void ShowShortMessage(string message);
        void ShowLongMessage(string message);
    }
}
