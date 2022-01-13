using NUnit.Framework;
using System.Collections.Generic;

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
            List<GroupData> oldGroups = application.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[indexToRemove];

            application.Groups.Remove(indexToRemove);

            Assert.AreEqual(oldGroups.Count - 1, application.Groups.GetGroupCount());

            List<GroupData> newGroups = application.Groups.GetGroupList();

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

