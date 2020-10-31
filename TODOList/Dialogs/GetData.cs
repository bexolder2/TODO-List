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
        public static void GetProjectName(TextBox tbName, string name_, Window npDialog)
        {
            if (tbName.Text.Length > 0)
            {
                name_ = tbName.Text;
                MessageBox.Show("Name saved.");
                npDialog.Close();
                DialogOperations.GetTaskData();
            }
            else
                MessageBox.Show("Enter correct name!");
        }

        public static void GetTaskData() 
        {
            //TODO:Sava info
        }
        //TextBox tbName, TextBox tbSDesc, TextBox tbLDesc, TextBox tbPerson, DatePicker dpSDate, DatePicker dpFDate, Window ntDialog, Logic.Project prj
    }
}
