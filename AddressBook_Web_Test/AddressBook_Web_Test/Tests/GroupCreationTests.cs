using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupCreationTest : AuthTestBase
    {
        [Test]
        public void GroupCrationTest()
        {
            GroupData group = new GroupData("group 1", "1", "First Group");
            application.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCrationTest()
        {
            GroupData group = new GroupData("", "", "");
            application.Groups.Create(group);
        }
    }
}
