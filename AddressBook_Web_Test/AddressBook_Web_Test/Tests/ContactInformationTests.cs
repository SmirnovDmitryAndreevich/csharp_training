using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = application.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = application.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactInformationIcon()
        {
            ContactData fromIcon = application.Contacts.GetContactInformationFromIcon(0);
            ContactData fromForm = application.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromIcon, fromForm);
            Assert.AreEqual(fromIcon.Address, fromForm.Address);
            Assert.AreEqual(fromIcon.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromIcon.AllEmails, fromForm.AllEmails);
        }
    }
}
