using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;

namespace AddressBook_Web_Test
{
    public class ContactHelper : HelperBase
    {
        private bool acceptNextAlert;

        public ContactHelper(ApplicationManager manager, bool acceptNextAlert) : base(manager)
        {
            this.acceptNextAlert = acceptNextAlert;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactPage();
            CreateContactInformation(contact);
            manager.Navigator.GoToMainPage();
            return this;
        }

        public ContactHelper Remove(int nubmerofindex, int row)
        {
            manager.Navigator.GoToMainPage();
            SelectContactToRemove(row.ToString());
            RemoveContacts(nubmerofindex);
            manager.Navigator.GoToMainPage();
            return this;
        }

        public ContactHelper Modify(ContactData name, int row)
        {
            manager.Navigator.GoToMainPage();
            SelectContactToChange(row.ToString());
            ModifyContact(name);
            SubmitContactModify();
            manager.Navigator.GoToMainPage();
            return this;
        }

        public void CreateContactInformation(ContactData name)
        {
            driver.FindElement(By.Name("firstname")).Click();
            Type(By.Name("firstname"), name.Firstname);
            Type(By.Name("middlename"), name.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys("Ivanovich");
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys("Iva");
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys("Empty");
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys("Avrora");
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys("Saint-Petersburg, st. Pionerskay 10");
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys("-");
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys("010101");
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys("-");
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys("-");
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("avrora.com");
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys("-");
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys("-");
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys("-");
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("iva.com");
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("1");
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("January");
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys("1864");
            driver.FindElement(By.Name("new_group")).Click();
            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByIndex(0);
            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys("Nothing to say");
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys("Street is my home");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys("Hello world");
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }

        public ContactHelper SubmitContactModify()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper ModifyContact(ContactData name)
        {
            driver.FindElement(By.Name("firstname")).Click();
            Type(By.Name("firstname"), name.Firstname);
            Type(By.Name("middlename"), name.Middlename);
            return this;
        }

        public ContactHelper SelectContactToChange(string row)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{row}]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SelectContactToRemove(string row)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{row}]/td")).Click();
            return this;
        }

        public ContactHelper RemoveContacts(int nubmerofindex)
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete " + nubmerofindex + " addresses[\\s\\S]$"));
            return this;
        }
        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        public void AddContactIfNotPresent(int index)
        {
            while (!IsElementPresent(By.XPath($"//table[@id='maintable']/tbody/tr[{index + 1}]/td")))
            {
                Create(new ContactData("Eric", "Cartman"));
                manager.Navigator.GoToMainPage();
            }
        }
    }
}