using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Contacts.Models;
using Xamarin.Forms;

namespace Contacts.ViewModels
{
    public class ContactDetailVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public String[] profileImage = { "profile01.png", "profile02.png", "profile03.png", "profile04.png",
                                  "profile05.png", "profile06.png", "profile07.png", "profile01.png",
                                  "profile02.png", "profile03.png"
        };

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string userId;
        private string firstname;
        private string lastName;
        private string company;
        private string email;
        private string jobTitle;
        private string phone;
        private string street;
        private string city;
        private string postalCode;
        private string state;

        public string UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
                OnPropertyChanged("CanSave");
            }
        }
        public string FirstName
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged("FirstName");
                OnPropertyChanged("FullName");
                OnPropertyChanged("CanSave");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
                OnPropertyChanged("FullName");
            }
        }
        
        public string Company
        {
            get { return company; }
            set {
                company = value;
                OnPropertyChanged("Company");
            }
        }

        public string Email
        {
            get { return email; }
            set {
                email = value;
                OnPropertyChanged("Email");
                OnPropertyChanged("CanSave");
            }
        }

        public string JobTitle
        {
            get { return jobTitle; }
            set {
                jobTitle = value;
                OnPropertyChanged("JobTitle");
            }
        }

        public string Phone
        {
            get { return phone; }
            set {
                phone = value;
                OnPropertyChanged("Phone");
                OnPropertyChanged("CanSave");
            }
        }

        public string Street
        {
            get { return street; }
            set {
                street = value;
                OnPropertyChanged("Street");
                OnPropertyChanged("Address");
            }
        }

        public string City
        {
            get { return city; }
            set {
                city = value;
                OnPropertyChanged("City");
                OnPropertyChanged("Address");
            }
        }

        public string PostalCode
        {
            get { return postalCode; }
            set {
                postalCode = value;
                OnPropertyChanged("PostalCode");
                OnPropertyChanged("Address");
            }
        }

        public string PhotoUrl { get; set; }

        public string State
        {
            get { return state; }
            set {
                state = value;
                OnPropertyChanged("State");
                OnPropertyChanged("Address");
            }
        }

        public string FullName => FirstName + " " + LastName;
        public string Address => Street + "," + City + "," + PostalCode + "," + State;

        public ObservableCollection<Contact> Contacts { get; set; }

        public ICommand SaveCommand { get; set; }

        public ContactDetailVM()
        {
            SaveCommand = new Command<bool>(SaveAction, CanExecuteSave);
        }

        public bool CanSave
        {
            get {
                return !string.IsNullOrWhiteSpace(FirstName) &&
                    !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Phone);
            }
        }

        bool CanExecuteSave(bool arg)
        {
            return arg;
        }

        void SaveAction(bool obj)
        {
            Contact newExperience = new Contact()
            {
                UserId = UserId,
                FirstName = FirstName,
                LastName = LastName,
                Company = Company,
                Email = Email,
                JobTitle = JobTitle,
                Phone = Phone,
                Street = Street,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                City = City,
                PostalCode = PostalCode,
                State = State,
                PhotoUrl = profileImage[Contact.GetContactsCount() % 10]
            };

            bool insertSuccessful = newExperience.InsertContacts();

            if (insertSuccessful)
            {
                FirstName = string.Empty;
                LastName = string.Empty;
                Company = string.Empty;
                Email = string.Empty;
                JobTitle = string.Empty;
                Phone = string.Empty;
                City = string.Empty;
                PostalCode = string.Empty;
                State = string.Empty;
                App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "There was an error inserting the Experience, please try again", "Ok");
            }
        }
    }
}
