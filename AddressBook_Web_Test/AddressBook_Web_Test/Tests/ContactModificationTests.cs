﻿using NUnit.Framework;

namespace AddressBook_Web_Test.Tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModifyTests()
        {
            ContactData name = new ContactData("Petr", "Petrov");

            application.Contacts.Modify(name,2);
            application.Auth.Logout();
        }
    }
}