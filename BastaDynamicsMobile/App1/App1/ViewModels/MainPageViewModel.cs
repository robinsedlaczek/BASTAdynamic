using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BastaDynamicBackendInterface;
using BastaDynamicsShared.Commands;

namespace BastaDynamicsShared
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CustomerProxy> AllCustomers { get; set; }

        public MainPageViewModel()
        {
            ReloadAllCustomers();
        }


        private void ReloadAllCustomers()
        {
            var customerOperations = new CustomerOperations();
            try
            {
                AllCustomers = new ObservableCollection<CustomerProxy>(customerOperations.GetAllCustomers().Result);
            }
            catch (Exception ex)
            {
                // log
            }
        }


        public ICommand CommandDeleteCustomer => new CommandDeleteCustomer();

        public ICommand CommandCreateCustomer => new CommandCreateCustomer();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
