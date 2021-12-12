using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            application.Groups.Remove(1);
            application.Auth.Logout();
        }
    }
}

