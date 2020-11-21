using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TODOList.Drawing
{
    public class DrawTabControl
    {
        private TabControl tabControl= new TabControl();

        public void CreateTabControl(Grid grid, string name)
        {
            tabControl.Name = name;
            grid.Children.Add(tabControl);
        }

        public void CreateTabItem(string title)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = title;

            tabControl.Items.Add(tabItem);
        }
    }
}
