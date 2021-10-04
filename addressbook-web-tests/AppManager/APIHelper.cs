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
            List<ProjectData> allProjects = new List<ProjectData>();
            AccountData account = new AccountData("administrator", "password");

            addressbook_web_tests.Mantis.MantisConnectPortTypeClient client = new addressbook_web_tests.Mantis.MantisConnectPortTypeClient();
            List<ProjectData> projectList = new List<ProjectData>();

            client.mc_projects_get_user_accessible(account.Username, account.Password);
            return allProjects;
        }
    }
}
