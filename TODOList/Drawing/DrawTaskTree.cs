using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TODOList.Logic;

namespace TODOList.Drawing
{
    public class DrawTaskTree
    {
        private TreeView treeView;
        private DrawContextMenu drawCM;

        public DrawTaskTree(Grid grid)
        {
            treeView = new TreeView();
            CreateTaskTree(grid);
        }

        private void CreateTaskTree(Grid grid)//TODO: set size
        {
            //treeView.SelectedItemChanged += TreeView_SelectedItemChanged;
            grid.Children.Add(treeView);
        }

        //private void TreeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        //{
        //    throw new NotImplementedException();
        //}

        public void CreateTreeViewItem(string projectName)
        {
            treeView.Items.Clear();

            foreach(var value in Program.Prj.Find(project => project.ProjectName == projectName).Root)
            {
                TreeViewItem tvi = new TreeViewItem();
                tvi.Header = value.TaskName;
                tvi.Name = value.TaskName;
                drawCM = new DrawContextMenu();
                tvi.ContextMenu = drawCM.contextMenuForTasks;
                treeView.Items.Add(tvi);
            }
        }

        //public void SelectedItem()
        //{
        //    TreeViewItem selectedItem = treeView.SelectedItem as TreeViewItem;
        //}
    }
}
