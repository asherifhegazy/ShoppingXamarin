using System;
using System.Collections.Generic;
using System.Text;

namespace eShopApp.ViewModels.Shared
{
    public class ActivityIndicatorViewModel : BaseViewModel
    {
        bool isIndicatorEnabled = false;

        public bool IsIndicatorEnabled
        {
            get => isIndicatorEnabled;

            set
            {
                if (isIndicatorEnabled != value)
                {
                    SetValue(ref isIndicatorEnabled, value);
                    OnPropertyChanged(nameof(IsIndicatorEnabled));
                }
            }
        }
    }
}
