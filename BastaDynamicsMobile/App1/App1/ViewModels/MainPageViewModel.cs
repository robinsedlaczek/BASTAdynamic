using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using BastaDynamicsShared.Commands;

namespace BastaDynamicsShared
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public ICommand CommandDeleteCustomer => new CommandDeleteCustomer();

        public ICommand CommandCreateCustomer => new CommandCreateCustomer();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
