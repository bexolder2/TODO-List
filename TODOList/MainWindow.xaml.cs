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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TODOList.Logic;
using System.IO;
using Microsoft.Win32;

namespace TODOList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Closed += MainWindow_Closed;
            GlobalVariables.DrawingTabControl.CreateTabControl(RootGrid, "TabControl1");
            Dialogs.DialogOperations.InitProject += DialogOperations_InitProject;
            //Dialogs.DialogOperations.NewTask += DialogOperations_NewTask;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            foreach (var obj in Program.Prj)
            {
                Program.Serialize($"{obj.ProjectName}.dat", obj);
            }       
        }

        //private void DialogOperations_NewTask()
        //{
        //    if (GlobalVariables.newTask != null)
        //        GlobalVariables.newTask.SaveNewTask += NewTask_SaveNewTask;
        //}

        //private void NewTask_SaveNewTask(object sender, EventArgs e)
        //{
        //    //GlobalVariables.DrawingTabControl.AddTaskItem(Program.Prj.Last().ProjectName); //TODO: current name WTF?? maybe move to NewTask.xaml.cs
        //}

        private void DialogOperations_InitProject()
        {
            if (GlobalVariables.newPr != null)
                GlobalVariables.newPr.SaveNewProject += NewPr_SaveNewProject;
        }

        private void NewPr_SaveNewProject(object sender, EventArgs e)
        {
            GlobalVariables.DrawingTabControl.CreateTabItem(Program.Prj.Last().ProjectName, Program.Prj.Last());
            GlobalVariables.BufferPrj = null;
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            Program.AddProject();
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "binary files (*.dat)|*.dat";
            open.RestoreDirectory = true;

            if (open.ShowDialog() == true)
            {
                filePath = open.FileName;
            }

            Program.Deserialize(filePath);
            NewPr_SaveNewProject(null, null);
            GlobalVariables.DrawingTabControl.drawTT.RefreshTreeView();
        }
    }
}
