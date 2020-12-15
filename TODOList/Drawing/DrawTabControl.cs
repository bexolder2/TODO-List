using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TODOList.Logic;

namespace TODOList.Drawing
{
    public class DrawTabControl
    {
        public TabControl tabControl { get; private set; }
        public DrawTaskTree drawTT { get; private set; }//TODO: maybe dynamic task tree
        private Grid TabGrid;
        private DrawContextMenu drawCM;

        public DrawTabControl()
        {
            tabControl = new TabControl();
        }

        public void CreateTabControl(Grid grid, string name)
        {
            tabControl.Name = name;
            Thickness margin = tabControl.Margin;
            margin.Top = 20;
            tabControl.Margin = margin;
            grid.Children.Add(tabControl);
        }

        public void CreateTabItem(string title, Project project)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = title;
            TabGrid = new Grid();
            tabItem.Content = TabGrid;
            drawTT = new DrawTaskTree(TabGrid, project);
            drawCM = new DrawContextMenu();
            tabItem.ContextMenu = drawCM.contextMenuForTabItems;
            tabControl.Items.Add(tabItem);
            tabItem.Focus();
        }

        //public void AddTaskItem(string title)
        //{
        //    drawTT.CreateTreeViewItem(title);
        //}

        public string GetFocusTabItemHeader()
        {
            return (tabControl.Items[tabControl.SelectedIndex] as TabItem).Header.ToString();
        }

        public void DeleteTabItem()
        {
            tabControl.Items.Remove(tabControl.Items[tabControl.SelectedIndex]);
        }

        public void DeleteTreeViewItem()
        {
            //drawTT.DeleteTreeViewItem();
        }
    }
}
