using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace AddressBook_Web_Test
{
    class RemovingContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            // For removing you must choose parameter "filterName". It can be name as name of group.
            string filterName = "name1";
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).First();

            application.Contacts.RemovingContactFromGroup(contact, filterName);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}