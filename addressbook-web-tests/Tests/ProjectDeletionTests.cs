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
            app.Navigator.GoToProgectManagmentMenu();
            List<ProjectData> oldList = app.Project.GetProjectsList();
            if (oldList.Count == 0)
            {
                ProjectData project = new ProjectData() { Name = "Delete me" };
                app.Project.CreateProcject(project);
                oldList = app.Project.GetProjectsList();
            }
            ProjectData projectToDelete = oldList[0];

            //actions
            app.Project.DeleteProcject();

            //validation
            app.Navigator.GoToProgectManagmentMenu();
            List<ProjectData> newList = app.Project.GetProjectsList();
            oldList.Remove(projectToDelete);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}