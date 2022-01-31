using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook_Web_Test
{
    [Table(Name="group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {
        }

        public GroupData(string name)
        {
            Name = name;
        }
        
        public bool Equals(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {Name}\n{ Footer}: { Footer}\n{ Header}: { Header}";
        }

        public int CompareTo(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }
        [Column(Name="group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        public List<ContactData> GetContacts()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupsId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00") select c).Distinct().ToList();
            }
        }
    }
}
