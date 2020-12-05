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
    public class DrawTaskTree
    {
        private TreeView treeView;
        private DrawContextMenu drawCM;
        public string TreeViewItemHeader { get; private set; }

        public DrawTaskTree(Grid grid)
        {
            treeView = new TreeView();
            CreateTaskTree(grid);
        }

        private void CreateTaskTree(Grid grid)//TODO: set size
        {
            treeView.SelectedItemChanged += TreeView_SelectedItemChanged;
            grid.Children.Add(treeView);
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            GetTreeViewItemFocus();
        }

        private void GetTreeViewItemFocus()
        {
            if(treeView.SelectedItem != null)
            {
                TreeViewItemHeader = (treeView.SelectedItem as TreeViewItem).Header.ToString();
            }
        }

        public void CreateTreeViewItem(string projectName)
        {
            if(GlobalVariables.ChildFlag == false)
            {
                treeView.Items.Clear();

                foreach (var value in Program.Prj.Find(project => project.ProjectName == projectName).Root)
                {
                    TreeViewItem tvi = new TreeViewItem();
                    tvi.Header = value.TaskName;
                    tvi.Name = value.TaskName;
                    drawCM = new DrawContextMenu();
                    tvi.ContextMenu = drawCM.contextMenuForTasks;
                    treeView.RegisterName(tvi.Name, tvi);
                    treeView.Items.Add(tvi);
                }
            }
        }

        public void CreateChildTreeViewItem(string childName)
        {
            TreeViewItem tviRoot = treeView.FindName(TreeViewItemHeader) as TreeViewItem;
            TreeViewItem tviChild = new TreeViewItem();
            tviChild.Header = childName;
            tviChild.Name = childName;
            tviChild.ContextMenu = drawCM.contextMenuForTasks;
            tviRoot.Items.Add(tviChild);
        }

        public void DeleteTreeViewItem()
        {
            treeView.Items.Remove(treeView.FindName(TreeViewItemHeader));
            treeView.Items.Refresh();
        }
    }
}
