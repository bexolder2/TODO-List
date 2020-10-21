using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Logic
{
    public class Project
    {
        public string ProjectName { get; set; }
        public Dictionary<int, Task> Root { get; set; }

        public Project()
        {
            Root = new Dictionary<int, Task>();
        }

        public Project(string prName)
        {
            ProjectName = prName;
        }

        public void NewProject()
        {
            Dialogs.DialogOperations.GetNewProjectData(this);
        } 

        public void DeleteProject()
        {

        }
    }
}
