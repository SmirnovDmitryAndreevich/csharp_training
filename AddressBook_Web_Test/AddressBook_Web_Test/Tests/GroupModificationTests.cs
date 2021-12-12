using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("New Group", "Change Group", "Change for Test");
            application.Groups.Modify(1, newData);
        }
    }
}
