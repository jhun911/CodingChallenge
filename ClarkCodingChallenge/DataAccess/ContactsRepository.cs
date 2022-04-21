using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClarkCodingChallenge.Models;

namespace ClarkCodingChallenge.DataAccess
{
    public interface IContactsRepository
    {
        List<Contact> GetContacts();
        Contact GetContact(int id);
        void AddContact(Contact contact);
    }

    public class ContactsRepository : IContactsRepository
    {
        public List<Contact> GetContacts()
        {
            return ContactsDataAccess.ContactList.ToList();
        }

        public Contact GetContact(int id)
        {
            Contact contact = ContactsDataAccess.ContactList.Where(c => c.Id == id).FirstOrDefault();
            return contact;
        }

        public void AddContact(Contact contact)
        {
            int nextAvailableId = ContactsDataAccess.ContactList.Count + 1;
            contact.Id = nextAvailableId;
            ContactsDataAccess.ContactList.Add(contact);
        }
    }
}
