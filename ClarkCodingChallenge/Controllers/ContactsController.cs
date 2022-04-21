using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.DataAccess;
using System.Text.RegularExpressions;

namespace ClarkCodingChallenge.Controllers
{
    public class ContactsController : Controller
    {
        private ContactsRepository _contactsRepository = null;

        public ContactsController()
        {
            _contactsRepository = new ContactsRepository();
        }

        public IActionResult Index()
        {
            List<Contact> contactList = _contactsRepository.GetContacts();

            return View(contactList);
        }

        public ActionResult Add()
        {
            var Contact = new Contact();

            return View(Contact);
        }

        [HttpPost]
        public ActionResult Add(Contact contact)
        {
            if (ValidateContact(contact))
            {
                _contactsRepository.AddContact(contact);

                TempData["Message"] = "Your contact was successfully added!";

                return RedirectToAction("Index");
            }

            return View(contact);
        }

        [HttpGet]
        public ActionResult GetAllContact()
        {
            List<Contact> contactList = _contactsRepository.GetContacts();
            contactList.Sort((x, y) => x.LastName.CompareTo(y.LastName) == 0 ? x.FirstName.CompareTo(y.FirstName) : x.LastName.CompareTo(y.LastName));

            return Ok(contactList);
        }

        [HttpGet("Contacts/GetAllContact/{lastName}/{order}")]
        public ActionResult GetAllContact(string lastName, string order)
        {
            List<Contact> contactList = _contactsRepository.GetContacts();
            contactList.Sort((x, y) => x.LastName.CompareTo(y.LastName) == 0 ? x.FirstName.CompareTo(y.FirstName) : x.LastName.CompareTo(y.LastName));
            if (lastName != "")
                contactList = contactList.Where(c => c.LastName == lastName).ToList();
            if (order == "Descending")
                contactList.Sort((y, x) => x.LastName.CompareTo(y.LastName) == 0 ? x.FirstName.CompareTo(y.FirstName) : x.LastName.CompareTo(y.LastName));

            return Ok(contactList);
        }


        private bool ValidateContact(Contact contact)
        {
            bool valid = true;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            bool IsEmail = false;
            if(contact.Email != null && contact.Email.Length > 0)
            {
                Match match = regex.Match(contact.Email);
                if(match.Success)
                    IsEmail = true;
            }

            if (contact.FirstName == null || contact.FirstName.Length == 0)
            {
                valid = false;
                ModelState.AddModelError("FirstName", "The First Name length must be greater than 0.");
            }

            if (contact.LastName == null || contact.LastName.Length == 0)
            {
                valid = false;
                ModelState.AddModelError("LastName", "The Last Name length must be greater than 0.");
            }

            if (!IsEmail)
            {
                valid = false;
                ModelState.AddModelError("Email", "The Email length must be valid.");
            }

            return valid;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
