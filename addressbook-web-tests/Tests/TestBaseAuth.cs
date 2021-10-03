using System;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]

        public void Login()
        {
            AccountData account = new AccountData("administrator", "password");
            app.Auth.Login(account);   
        }
    }
}