using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TODOList.Drawing.Navigation
{
    public class Frames
    {
        public Frame frame { get; private set; }

        public Frames()
        {
            frame = new Frame();
        }

        public void CreateFrame(Grid grid)
        {
            frame.Background = Brushes.Azure;
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            Thickness margin = frame.Margin;
            margin.Left = 200;
            margin.Top = 10;
            margin.Right = 10;
            margin.Bottom = 40;
            frame.Margin = margin;

            grid.Children.Add(frame);
        }
    }
}
