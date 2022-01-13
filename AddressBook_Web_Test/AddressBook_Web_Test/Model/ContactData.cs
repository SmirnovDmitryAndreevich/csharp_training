using System;

namespace AddressBook_Web_Test
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
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
    }
}

