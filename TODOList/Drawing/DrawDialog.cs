using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TODOList.Drawing
{
    public class DrawDialog
    {
        //public void DrawStartPageNP(Window win, Grid grid)
        //{
        //    // TODO: Set win size
        //    AddRows(grid, 3);
        //    AddColumns(grid, 2);

        //    Label lName = new Label();
        //    TextBox tbName = new TextBox();
        //    Button bSave = new Button();
        //    Button bCancel = new Button();

        //    win.Title = "New project";
        //    Settings(win, grid, lName, tbName, bSave, bCancel);

        //    lName.Content = "Enter project name:";
        //    tbName.MaxLength = 20;
        //    bSave.Content = "Save";
        //    bCancel.Content = "Cancel";
        //}

        //private void AddRows(Grid grid, int number)
        //{
        //    for(int i = 0; i < number; i++)
        //    {
        //        RowDefinition NewRow = new RowDefinition();
        //        NewRow.Height = new GridLength(28);
        //        grid.RowDefinitions.Add(NewRow);
        //    }
        //}

        //private void AddColumns(Grid grid, int number)
        //{
        //    for (int i = 0; i < number; i++)
        //    {
        //        ColumnDefinition NewCol = new ColumnDefinition();
        //        NewCol.Width = new GridLength(80);
        //        grid.ColumnDefinitions.Add(NewCol);
        //    }
        //}
        
        //private void Settings(Window win, Grid grid, Label lName, TextBox tbName, Button bSave, Button bCancel)
        //{
        //    win.Width = 180;
        //    win.Height = 125;

        //    grid.Children.Add(lName);
        //    grid.Children.Add(tbName);
        //    grid.Children.Add(bSave);
        //    grid.Children.Add(bCancel);

        //    Grid.SetRow(lName, 0);
        //    Grid.SetColumn(lName, 0);
        //    Grid.SetColumnSpan(lName, 2);

        //    Grid.SetRow(tbName, 1);
        //    Grid.SetColumn(tbName, 0);
        //    Grid.SetColumnSpan(tbName, 2);

        //    Grid.SetRow(bSave, 2);
        //    Grid.SetColumn(bSave, 0);

        //    Grid.SetRow(bCancel, 2);
        //    Grid.SetColumn(bCancel, 1);

        //    tbName.Height = 18;
        //    tbName.Width = 150;

        //    bSave.Height = 22;
        //    bCancel.Height = 22;
        //    bSave.Width = 70;
        //    bCancel.Width = 70;
        //}

        //private void NewEvents(Button bCancel)
        //{
        //    bCancel.Click += new RoutedEventHandler(Cancel_Click);
        //}
    }
}
