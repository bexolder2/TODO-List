using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Logic;

namespace TODOList.Dialogs
{
    public static class DialogOperations
    {
        public static event Action InitProject;
        public static event Action NewTask;
        public static void GetNewProjectData(Project project)
        {
            GlobalVariables.newPr = null;
            GlobalVariables.newPr = new DialogXaml.NewProject();
            InitProject?.Invoke();
            GlobalVariables.newPr.ShowDialog();
        }

        public static void GetTaskData()
        {
            GlobalVariables.newTask = null;
            GlobalVariables.newTask = new DialogXaml.NewTask();
            NewTask?.Invoke();
            GlobalVariables.newTask.ShowDialog();
        }
    }
}
