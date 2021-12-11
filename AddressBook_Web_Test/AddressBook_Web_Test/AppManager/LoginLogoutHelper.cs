using OpenQA.Selenium;

namespace AddressBook_Web_Test
{
    public class LoginLogoutHelper : HelperBase
    {
        public LoginLogoutHelper(IWebDriver driver)
            : base(driver)
        {
        }

        public void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();
            driver.FindElement(By.XPath("//div[@id='header']/a")).Click();
        }
        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
