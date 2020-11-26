using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TODOList.Drawing
{
    public class DrawTaskTree
    {
        private TreeView treeView;
        private DrawContextMenu drawCM;

        public DrawTaskTree(TabControl tc)
        {
            treeView = new TreeView();
            CreateTaskTree(tc);
        }

        private void CreateTaskTree(TabControl tc)
        {
            treeView.SelectedItemChanged += TreeView_SelectedItemChanged;
            tc.Items.Add(treeView);
        }

        private void TreeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            throw new NotImplementedException();
        }

        public void CreateTreeViewItem(string title)
        {
            TreeViewItem tvi = new TreeViewItem();
            tvi.Header = title;
            tvi.Name = title;
            drawCM = new DrawContextMenu();
            tvi.ContextMenu = drawCM.contextMenu;
            treeView.Items.Add(tvi);
        }

        public void SelectedItem()
        {
            TreeViewItem selectedItem = treeView.SelectedItem as TreeViewItem;
        }
    }
}
