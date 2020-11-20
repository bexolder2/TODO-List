using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            Logic.GlobalVariables.BufferTask.Responsible.Name = Logic.GlobalVariables.BufferTask.BufferResponsible;
            Logic.GlobalVariables.BufferTask.Responsible.AvailableTasks.Add(Logic.GlobalVariables.BufferTask);

            if (Logic.GlobalVariables.ChildFlag == true)
            {

            }
            else
            {
                SaveTaskData();
            }
        }

        public static void SaveTaskData()
        {          
            Logic.Program.Prj.Last().Root.Add(Logic.GlobalVariables.BufferTask);
            Logic.GlobalVariables.BufferTask = null;
        }

        public static void SaveChildTaskData()
        {
            Logic.Program.Prj.Last().Root.Last().Children.Add(Logic.GlobalVariables.BufferTask);
            Logic.GlobalVariables.BufferTask = null;
        }

        public static void EndSave()
        {
            Logic.Program.Prj.Add(Logic.GlobalVariables.BufferPrj);
        }
    }
}
