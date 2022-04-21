using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClarkCodingChallenge.Controllers;

namespace ClarkCodingChallenge.Tests.ControllerTest
{
    [TestClass]
    public class ContactsControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new ContactsController();

            // Act
            IActionResult response = controller.Index();

            // Assert
            Assert.IsInstanceOfType(response, typeof(ViewResult));
        }
    }
}
