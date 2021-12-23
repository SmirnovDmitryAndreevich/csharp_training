using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            application.Auth.Logout();

            AccountData account = new AccountData("admin", "secret");
            application.Auth.Login(account);
            Assert.IsTrue(application.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            application.Auth.Logout();

            AccountData account = new AccountData("admin", "nosecret");
            application.Auth.Login(account);
            Assert.IsFalse(application.Auth.IsLoggedIn(account));
        }
    }
}
