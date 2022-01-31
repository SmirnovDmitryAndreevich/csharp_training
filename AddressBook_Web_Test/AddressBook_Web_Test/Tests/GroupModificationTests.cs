﻿using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int indexToModify = 4;
            GroupData newData = new GroupData("New Group", null, "Change for Test");
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[indexToModify];

            application.Groups.AddGroupIfNotPresent(indexToModify);
            application.Groups.Modify(indexToModify, newData);

            Assert.AreEqual(oldGroups.Count, application.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[indexToModify].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id ==oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
