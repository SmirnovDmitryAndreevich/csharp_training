using NUnit.Framework;

namespace AddressBook_Web_Test
{
    public class TestBase
    {
        protected ApplicationManager application;

        [SetUp]
        public void SetupApplicationManager()
        {
            application = ApplicationManager.GetInstance();
            application.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
