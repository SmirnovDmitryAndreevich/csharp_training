using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int indexToRemove = 3;
            application.Contacts.AddContactIfNotPresent(indexToRemove);
            application.Contacts.Remove(1,indexToRemove);
            application.Auth.Logout();
        }
    }
}