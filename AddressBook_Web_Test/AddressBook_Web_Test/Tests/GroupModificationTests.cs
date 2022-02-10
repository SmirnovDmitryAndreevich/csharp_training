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
            int indexToModify = 3;
            GroupData newData = new GroupData("New Group", "Test", "Change for Test");
            application.Groups.AddGroupIfNotPresent(indexToModify);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldGroupData = oldGroups[indexToModify-1];

            application.Groups.Modify(oldGroupData, newData);

            Assert.AreEqual(oldGroups.Count, application.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[indexToModify].Name = newData.Name;
            //oldGroups.Sort();
            //newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (var group in newGroups)
            {
                if (group.Id == oldGroupData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
