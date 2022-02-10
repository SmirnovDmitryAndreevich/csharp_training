using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactInformationTests : ContactTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = application.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = application.Contacts.GetContactInformationFromEditForm();

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactInformationIcon()
        {
            string fromIcon = application.Contacts.GetContactInformationFromIcon(0);
            ContactData fromForm = application.Contacts.GetContactInformationFromEditForm();
            CollectionAssert.AreEqual(fromForm.AllData, fromIcon);
        }
    }
}
