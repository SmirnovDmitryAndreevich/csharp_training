using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressBook_Web_Test
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected bool acceptNextAlert;

        protected LoginLogoutHelper loginLogoutHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook";
            acceptNextAlert = true;

            loginLogoutHelper = new LoginLogoutHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this, acceptNextAlert);
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginLogoutHelper Auth
        {
            get
            {
                return loginLogoutHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }
    }
}
