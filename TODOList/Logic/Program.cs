using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

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

    [Serializable]
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

        public static void Serialize(string fileName, Project source)
        {
            //using (var file = new StreamWriter(fileName))
            //{
            //    file.WriteLine(JsonConvert.SerializeObject(source));
            //}
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, source);
            }
        }

        public static void Deserialize(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                Prj.Add((Project)formatter.Deserialize(fs));
            }
        }
    }
}
