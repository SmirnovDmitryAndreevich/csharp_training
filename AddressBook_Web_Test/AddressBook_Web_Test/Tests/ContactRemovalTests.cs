using NUnit.Framework;

namespace AddressBook_Web_Test.Tests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            application.Contacts.Remove(1,2);
            application.Auth.Logout();
        }
    }
}