using NUnit.Framework;

namespace AddressBook_Web_Test
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager application = ApplicationManager.GetInstance();
        }
    }
}
