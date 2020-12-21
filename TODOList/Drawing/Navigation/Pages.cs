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
        private Canvases canvas { get; set; }

        public Pages()
        {
            page = new Page();
        }

        public void CreatePage(Frames fr, int year, int month)
        {
            CreateCanvas(year, month);
            InitializeTasksOnCanvas(fr);
            page.Content = canvas._Scroll;
        }

        public void NewTask(Logic.Task task)
        {
            canvas.AddLine(task);
        }

        private void CreateCanvas(int year, int month)
        {
            canvas = new Canvases(year, month);
        }

        private void InitializeTasksOnCanvas(Frames fr)
        {
            foreach(var task in fr.TasksWithoutTree)
            {
                NewTask(task);
            }
        }
        #region old
        //private void CreateDataGrid(int month)
        //{
        //    DataGrid dg = new DataGrid();
        //    dg.IsReadOnly = true;
        //    dg.CanUserSortColumns = false;
        //    dg.CanUserResizeColumns = false;
        //    dg.AutoGenerateColumns = false;

        //    DataGridTextColumn col1 = new DataGridTextColumn();
        //    col1.Header = "Task name";
        //    dg.Columns.Add(col1);
        //    DataGridCheckBoxColumn col2 = new DataGridCheckBoxColumn();
        //    col2.Header = "Performed";
        //    dg.Columns.Add(col2);
        //    DataGridCheckBoxColumn col3 = new DataGridCheckBoxColumn();
        //    col3.Header = "Pause";
        //    dg.Columns.Add(col3);
        //    for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, month); i++)
        //    {
        //        DataGridTextColumn col = new DataGridTextColumn();
        //        col.Header = (i + 1).ToString();
        //        dg.Columns.Add(col);
        //    }
        //    page.Content = dg;
        //}
        #endregion
    }
}
