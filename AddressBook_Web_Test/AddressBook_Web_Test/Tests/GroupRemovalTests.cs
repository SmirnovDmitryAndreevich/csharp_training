using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int indexToRemove = 4;
            application.Groups.AddGroupIfNotPresent(indexToRemove);
            application.Groups.Remove(indexToRemove);
            application.Auth.Logout();
        }
    }
}

