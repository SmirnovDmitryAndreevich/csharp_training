using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Ivan", "Ivanov");
            List<ContactData> oldContactList = application.Contacts.GetContactList();

            application.Contacts.Create(contact);

            Assert.AreEqual(oldContactList.Count + 1, application.Contacts.GetContactCount());

            List<ContactData> newContactList = application.Contacts.GetContactList();
            oldContactList.Add(contact);
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);

            application.Auth.Logout();
        }
    }
}