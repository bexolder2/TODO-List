using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace TODOList.Drawing.Navigation
{
    public class Pages
    {
        public Page page { get; private set; }

        public Pages()
        {
            page = new Page();
        }

        public void CreatePage(int month)
        {
            page.Background = Brushes.Green;
            CreateDataGrid(month);
        }

        private void CreateDataGrid(int month)
        {
            DataGrid dg = new DataGrid();
            dg.IsReadOnly = true;
            dg.CanUserSortColumns = false;
            dg.CanUserResizeColumns = false;
            dg.AutoGenerateColumns = false;
            DataGridTextColumn col1 = new DataGridTextColumn();
            col1.Header = "Task name";
            dg.Columns.Add(col1);
            DataGridCheckBoxColumn col2 = new DataGridCheckBoxColumn();
            col2.Header = "Status";
            dg.Columns.Add(col2);
            for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, month); i++)
            {
                DataGridTextColumn col = new DataGridTextColumn();
                col.Header = (i + 1).ToString();
                dg.Columns.Add(col);
            }
            page.Content = dg;
        }
    }
}
