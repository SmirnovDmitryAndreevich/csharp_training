using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModifyTests()
        {
            ContactData name = new ContactData("Petr", "Petrov");

            int indexToModify = 3;
            application.Contacts.AddContactIfNotPresent(indexToModify);
            application.Contacts.Modify(name,indexToModify);
            application.Auth.Logout();
        }
    }
}