using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook_Web_Test
{
    class AddingContactToGroupTest : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            // For adding parameter "filterName" must be all.
            string filterName = "[all]";
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            application.Contacts.AddContactToGroup(contact, group, filterName);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
