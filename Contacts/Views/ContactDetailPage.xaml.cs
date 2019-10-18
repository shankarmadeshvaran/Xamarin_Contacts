using System;
using System.Collections.Generic;
using Contacts.ViewModels;
using Xamarin.Forms;

namespace Contacts.Views
{
    public partial class ContactDetailPage : ContentPage
    {
        ContactDetailVM viewModel;

        public ContactDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            viewModel = new ContactDetailVM();
            BindingContext = viewModel;
        }
    }
}
