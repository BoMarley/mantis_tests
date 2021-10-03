using OpenQA.Selenium;
using System;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            else
            {
                driver.Navigate().GoToUrl(baseURL);
            }
        }

        internal void GoToProgectManagmentMenu()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php")
            {
                return;
            }
            else
            {
                driver.Navigate().GoToUrl(baseURL + "/manage_proj_page.php");
            }            
        }
    }
}