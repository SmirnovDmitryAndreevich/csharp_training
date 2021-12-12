using NUnit.Framework;

namespace AddressBook_Web_Test
{
    public class TestBase
    {
        protected ApplicationManager application;

        [SetUp]
        public void SetupTest()
        {
            application = new ApplicationManager();
            application.Navigator.OpenHomePage();
            application.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            application.Stop();
        }
    }
}
