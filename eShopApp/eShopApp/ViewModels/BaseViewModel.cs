using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace eShopApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;

            OnPropertyChanged(propertyName);
        }

        bool isLoading = false;

        public bool IsLoading
        {
            get => isLoading;

            set
            {
                if (isLoading != value)
                {
                    SetValue(ref isLoading, value);
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        }
    }
}
