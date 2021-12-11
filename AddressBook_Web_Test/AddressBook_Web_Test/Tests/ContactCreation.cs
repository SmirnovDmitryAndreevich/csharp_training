using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            application.Navigator.OpenHomePage();
            application.Auth.Login(new AccountData("admin", "secret"));
            application.Navigator.GoToContactPage();
            application.Contacts.CreateContactInformation(new ContactData("Ivan", "Ivanov"));
            application.Navigator.GoToMainPage();
            application.Auth.Logout();
        }
    }
}