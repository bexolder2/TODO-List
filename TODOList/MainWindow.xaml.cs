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

            GlobalVariables.DrawingTabControl.CreateTabControl(GetMainWindowGrid(), "TabControl1");
            Dialogs.DialogOperations.InitProject += DialogOperations_InitProject;    


        }

        private void DialogOperations_InitProject()
        {
            if (GlobalVariables.newPr != null)
                GlobalVariables.newPr.SaveNewProject += NewPr_SaveNewProject;
        }

        private void NewPr_SaveNewProject(object sender, EventArgs e)
        {
            GlobalVariables.DrawingTabControl.CreateTabItem(Program.Prj.Last().ProjectName);
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            Program.AddProject();
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public Grid GetMainWindowGrid()
        {
            return RootGrid;
        }
    }
}
