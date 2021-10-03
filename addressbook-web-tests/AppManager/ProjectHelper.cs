using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager)
            : base(manager)
        {
            
        }

        public List<ProjectData> GetProjectsList()
        {
            manager.Navigator.GoToProgectManagmentMenu();
            List<ProjectData> projects = new List<ProjectData>();
            IWebElement table = driver.FindElement(By.CssSelector(".widget-box"));
            IList<IWebElement> lines = table.FindElements(By.CssSelector("table tbody tr"));
            foreach (IWebElement line in lines)
            {
                IWebElement link = line.FindElement(By.TagName("a"));

                string projectName = link.Text;
                string id = link.GetAttribute("href");
                Regex regex = new Regex(@"\d+$");
                Match match = regex.Match(id);
                string projectId = match.Value;

                projects.Add(new ProjectData()
                {
                    Name = projectName,
                    Id = projectId
                });

            }
            return projects;
        }

        public void CreateProcject(ProjectData projectToCreate)
        {
            manager.Navigator.GoToProgectManagmentMenu();
            ProjectCreationInit();
            FillProjectForm(projectToCreate);
            SubmitProjectCreation();
        }

        public void ProjectCreationInit()
        {
            driver.FindElement(By.CssSelector(".form-inline.inline.single-button-form")).Click();
        }

        public void FillProjectForm(ProjectData projectToCreate)
        {
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(projectToCreate.Name);
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//form[@id='manage-project-create-form']/div/div[3]/input")).Click();
        }
    }
}
