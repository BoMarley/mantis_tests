using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }
        
        public List<ProjectData> GetAllProjects()
        {
            AccountData account = new AccountData("administrator", "password");

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projectDataFromDB = client.mc_projects_get_user_accessible(account.Username, account.Password);

            List<ProjectData> projectList = new List<ProjectData>();

            foreach (mantis_tests.Mantis.ProjectData p in projectDataFromDB)
            {
                ProjectData project = new ProjectData();
                project.Id = p.id;
                project.Name = p.name;
                projectList.Add(project);
            }                        
            return projectList;
        }
    }
}
