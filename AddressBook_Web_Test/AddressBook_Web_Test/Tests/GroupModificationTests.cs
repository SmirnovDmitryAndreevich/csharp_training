using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("New Group", null, "Change for Test");

            int indexToModify = 4;
            application.Groups.AddGroupIfNotPresent(indexToModify);
            application.Groups.Modify(indexToModify, newData);
        }
    }
}
