using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TODOList.Drawing
{
    public class DrawContextMenu
    {
        public ContextMenu contextMenu { get; private set; }

        public DrawContextMenu()
        {
            contextMenu = new ContextMenu();
            CreateMenuItems();
        }

        private void CreateMenuItems()
        {
            MenuItem menuItem1 = new MenuItem();
            menuItem1.Header = "Добавить подзадачу";
            menuItem1.Click += AddTask_Click;
            contextMenu.Items.Add(menuItem1);
            
            MenuItem menuItem2 = new MenuItem();
            menuItem2.Header = "Удалить задачу";
            menuItem2.Click += DeleteTask_Click;
            contextMenu.Items.Add(menuItem2);
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete task");
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add task");
        }

        //public void CreateMenuItem(string title)
        //{
        //    MenuItem menuItem = new MenuItem();
        //    menuItem.Header = title;
        //    menuItem.Click += (object sender, RoutedEventArgs e) => 
        //    {

        //    };
        //    contextMenu.Items.Add(menuItem);
        //}
    }
}
