using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TODOList.Logic;

namespace TODOList.Drawing
{
    public struct DataItem
    {
        public string ColTaskName { get; set; }
        public CheckBox ColPerformed { get; set; }
        public CheckBox ColPause { get; set; }
        public List<List<StatusColor>> Cells { get; set; }
    }

    public class DrawDataGridRows
    {
        public List<DataItem> dataItem { get; private set; }
        public List<Logic.Task> TasksWithoutTree { get; private set; }

        public DrawDataGridRows(Project project)
        {
            dataItem = new List<DataItem>();
            
            TasksWithoutTree = new List<Logic.Task>();
            ConvertToList(project);
            InitializeDataItem();       
        }

        public void InitializeDataItem()
        {
            foreach (var item in TasksWithoutTree)
            {
                DataItem DItem = new DataItem();
                DItem.ColPerformed = new CheckBox();
                DItem.ColPause = new CheckBox();
                DItem.Cells = new List<List<StatusColor>>(12);
                for (int i = 0; i < DItem.Cells.Capacity; i++)
                {
                    DItem.Cells.Add(new List<StatusColor>(DateTime.DaysInMonth(DateTime.Now.Year, i + 1)));
                    for (int j = 0; j < DItem.Cells[i].Capacity; j++)
                    {
                        DItem.Cells[i].Add(StatusColor.White);
                    }
                }
                DItem.ColTaskName = item.TaskName;

                if (item.TaskStatus != Status.Finish)
                    DItem.ColPerformed.IsChecked = false;
                else
                    DItem.ColPerformed.IsChecked = true;

                if (item.TaskStatus == Status.Stopped)
                    DItem.ColPause.IsChecked = true;
                else
                    DItem.ColPause.IsChecked = false;

                SetCellsColors(DItem, item);
                dataItem.Add(DItem);
            }
        }

        private void SetCellsColors(DataItem DItem, Logic.Task item)
        {
            int days = item.Finish.Day - item.Start.Day;
            int monthCounter = item.Start.Month;
            int dayCounter = item.Start.Day;

            if (days == 0)
            {
                DItem.Cells[monthCounter - 1][dayCounter - 1] = StatusColor.Green;
            }
            else
            {
                for (int i = 0; i < days; i++)
                {
                    if (dayCounter < DItem.Cells[monthCounter - 1].Capacity)
                    {
                        DItem.Cells[monthCounter - 1][dayCounter - 1] = StatusColor.Green;
                        dayCounter++;
                    }
                    else
                    {
                        monthCounter++;
                        DItem.Cells[monthCounter - 1][dayCounter - 1] = StatusColor.Green;
                        dayCounter++;
                    }
                }
            }
        }

        private void FillingDataGrid(Project project, DataGrid dg)
        {
            foreach(var prj in project.Root)
            {
                DataGridRow row = new DataGridRow();
                //row
                row.Item = prj.TaskName;
                dg.Items.Add(row);
            }
        }

        #region search
        private void ConvertToList(Project project)
        {
            foreach (var child in project.Root)
            {
                if(child.Children == null)
                {
                    TasksWithoutTree.Add(child);
                }
                else
                {
                    TasksWithoutTree.Add(child);
                    ConvertToListChild(child);
                }
            }
        }

        private void ConvertToListChild(Logic.Task child)
        {
            foreach (var child_ in child.Children)
            {
                if (child_.Children == null)
                {
                    TasksWithoutTree.Add(child_);
                }
                else
                {
                    TasksWithoutTree.Add(child_);
                    ConvertToListChild(child_);
                }
            }
        }
        #endregion
    }
}
