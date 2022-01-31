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
            int indexToRemove = 4;
            application.Groups.AddGroupIfNotPresent(indexToRemove);
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[indexToRemove];

            application.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, application.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(indexToRemove);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

            application.Auth.Logout();
        }
    }
}

