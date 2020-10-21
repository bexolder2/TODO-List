using System;
using System.Collections.Generic;
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
        public static DateTime CurrentDate { get; set; }
        public static List<Project> Projects { get; set; }

        // TODO: Init list
        
        //public static Program()
        //{
        //    Projects = new List<Project>();
        //}

        public static void AddProject()
        {
            Project test = new Project();
            test.NewProject();
            //Projects.Add(project);
        } 
    }
}
