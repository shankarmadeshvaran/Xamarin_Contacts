using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace Contacts.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }

        public string UserId { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        public string Company { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string Email { get; set; }

        public string JobTitle { get; set; }

        public string Phone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string PhotoUrl { get; set; }

        public string State { get; set; }

        public string FullName => FirstName + " " + LastName;

        public string Address => Street + "," + City + "," + PostalCode + "," + State;

        public bool InsertContacts()
        {
            int insertedItems = 0;
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                insertedItems = connection.Insert(this);
            }
            return insertedItems > 0;
        }

        public static void DeleteContactFromDB(Contact deleteContact)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.Query<Contact>("DELETE FROM [Contact] WHERE [UserId] = " + deleteContact.UserId);
                Console.WriteLine("Total Contacts in DB"+ GetContactsCount());
            }
        }

        public static List<Contact> GetContacts()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Contact>();
                return conn.Table<Contact>().ToList();
            }
        }

        public static int GetContactsCount()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                Console.WriteLine(connection.Table<Contact>().Count());
                return connection.Table<Contact>().Count();
            }
        }
    }
}
