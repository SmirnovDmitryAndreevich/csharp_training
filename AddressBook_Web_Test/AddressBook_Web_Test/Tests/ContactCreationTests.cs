using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 3; i ++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(15))
                {
                });
            }
            return contacts;
        }
        

        [Test, TestCaseSource("RandomContactProvider")]
        public void ContactCreationTest(ContactData contact)
        {
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