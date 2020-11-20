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

namespace TODOList.DialogXaml
{
    public partial class NewTask : Window
    {
        public NewTask()
        {
            InitializeComponent();
            Logic.GlobalVariables.BufferTask = new Logic.Task();

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
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //Logic.Program.Prj.Last();
            Logic.GlobalVariables.BufferTask = null;
            Close();
        }
    }
}
