using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]
        public void GroupCrationTest()
        {
            application.Navigator.OpenHomePage();
            application.Auth.Login(new AccountData("admin","secret"));
            application.Navigator.GoToGroupPage();
            application.Groups.InitGroupCreation();
            application.Groups.FillGroupForm(new GroupData("group 1", "1", "First Group"));
            application.Groups.SubmitGroupCreation();
            application.Navigator.GoToGroupPage();
        }
    }
}
