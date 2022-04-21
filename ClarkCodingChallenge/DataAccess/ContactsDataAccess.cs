using System.Collections.Generic;
using ClarkCodingChallenge.Models;

namespace ClarkCodingChallenge.DataAccess
{
    public static class ContactsDataAccess
    {
        public static List<Contact> ContactList { get; set; }

        static ContactsDataAccess()
        {
            InitData();
        }

        private static void InitData()
        {
            ContactList = new List<Contact>();
            ContactList.Add(new Contact() { Id = 1, FirstName = "Bill", LastName = "Smith", Email = "test@test.com" });
        }
    }

    public class ContactsDataSource
    {
        public List<Contact> ContactList { get; set; }

        ContactsDataSource()
        {
            InitData();
        }

        private void InitData()
        {
            //ContactList from date source
        }
    }
}
