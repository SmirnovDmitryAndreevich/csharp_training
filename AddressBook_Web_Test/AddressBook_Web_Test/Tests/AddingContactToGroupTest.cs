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

            List<GroupData> groupList = GroupData.GetAll();
            List<ContactData> contactList = ContactData.GetAll();
            ContactData newcontact = new ContactData("FirstName", "LastName");
            GroupData newgroup = new GroupData("GroupName", "Header", "Footer");

            if (groupList.Count == 0)
            {
                application.Groups.Create(newgroup);
                if(contactList.Count == 0)
                {
                    application.Contacts.Create(newcontact);
                }
            }
            else
            {
                if (contactList.Count == 0)
                {
                    application.Contacts.Create(newcontact);
                }
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            if (oldList.SequenceEqual(ContactData.GetAll()))
            {
                application.Contacts.Create(newcontact);
            }

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
