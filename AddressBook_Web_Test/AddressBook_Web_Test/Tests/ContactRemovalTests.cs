using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int indexToRemove = 1;
            application.Contacts.AddContactIfNotPresent(indexToRemove);
            List<ContactData> oldContactList = ContactData.GetAll();
            ContactData contactToRemove = oldContactList[indexToRemove-1];

            application.Contacts.Remove(contactToRemove);

            Assert.AreEqual(oldContactList.Count - 1, application.Contacts.GetContactCount());
            oldContactList.Remove(contactToRemove);
            List<ContactData> newContactList = ContactData.GetAll();
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);

            foreach (var contact in newContactList)
            {
                Assert.AreNotEqual(contact.Id, contactToRemove.Id);
            }
        }
    }
}