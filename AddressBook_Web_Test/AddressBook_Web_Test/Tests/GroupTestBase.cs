using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBook_Web_Test
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupUI_DB()
        {
            if(PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUI = application.Groups.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
