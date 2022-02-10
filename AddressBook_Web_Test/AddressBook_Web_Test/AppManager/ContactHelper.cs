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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToMainPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
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
        public ContactData GetContactInformationFromEditForm()
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

        public string GetContactInformationFromIcon(int row)
        {
            manager.Navigator.GoToMainPage();
            SelectPersonalDetails(row);

            string allDetailsFromIcon = driver.FindElement(By.XPath("//div[@id='content']")).Text;
            return allDetailsFromIcon;
        }


        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactPage();
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContacCreation();
            manager.Navigator.GoToMainPage();
            return this;
        }

        public ContactHelper SubmitContacCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.Lastname);
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

        public ContactHelper Remove(ContactData contact)
        {
            SelectContactToRemove(contact.Id);
            RemoveContact();
            manager.Navigator.GoToMainPage();
            return this;
        }

        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector("div.msgbox"));
            contactCache = null;
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
            FillContactForm(name);
            SubmitContactModify();
            manager.Navigator.GoToMainPage();
            return this;
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
            driver.FindElement(By.XPath("//tr[./td[./input[@name='selected[]' and @value='" + id + "']]]")).FindElement(By.XPath(".//img[@alt='Edit']")).Click();
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

        public ContactHelper AddContactIfNotPresent()
        {
            if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")))
            {
                ContactData contact = (new ContactData("Auto", "Auto"));
                Create(contact);
            }
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToMainPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    IWebElement lastname = element.FindElement(By.CssSelector("td:nth-child(2)"));
                    IWebElement firstname = element.FindElement(By.CssSelector("td:nth-child(3)"));
                    contactCache.Add(new ContactData(firstname.Text, lastname.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            manager.Navigator.GoToMainPage();
            return driver.FindElements(By.CssSelector("[name='entry']")).Count;
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