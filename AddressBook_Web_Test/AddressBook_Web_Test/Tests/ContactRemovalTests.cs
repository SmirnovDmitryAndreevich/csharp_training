using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            application.Contacts.Remove(1,2);
            application.Auth.Logout();
        }
    }
}