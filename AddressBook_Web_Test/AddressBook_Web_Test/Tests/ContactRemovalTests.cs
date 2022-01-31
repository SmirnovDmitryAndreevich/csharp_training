﻿using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int indexToRemove = 0;
            application.Contacts.AddContactIfNotPresent(indexToRemove);
            List<ContactData> oldContactList = ContactData.GetAll();

            application.Contacts.Remove(1,indexToRemove);

            Assert.AreEqual(oldContactList.Count - 1, application.Contacts.GetContactCount());

            List<ContactData> newContactList = ContactData.GetAll();
            oldContactList.RemoveAt(indexToRemove);
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);

            application.Auth.Logout();
        }
    }
}