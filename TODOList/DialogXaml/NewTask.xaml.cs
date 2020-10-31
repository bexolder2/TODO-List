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
            DataContext = Logic.GlobalVariables.BufferTask; //TODO: Converter for date
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.GetData.GetTaskData();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Logic.GlobalVariables.BufferTask = null;
            Close();
        }
    }
}
