using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]
        public void GroupCrationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(new GroupData("group 1", "1", "First Group"));
            SubmitGroupCreation();
            GoToGroupPage();
        }
    }
}
