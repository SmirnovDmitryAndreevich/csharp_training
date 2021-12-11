using OpenQA.Selenium;

namespace AddressBook_Web_Test
{
    public class HelperBase
    {
        protected IWebDriver driver;
        
        public HelperBase (IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}