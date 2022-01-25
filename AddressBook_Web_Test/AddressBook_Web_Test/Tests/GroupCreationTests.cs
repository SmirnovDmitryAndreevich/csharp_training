using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace AddressBook_Web_Test
{
    [TestFixture]
    public class GroupCreationTest : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
        }

        [Test, TestCaseSource("GroupDataFromCsvFile")]
        public void GroupCrationTest(GroupData group)
        {
            List<GroupData> oldGroups = application.Groups.GetGroupList();

            application.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, application.Groups.GetGroupCount());

            List<GroupData> newGroups = application.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadGroupCrationTest()
        {
            GroupData group = new GroupData("a'a", "", "");
            List<GroupData> oldGroups = application.Groups.GetGroupList();

            application.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, application.Groups.GetGroupCount());

            List<GroupData> newGroups = application.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
