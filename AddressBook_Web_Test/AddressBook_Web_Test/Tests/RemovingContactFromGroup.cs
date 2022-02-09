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
            // For adding parameter "filterName" must be all.
            string filterName = "[all]";

            List<GroupData> groupList = GroupData.GetAll();
            List<ContactData> contactList = ContactData.GetAll();
            ContactData newcontact = new ContactData("FirstName", "LastName");
            GroupData newgroup = new GroupData("GroupName", "Header", "Footer");

            if (groupList.Count == 0)
            {
                application.Groups.Create(newgroup);
                if (contactList.Count == 0)
                {
                    application.Contacts.Create(newcontact);
                    GroupData group = GroupData.GetAll()[0];
                    List<ContactData> contactInGroup = group.GetContacts();
                    ContactData contact = ContactData.GetAll().Except(contactInGroup).First();
                    application.Contacts.AddContactToGroup(contact, group, filterName);
                }
            }
            else
            {
                if (contactList.Count == 0)
                {
                    application.Contacts.Create(newcontact);
                }
                GroupData group = GroupData.GetAll()[0];
                List<ContactData> contactInGroup = group.GetContacts();
                if (contactInGroup.Count == 0)
                {
                    ContactData contact = ContactData.GetAll().Except(contactInGroup).First();
                    application.Contacts.AddContactToGroup(contact, group, filterName);
                }
            }

            GroupData groupAfterVerify = GroupData.GetAll()[0];
            List<ContactData> oldList = groupAfterVerify.GetContacts();
            ContactData contactInGroupAfterVerify = GroupData.GetAll()[0].GetContacts().First();

            application.Contacts.RemovingContactFromGroup(contactInGroupAfterVerify, groupAfterVerify);

            List<ContactData> newList = groupAfterVerify.GetContacts();
            oldList.Remove(contactInGroupAfterVerify);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}