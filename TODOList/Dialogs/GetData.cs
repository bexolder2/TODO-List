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

        public static void GetTaskData(GlobalVariables.Operations operation = GlobalVariables.Operations.Add) 
        {
            GlobalVariables.BufferTask.Responsible.Name = GlobalVariables.BufferTask.BufferResponsible;
            GlobalVariables.BufferTask.Responsible.AvailableTasks.Add(GlobalVariables.BufferTask);

            if (GlobalVariables.ChildFlag == true)
            {
                SaveChildTaskData(operation);
            }
            else
            {
                SaveTaskData(operation);
                GlobalVariables.DrawingTabControl.drawTT.RefreshTreeView();
                //GlobalVariables.DrawingTabControl.drawTT.CreateTreeViewItem(GlobalVariables.DrawingTabControl.GetFocusTabItemHeader());
            }
        }

        public static void SaveTaskData(GlobalVariables.Operations operation = GlobalVariables.Operations.Add)//TODO: ENUM
        {
            if(operation == GlobalVariables.Operations.Edit)
            {
                Search(operation);
            }
            else
            {
                Program.Prj.Find(x => x.ProjectName == GlobalVariables.DrawingTabControl.GetFocusTabItemHeader()).Root.Add(GlobalVariables.BufferTask);
                GlobalVariables.BufferTask = null;
            }          
        }

        public static void SaveChildTaskData(GlobalVariables.Operations operation = GlobalVariables.Operations.Add)
        {
            if(GlobalVariables.DrawingTabControl.drawTT.SelectedTask != null)
            {
                Search(operation);
            }
        }

        private static void Search(GlobalVariables.Operations operation = GlobalVariables.Operations.Add)
        {
            GlobalVariables.DrawingTabControl.drawTT.
                    Search(Program.Prj.Find(x => x.ProjectName == GlobalVariables.DrawingTabControl.GetFocusTabItemHeader()),
                                                 operation);
            GlobalVariables.BufferTask = null;
        } 

        public static void EndSave()
        {
            Program.Prj.Add(GlobalVariables.BufferPrj);
        }
    }
}
