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
        }

        [TearDown]
        public void TeardownTest()
        {
            application.Stop();
        }
    }
}
