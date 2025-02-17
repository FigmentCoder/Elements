﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Elements.ViewModels
{
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = null!;

        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Initialize(object @object) { }
    }
}