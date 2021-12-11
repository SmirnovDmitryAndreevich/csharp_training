using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            application.Navigator.OpenHomePage();
            application.Auth.Login(new AccountData("admin","secret"));
            application.Navigator.GoToGroupPage();
            application.Groups.SelectGroup(1);
            application.Groups.RemoveGroup();
            application.Navigator.GoToGroupPage();
            application.Auth.Logout();
        }
    }
}

