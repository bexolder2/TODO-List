using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Logic
{
    public enum Status
    {
        Start,
        Finish,
        Stopped,
        Overdue
    }
    public enum StatusColor
    {
        Green,
        Gray,
        Yellow,
        Red
    }

    public static class Program
    {
        public static List<Project> Prj;

        static Program()
        {
            Prj = new List<Project>();
        }

        public static void AddProject()
        {
            GlobalVariables.BufferPrj = new Project();
            GlobalVariables.BufferPrj.NewProject();
            //Projects.Add(project);
        } 

        public static void DeleteProject(string projectName)
        {
            Prj.Remove(Prj.Find(x => x.ProjectName == projectName));
            GlobalVariables.DrawingTabControl.DeleteTabItem();
            GlobalVariables.DrawingTabControl.tabControl.Items.Refresh();
        }
    }
}
