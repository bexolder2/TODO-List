using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TODOList.Logic;

namespace TODOList.Dialogs
{
    public static class GetData
    {
        //public static void GetProjectName(TextBox tbName, string name_, Window npDialog)
        //{
        //    if (tbName.Text.Length > 0)
        //    {
        //        name_ = tbName.Text;
        //        MessageBox.Show("Name saved.");
        //        npDialog.Close();
        //        DialogOperations.GetTaskData();
        //    }
        //    else
        //        MessageBox.Show("Enter correct name!");
        //}

        public static void GetTaskData() 
        {
            GlobalVariables.BufferTask.Responsible.Name = GlobalVariables.BufferTask.BufferResponsible;
            GlobalVariables.BufferTask.Responsible.AvailableTasks.Add(GlobalVariables.BufferTask);

            if (GlobalVariables.ChildFlag == true)
            {

            }
            else
            {
                SaveTaskData();
            }
        }

        public static void SaveTaskData()
        {          
            Program.Prj.Last().Root.Add(GlobalVariables.BufferTask);
            GlobalVariables.BufferTask = null;
        }

        public static void SaveChildTaskData()
        {
            Program.Prj.Last().Root.Last().Children.Add(GlobalVariables.BufferTask);
            GlobalVariables.BufferTask = null;
        }

        public static void EndSave()
        {
            Program.Prj.Add(GlobalVariables.BufferPrj);
        }
    }
}
