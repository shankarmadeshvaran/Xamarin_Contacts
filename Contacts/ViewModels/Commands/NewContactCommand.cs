using System;
using System.Windows.Input;

namespace Contacts.ViewModels.Commands
{
    public class NewContactCommand : ICommand
    {
        private ContactsVM viewModel;

        public NewContactCommand(ContactsVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.NewContact();
        }
    }
}