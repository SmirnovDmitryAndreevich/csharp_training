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

        public void RemovingContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToMainPage();
            SelectGroupInFilter(group.Name);
            SelectContactToAddToGroup(contact.Id);
            CommitToRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitToRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }
        private void SelectGroupInFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void AddContactToGroup(ContactData contact, GroupData group, string filtername)
        {
            manager.Navigator.GoToMainPage();
            GroupFilter(filtername);
            SelectContactToAddToGroup(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitToAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitToAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void SelectContactToAddToGroup(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void GroupFilter(string filterName)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(filterName);
        }

        public ContactHelper Remove(int nubmerofindex, int row)
        {
            manager.Navigator.GoToMainPage();
            SelectContactToRemove(row);
            RemoveContacts(nubmerofindex);
            manager.Navigator.GoToMainPage();
            return this;
        }

        public ContactHelper Remove(int nubmerofindex, ContactData contact)
        {
            manager.Navigator.GoToMainPage();
            SelectContactToRemove(contact.Id);
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
        
        internal ContactHelper Modify(ContactData contact, ContactData name)
        {
            manager.Navigator.GoToMainPage();
            SelectContactToChange(contact.Id);
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

        private ContactHelper SelectContactToChange(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='" + id + "']")).FindElement(By.XPath("//img[@alt='Edit']")).Click();

            return this;
        }

        public ContactHelper SelectContactToRemove(int row)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[" + (row+2) + "]/ td")).Click();
            return this;
        }

        private ContactHelper SelectContactToRemove(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='" + id + "']")).Click();
            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='" + id + "']")).Click();
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

        public string GetContactInformationFromIcon(int row)
        {
            manager.Navigator.GoToMainPage();
            SelectPersonalDetails(row);

            string allDetailsFromIcon = driver.FindElement(By.XPath("//div[@id='content']")).Text;
            return allDetailsFromIcon;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToMainPage();
            SelectContactToChange(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string firstemail = driver.FindElement(By.Name("email")).GetAttribute("value");
            string secondemail = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string thirdemail = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.XPath("//div[@id='content']/form/select[2]/option[1]")).Text;
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string amonth = driver.FindElement(By.XPath("//div[@id='content']/form/select[4]/option[1]")).Text;
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).Text;
            string secondaryphone = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).Text;

            return new ContactData(firstName.Trim(), lastName.Trim())
            {
                MiddleName = middleName,
                Nickname = nickName,
                Company = company,
                Title = title,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                FirstEmail = firstemail,
                SecondEmail = secondemail,
                ThirdEmail = thirdemail,
                Homepage = homepage,
                BDay = bday,
                BMonth = bmonth,
                BYear = byear,
                ADay = aday,
                AMonth = amonth,
                AYear = ayear,
                Address2 = address2,
                SecondaryPhone = secondaryphone,
                Notes = notes
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