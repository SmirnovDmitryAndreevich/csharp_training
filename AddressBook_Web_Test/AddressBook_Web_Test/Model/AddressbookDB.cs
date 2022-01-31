using LinqToDB;

namespace AddressBook_Web_Test
{
    public class AddressbookDB : LinqToDB.Data.DataConnection
    {
        public AddressbookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }

        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); } }

        public ITable<GroupContactRelation> GCR { get { return GetTable<GroupContactRelation>(); } }
    }
}
