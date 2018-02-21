using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BastaDynamicsShared.Commands
{
    public class CommandDisplayNewCustomerDialog : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
