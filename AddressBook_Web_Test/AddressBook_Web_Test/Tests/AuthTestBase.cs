using NUnit.Framework;

namespace AddressBook_Web_Test
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            application.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
