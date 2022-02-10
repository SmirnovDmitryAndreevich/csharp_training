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
            application.Contacts.AddContactIfNotPresent();

            List<ContactData> oldContactList = ContactData.GetAll();
            ContactData oldContactData = oldContactList[indexToModify-1];

            application.Contacts.Modify(oldContactData, name);
            Assert.AreEqual(oldContactList.Count, application.Contacts.GetContactCount());

            List<ContactData> newContactList = ContactData.GetAll();
            oldContactList[indexToModify-1].Firstname = name.Firstname;
            oldContactList[indexToModify-1].Lastname = name.Lastname;

            oldContactList.Sort();
            newContactList.Sort();
                
            Assert.AreEqual(oldContactList, newContactList);

            foreach (var contact in newContactList)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual($"{name.Lastname} {name.Firstname}", $"{contact.Lastname} {contact.Firstname}");
                }
            }
        }
    }
}