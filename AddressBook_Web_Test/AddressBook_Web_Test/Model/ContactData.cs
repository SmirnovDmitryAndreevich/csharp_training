using System;
using System.Text.RegularExpressions;

namespace AddressBook_Web_Test
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Firstname == other.Firstname) & (Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return ("Firstname =" + Firstname + "," + "Lastname =" + Lastname);
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            string expected = $"{Lastname} {Firstname}";
            string actual = $"{other.Lastname} {other.Firstname}";
            return expected.CompareTo(actual);
        }


        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string SecondaryPhone { get; set; }

        public string FirstEmail { get; set; }

        public string SecondEmail { get; set; }

        public string ThirdEmail { get; set; }


        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(SecondaryPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if(allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(FirstEmail) + CleanUp(SecondEmail) + CleanUp(ThirdEmail).Trim());
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone =="")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
    }
}

