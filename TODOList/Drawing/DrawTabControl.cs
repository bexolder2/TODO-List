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
        public Navigation.Navigator nv { get; private set; }
        private Grid TabGrid;
        private DrawContextMenu drawCM;

        private Label lMonth { get; set; }

        public enum Month
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

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
            nv = new Navigation.Navigator(TabGrid);

            for(int i = 1; i <= 12; i++)
            {
                nv.AddPage(i); //================================================================
            }
            
            drawCM = new DrawContextMenu();
            CreateButtons();
            SetLabelProperties();
            tabItem.ContextMenu = drawCM.contextMenuForTabItems;
            tabControl.Items.Add(tabItem);
            tabItem.Focus();
        }    

        public string GetFocusTabItemHeader()
        {
            return (tabControl.Items[tabControl.SelectedIndex] as TabItem).Header.ToString();
        }

        public void DeleteTabItem()
        {
            tabControl.Items.Remove(tabControl.Items[tabControl.SelectedIndex]);
        }

        #region UI
        private void SetLabelProperties()
        {
            lMonth = new Label();

            Thickness margin = lMonth.Margin;
            margin.Left = 370;
            margin.Top = 480;
            margin.Right = 690;
            lMonth.Margin = margin;
            TabGrid.Children.Add(lMonth);
        }

        private void CreateButtons()
        {
            Button bBack = new Button();
            Button bNext = new Button();
            Button bShow = new Button();

            bBack.Content = "<";
            bNext.Content = ">";
            bShow.Content = "Show diagram";
            bBack.Height = 20;
            bBack.Width = 20;
            bNext.Height = 20;
            bNext.Width = 20;
            bShow.Height = 20;
            bShow.Width = 100;
            Thickness margin = bBack.Margin;
            margin.Left = 200;
            margin.Top = 480;
            margin.Right = 950;
            margin.Bottom = 10;
            bBack.Margin = margin;
            Thickness margin2 = bNext.Margin;
            margin2.Left = 230;
            margin2.Top = 480;
            margin2.Right = 920;
            margin2.Bottom = 10;
            bNext.Margin = margin2;
            Thickness margin3 = bShow.Margin;
            margin3.Left = 260;
            margin3.Top = 480;
            margin3.Right = 800;
            margin3.Bottom = 10;
            bShow.Margin = margin3;

            bBack.Click += (object sender, RoutedEventArgs e) =>
            {
                if (nv.CurrentPage - 1 >= 0)
                {
                    nv.frame_.frame.Navigate(nv.pages_[nv.CurrentPage - 1].page);
                    nv.CurrentPage--;
                    SetLabelText();
                }
            };

            bNext.Click += (object sender, RoutedEventArgs e) =>
            {
                if (nv.pages_.Count != 0)
                {
                    if (nv.pages_.Count > nv.CurrentPage + 1)
                    {
                        nv.frame_.frame.Navigate(nv.pages_[nv.CurrentPage + 1].page);
                        nv.CurrentPage++;
                        SetLabelText();
                    }
                }
            };

            bShow.Click += (object sender, RoutedEventArgs e) =>
            {
                if (nv.pages_.Count != 0)
                    nv.frame_.frame.Navigate(nv.pages_[0].page);
                SetLabelText();
            };

            TabGrid.Children.Add(bBack);
            TabGrid.Children.Add(bNext);
            TabGrid.Children.Add(bShow);
        }

        private void SetLabelText()
        {
            foreach (Month m in Enum.GetValues(typeof(Month)))
            {
                if ((int)m == nv.CurrentPage)
                {
                    lMonth.Content = m;
                }
            }
        }
        #endregion
    }
}
