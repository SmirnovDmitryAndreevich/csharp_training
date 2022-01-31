using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModifyTests()
        {
            int indexToModify = 1;
            ContactData name = new ContactData("Petr", "Petrov");
            application.Contacts.AddContactIfNotPresent(indexToModify);

            List<ContactData> oldContactList = ContactData.GetAll();

            application.Contacts.Modify(name,indexToModify);
            Assert.AreEqual(oldContactList.Count, application.Contacts.GetContactCount());

            List<ContactData> newContactList = ContactData.GetAll();
            oldContactList[indexToModify].Firstname = name.Firstname;
            oldContactList[indexToModify].Lastname = name.Lastname;
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);

            application.Auth.Logout();
        }
    }
}