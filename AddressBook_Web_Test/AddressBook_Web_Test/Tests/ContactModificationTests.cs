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

            application.Contacts.Modify(name,2);
            application.Auth.Logout();
        }
    }
}