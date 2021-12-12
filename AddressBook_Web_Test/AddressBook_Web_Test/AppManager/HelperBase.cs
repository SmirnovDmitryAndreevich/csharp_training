using OpenQA.Selenium;

namespace AddressBook_Web_Test
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;
        
        public HelperBase (ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
    }
}