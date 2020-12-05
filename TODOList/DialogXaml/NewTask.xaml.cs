using System;
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

        public NewTask()
        {
            InitializeComponent();
            GlobalVariables.BufferTask = new Logic.Task();

            dpSDate.DisplayDateStart = DateTime.Now;
            dpFDate.DisplayDateStart = DateTime.Now;
            DataContext = Logic.GlobalVariables.BufferTask;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //if(cbNextTask.IsChecked == true)
            //{
            //    if(cbChildTask.IsChecked == true)
            //    {
            //        Logic.GlobalVariables.ChildFlag = true;
            //        Dialogs.GetData.GetTaskData();
            //        Dialogs.DialogOperations.GetTaskData();
            //        Close();
            //    }
            //    else
            //    {
            //        Logic.GlobalVariables.ChildFlag = false;
            //        Logic.GlobalVariables.BufferTask.Children = null;
            //        Dialogs.GetData.GetTaskData();
            //        Dialogs.DialogOperations.GetTaskData();
            //        Close();
            //    }
            //}
            //else
            //{
            //    Dialogs.GetData.GetTaskData();
            //    Close();
            //}
            Dialogs.GetData.GetTaskData();
            Close();
            Dialogs.DialogOperations.GetTaskData();

            SaveNewTask?.Invoke(this, null);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //Logic.Program.Prj.Last();
            GlobalVariables.BufferTask = null;
            Close();
            GlobalVariables.ChildFlag = false;
        }
    }
}
