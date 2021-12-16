﻿using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Ivan", "Ivanov");
            application.Contacts.Create(contact);
            application.Auth.Logout();
        }
    }
}