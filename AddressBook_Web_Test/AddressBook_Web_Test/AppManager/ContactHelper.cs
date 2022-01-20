using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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
            SelectContactToRemove(row);
            RemoveContacts(nubmerofindex);
            manager.Navigator.GoToMainPage();
            return this;
        }

        public ContactHelper Modify(ContactData name, int row)
        {
            manager.Navigator.GoToMainPage();
            SelectContactToChange(row);
            ModifyContact(name);
            SubmitContactModify();
            manager.Navigator.GoToMainPage();
            return this;
        }

        public void CreateContactInformation(ContactData name)
        {
            driver.FindElement(By.Name("firstname")).Click();
            Type(By.Name("firstname"), name.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys("Ivanovich");
            Type(By.Name("lastname"), name.Lastname);
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

            contactCache = null;
        }

        public ContactHelper SubmitContactModify()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ModifyContact(ContactData name)
        {
            driver.FindElement(By.Name("firstname")).Click();
            Type(By.Name("firstname"), name.Firstname);
            Type(By.Name("lastname"), name.Lastname);
            return this;
        }

        public ContactHelper SelectContactToChange(int row)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[" + (row+2) + "]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SelectContactToRemove(int row)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[" + (row+2) + "]/ td")).Click();
            return this;
        }

        public ContactHelper RemoveContacts(int nubmerofindex)
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete " + (nubmerofindex) + " addresses[\\s\\S]$"));
            contactCache = null;
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
            while (!IsElementPresent(By.XPath("//tr[" + (index + 2) + "]/td/input")))
            {
                Create(new ContactData("Eric", "Cartman"));
                manager.Navigator.GoToMainPage();
            }
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            manager.Navigator.GoToMainPage();
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToMainPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> row = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(row[2].Text, row[1].Text));
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            manager.Navigator.GoToMainPage();
            return driver.FindElements(By.CssSelector("[name='entry']")).Count;
        }

        public ContactData GetContactInformationFromTable(int row)
        {
            manager.Navigator.GoToMainPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[row].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhone = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhone,
                AllEmails = allEmails
            };

        }

        public ContactData GetContactInformationFromIcon(int row)
        {
            manager.Navigator.GoToMainPage();
            SelectPersonalDetails(row);

            string[] info = driver.FindElement(By.CssSelector("div#content")).Text.Split('\r', '\n');
            string[] allName = info[0].Split(' ');
            string firstname = allName[0];
            string lastname = allName[2];
            string address = info[8];

            string homePhone = Regex.Replace(info[12], @"[()H: -]", "");
            string mobilePhone = Regex.Replace(info[14], @"[()M: -]", "");
            string workPhone = Regex.Replace(info[16], @"[()W: -]", "");
            string secondaryphone = Regex.Replace(info[40], @"[()P: -]", "");
            string allPhone = $"{homePhone}\r\n{mobilePhone}\r\n{workPhone}\r\n{secondaryphone}";

            string firstemail = info[20];
            string sencondemail = info[22];
            string thirdemail = info[24];
            string allEmails = $"{firstemail}\r\n{sencondemail}\r\n{thirdemail}";

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhone,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToMainPage();
            SelectContactToChange(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string secondaryphone = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string firstemail = driver.FindElement(By.Name("email")).GetAttribute("value");
            string secondemail = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string thirdemail = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                SecondaryPhone = secondaryphone,
                FirstEmail = firstemail,
                SecondEmail = secondemail,
                ThirdEmail = thirdemail
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToMainPage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public ContactHelper SelectPersonalDetails(int row)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[" + (row + 2) + "]/td[7]/a/img")).Click();
            return this;
        }
    }
}