﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TODOList.Logic;

namespace TODOList.DialogXaml
{
    public partial class NewTask : Window
    {
        public event EventHandler SaveNewTask;
        private GlobalVariables.Operations operation = GlobalVariables.Operations.Add;

        public NewTask()
        {
            InitializeComponent();
            GlobalVariables.BufferTask = new Logic.Task();

            dpSDate.DisplayDateStart = DateTime.Now;
            dpFDate.DisplayDateStart = DateTime.Now;
            DataContext = GlobalVariables.BufferTask;

            this.Closing += NewTask_Closing;
        }

        private void NewTask_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GlobalVariables.DrawingTabControl.drawTT.RefreshTreeView();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            #region
            /*if (cbNextTask.IsChecked == true)
            {
                if (cbChildTask.IsChecked == true)
                {
                    Logic.GlobalVariables.ChildFlag = true;
                    Dialogs.GetData.GetTaskData();
                    Dialogs.DialogOperations.GetTaskData();
                    Close();
                }
                else
                {
                    Logic.GlobalVariables.ChildFlag = false;
                    Logic.GlobalVariables.BufferTask.Children = null;
                    Dialogs.GetData.GetTaskData();
                    Dialogs.DialogOperations.GetTaskData();
                    Close();
                }
            }
            else
            {
                Dialogs.GetData.GetTaskData();
                Close();
            }*/
            #endregion
            GlobalVariables.BufferTask.Start = dpSDate.SelectedDate.Value;
            GlobalVariables.BufferTask.Finish = dpFDate.SelectedDate.Value;
            if (operation == GlobalVariables.Operations.Edit)
            {
                Dialogs.GetData.GetTaskData(operation);
                Close();
            }
            else
            {
                Dialogs.GetData.GetTaskData();
                Close();
                Dialogs.DialogOperations.GetTaskData();
                //SaveNewTask?.Invoke(this, null);
            }    
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //Logic.Program.Prj.Last();
            GlobalVariables.BufferTask = null;
            Close();
            GlobalVariables.ChildFlag = false;
        }

        public void EditMode()
        {
            operation = GlobalVariables.Operations.Edit;
            dpSDate.SelectedDate = GlobalVariables.BufferTask.Start;
            dpFDate.SelectedDate = GlobalVariables.BufferTask.Finish;
        }
    }
}
