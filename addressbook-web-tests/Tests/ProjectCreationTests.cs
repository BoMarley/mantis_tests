using System;
using System.Text;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            //prepare
            app.Navigator.GoToProgectManagmentMenu();
            List<ProjectData> oldList = app.Project.GetProjectsList();

            //actions
            ProjectData projectToCreate = new ProjectData() { Name = "Test project name" };
            ProjectData DuplicatedProjectName = oldList.Find(p => p.Name == projectToCreate.Name);
            if (DuplicatedProjectName != null)
            {
                projectToCreate.Name = projectToCreate.Name + " " + GenerateRandomString(5);
            }
            app.Project.CreateProcject(projectToCreate);

            //validation
            app.Navigator.GoToProgectManagmentMenu();
            List<ProjectData> newList = app.Project.GetProjectsList();
            oldList.Add(projectToCreate);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
