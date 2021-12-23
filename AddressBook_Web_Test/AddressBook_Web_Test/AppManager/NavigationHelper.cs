using OpenQA.Selenium;

namespace AddressBook_Web_Test
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupPage()
        {
            if (driver.Url == baseURL + "/group.php"
                && IsElementPresent(By.Name("new)")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactPage()
        {
            if (driver.Url == baseURL + "/edit.php"
            && IsElementPresent(By.Name("firstname")))
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void GoToMainPage()
        {
            if (driver.Url == baseURL && IsElementPresent(By.Name("MainForm")))
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
