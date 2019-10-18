using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contacts.Views;

namespace Contacts
{
    public partial class App : Application
    {
        public static string DatabasePath;

        public App(string databasePath)
        {
            InitializeComponent(); 
            DatabasePath = databasePath;

            MainPage = new NavigationPage(new ContactsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
