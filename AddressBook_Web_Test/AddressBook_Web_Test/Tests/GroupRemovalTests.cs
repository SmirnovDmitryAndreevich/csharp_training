using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            application.Groups.AddGroupIfNotPresent();

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            application.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, application.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}

