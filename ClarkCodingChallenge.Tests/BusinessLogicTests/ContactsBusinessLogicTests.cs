using ClarkCodingChallenge.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClarkCodingChallenge.Tests.BusinessLogicTests
{
    [TestClass]
    public class ContactsBusinessLogicTests
    {
        private IContactsRepository _contactRepos;


        [TestMethod]
        public void TestMethod1()
        {
            _contactRepos = new ContactsRepository();

            _contactRepos.AddContact(new Models.Contact() { FirstName = "Alex", LastName = "Rod", Email = "test2@test.com" });

            var response = _contactRepos.GetContacts();

            //Assert
            Assert.AreEqual(response.Count, 2);
        }
    }
}
