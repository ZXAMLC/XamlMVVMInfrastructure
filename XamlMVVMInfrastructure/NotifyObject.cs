using System;
using System.ComponentModel;

namespace Infrastructure
{
    public abstract class NotifyObject : INotifyPropertyChanged
    {
        ~NotifyObject()
        {
            PropertyChanged = null;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetPropertyNotify<T>(ref T storage, T value, string propertyName)
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected bool SetPropertyNotNotify<T>(ref T storage, T value, string propertyName)
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}