using System;
using System.Text;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    class ProjectDeleteTests : AuthTestBase
    {
        [Test]
        public void TestProjectDelete()
        {
            //prepare            
            List<ProjectData> oldList = app.API.GetAllProjects();
            if (oldList.Count == 0)
            {
                ProjectData projectToCreate = new ProjectData() { Name = "Delete me" };
                app.API.CreateProject(projectToCreate);
                oldList = app.API.GetAllProjects();
            }
            ProjectData projectToDelete = oldList[0];
            app.Navigator.GoToProgectManagmentMenu();

            //actions
            app.Project.DeleteProcject();

            //validation
            app.Navigator.GoToProgectManagmentMenu();
            List<ProjectData> newList = app.API.GetAllProjects();
            oldList.Remove(projectToDelete);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}