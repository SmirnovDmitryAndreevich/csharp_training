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
            int indexToBeRemove = 1;
            GroupData groups = GroupData.GetAll()[indexToBeRemove-1];
            List<ContactData> oldList = groups.GetContacts();
            ContactData contact = GroupData.GetAll()[indexToBeRemove - 1].GetContacts().First();

            application.Contacts.RemovingContactFromGroup(contact, groups);

            List<ContactData> newList = groups.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}