using System;
using OpenQA.Selenium;
using NUnit.Framework;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        internal void Login(AccountData account)
        {
            manager.Navigator.OpenHomePage();
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys(account.Username);
            driver.FindElement(By.XPath("//form[@id='login-form']/fieldset/input[2]")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//form[@id='login-form']/fieldset/input[3]")).Click();
            Assert.IsTrue(IsElementPresent(By.ClassName("user-info")));
        }
    }
}
