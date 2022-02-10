using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("New Group", "Test", "Change for Test");
            application.Groups.AddGroupIfNotPresent();

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldGroupData = oldGroups[0];

            application.Groups.Modify(oldGroupData, newData);

            Assert.AreEqual(oldGroups.Count, application.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldGroupData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
