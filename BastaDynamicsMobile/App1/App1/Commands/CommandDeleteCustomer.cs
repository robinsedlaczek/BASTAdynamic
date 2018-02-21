using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BastaDynamicsShared.Commands
{
    class CommandDeleteCustomer : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // BackendDataProvider.DeleteCustomer();
        }

        public event EventHandler CanExecuteChanged;
    }
}
