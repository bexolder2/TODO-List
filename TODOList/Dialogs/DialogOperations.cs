using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Dialogs
{
    public static class DialogOperations
    {
        public static void GetNewProjectData(Logic.Project project)
        {
            DialogXaml.NewProject newPr = new DialogXaml.NewProject();
            newPr.ShowDialog();  
        }

        public static void GetTaskData()
        {
            DialogXaml.NewTask newTask = new DialogXaml.NewTask();
            newTask.ShowDialog();
        }
    }
}
