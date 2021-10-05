using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests

{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper authentificationHelper;
        protected NavigationHelper navigationHelper;
        protected ProjectHelper projectHelper;

        

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.25.2";
            authentificationHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            projectHelper = new ProjectHelper(this);
            API = new APIHelper(this);
        }


        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public APIHelper API { get; set; }

        public LoginHelper Auth
        {
            get
            {
                return authentificationHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }

        public ProjectHelper Project
        {
            get
            {
                return projectHelper;
            }
        }

        public IWebDriver Driver {
            get
            {
                return driver;
            }
        }
    }
}
