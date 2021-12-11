using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToContactPage();
            CreateContactInformation(new ContactData("Ivan", "Ivanov"));
            GoBackToMainPage();
            Logout();
        }
    }
}