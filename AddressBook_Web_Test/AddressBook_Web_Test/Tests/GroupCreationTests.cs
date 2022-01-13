using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupCreationTest : AuthTestBase
    {
        [Test]
        public void GroupCrationTest()
        {
            GroupData group = new GroupData("group 1", "1", "First Group");
            List<GroupData> oldGroups = application.Groups.GetGroupList();

            application.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, application.Groups.GetGroupCount());

            List<GroupData> newGroups = application.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCrationTest()
        {
            GroupData group = new GroupData("", "", "");
            List<GroupData> oldGroups = application.Groups.GetGroupList();

            application.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, application.Groups.GetGroupCount());

            List<GroupData> newGroups = application.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadGroupCrationTest()
        {
            GroupData group = new GroupData("a'a", "", "");
            List<GroupData> oldGroups = application.Groups.GetGroupList();

            application.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, application.Groups.GetGroupCount());

            List<GroupData> newGroups = application.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
