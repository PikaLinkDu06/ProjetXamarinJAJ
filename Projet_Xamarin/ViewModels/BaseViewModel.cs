using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Projet_Xamarin.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool isBusy;
        public bool IsBusy { get { return isBusy; } set { SetProperty(ref isBusy, value); } }
        public bool IsNotBusy { get { return !isBusy ; } set { OnPropertyChanged(nameof(IsNotBusy)) ; } }
        protected void OnPropertyChanged(string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null) return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) 
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
