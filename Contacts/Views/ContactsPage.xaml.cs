using System;
using System.Collections.Generic;
using Contacts.ViewModels;
using Xamarin.Forms;

namespace Contacts.Views
{
    public partial class ContactsPage : ContentPage
    {
        ContactsVM viewModel;
        public ContactsPage()
        {
            InitializeComponent();
            viewModel = Resources["vm"] as ContactsVM;
            NavigationPage.SetHasBackButton(this, false);
            BindingContext = new ContactsVM(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ReadContacts();
        }

        public void UpdateListView()
        {
            viewModel.ReadContacts();
        }
    }
}
