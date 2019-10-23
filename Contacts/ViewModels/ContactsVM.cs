using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Contacts.Models;
using Contacts.ViewModels.Commands;
using Contacts.Views;
using Xamarin.Forms;

namespace Contacts.ViewModels
{
    public class ContactsVM : INotifyPropertyChanged
    {
        public ContactsPage ContactsPage { get; set; }

        public NewContactCommand NewContactCommand { get; set; }

        public ICommand OnCallClickedCommand { get; set; }

        public ICommand OnDeleteClickedCommand { get; set; }

        public ObservableCollection<Contact> Contacts { get; set; }

        public ContactsVM(ContactsPage _ContactsPage)
        {
            ContactsPage = _ContactsPage;

            OnCallClickedCommand = new Command<Contact>(CallContact);
            OnDeleteClickedCommand = new Command<Contact>(DeleteContactFromDetails);
        }
        public ContactsVM()
        {
            NewContactCommand = new NewContactCommand(this);

            Contacts = new ObservableCollection<Contact>();
            ReadContacts();
        }

        public async void DeleteContactFromDetails(Contact deleteContact)
        {
            var result = await ContactsPage.DisplayAlert("Alert!", "Are you sure you want to delete this contact?", "Yes", "No");
            if (result)
            {
                Contact.DeleteContactFromDB(deleteContact: deleteContact);
                ContactsPage.UpdateListView();
            }
        }

        public async void CallContact(Contact callingContact)
        {
            if (callingContact != null)
            {
                var message = callingContact.FullName + "\n" + callingContact.Phone;
                bool isCall = await ContactsPage.DisplayAlert("Do you really want to Call?", message, "Call", "Cancel");
                if (isCall)
                {
                    //Go to Contacts App
                    Device.OpenUri(new Uri("tel:" + callingContact.Phone));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void NewContact()
        {
            App.Current.MainPage.Navigation.PushAsync(new ContactDetailPage());
        }

        public void ReadContacts()
        {
            var contacts = Contact.GetContacts();
            Contacts.Clear();
            foreach (var contact in contacts)
            {
                Contacts.Add(contact);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
