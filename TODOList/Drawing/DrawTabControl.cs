using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TODOList.Drawing
{
    public class DrawTabControl
    {
        private TabControl tabControl= new TabControl();
        private DrawTaskTree drawTT;//TODO: maybe dynamic task tree

        public void CreateTabControl(Grid grid, string name)
        {
            tabControl.Name = name;
            Thickness margin = tabControl.Margin;
            margin.Top = 20;
            tabControl.Margin = margin;

            drawTT = new DrawTaskTree(tabControl);

            grid.Children.Add(tabControl);
        }

        public void CreateTabItem(string title)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = title;
            tabControl.Items.Add(tabItem);
        }

        public void AddTaskItem()
        {
            drawTT.CreateTreeViewItem()
        }
    }
}
