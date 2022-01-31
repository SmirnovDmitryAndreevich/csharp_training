using NUnit.Framework;
using System;
using System.Text;

namespace AddressBook_Web_Test
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager application;

        [SetUp]
        public void SetupApplicationManager()
        {
            application = ApplicationManager.GetInstance();
            application.Auth.Login(new AccountData("admin", "secret"));
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 1; i ++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}
