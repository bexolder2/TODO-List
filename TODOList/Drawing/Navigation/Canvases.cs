using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TODOList.Logic;

namespace TODOList.Drawing.Navigation
{
    public class Canvases
    {
        private List<SolidColorBrush> _Brushes;

        public ScrollViewer _Scroll { get; private set; }
        public Canvas _Canvas { get; private set; }

        public List<TextBlock> _TextBlocks { get; private set; }
        public List<TextBlock> _TasksTextBlocks { get; private set; }
        public List<Line> _Lines { get; private set; }
        public List<Rectangle> _Rectangles { get; private set; }
        public List<CheckBox> _CheckBoxesPerf { get; private set; }
        public List<CheckBox> _CheckBoxesPause { get; private set; }

        private enum CheckBoxType
        {
            Performed,
            Pause
        };

        private int YForLines = 45;
        private int XForName = 10;
        private int XForCbPerf = 200;
        private int XForCbPause = 250;
        private int StartXForRectangles;
       

        public Canvases(int year, int month)
        {
            _Brushes = new List<SolidColorBrush>();
            InitializeBrushes();
            _Scroll = new ScrollViewer();
            _Canvas = new Canvas();

            _TextBlocks = new List<TextBlock>();
            _Lines = new List<Line>();
            _Rectangles = new List<Rectangle>();
            _CheckBoxesPerf = new List<CheckBox>();
            _CheckBoxesPause = new List<CheckBox>();
            _TasksTextBlocks = new List<TextBlock>();

            Markup(year, month);
        }

        public void AddLine(Logic.Task task)
        {
            CreateCheckBoxes(CheckBoxType.Performed, task.TaskName);
            CreateCheckBoxes(CheckBoxType.Pause, task.TaskName);
            CreateHorizontalLine(0, (int)_Canvas.Width, YForLines);
            CreateTextBlock(task.TaskName);
            //CreateRectangle(, task.TaskStatusColor, task.TaskName);
            if (_Canvas.Height > YForLines)
                YForLines += 25;
            else
            {
                ExpandCanvasHeight();
                YForLines += 25;
            }
        }

        public void ExpandCanvasHeight()
        {
            _Canvas.Height *= 2;
        }

        private void InitializeBrushes()
        {
            _Brushes.Add(CreateBrush(0, 255, 0));
            _Brushes.Add(CreateBrush(128, 128, 128));
            _Brushes.Add(CreateBrush(255, 255, 0));
            _Brushes.Add(CreateBrush(255, 0, 0));
            _Brushes.Add(CreateBrush(255, 255, 255));
        }

        private SolidColorBrush CreateBrush(int r, int g, int b)
        {
            SolidColorBrush _Brush = new SolidColorBrush();
            _Brush.Color = Color.FromRgb((byte)r, (byte)g, (byte)b);
            return _Brush;
        }

        private void Markup(int year, int month)
        {
            int counter = DateTime.DaysInMonth(year, month);

            _Scroll.Width = 970;
            _Scroll.Height = 462;
            _Scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            _Canvas.Width = _Scroll.Width + 250;
            _Canvas.Height = _Scroll.Height * 2;
            int MarginTopForFirstLine = 10;
            int MarginBottomForFirstLine = (int)_Canvas.Height - 20;

            _Canvas.Background = Brushes.Beige; //TODO:choose color

            CreateTextBlocks(counter, MarginTopForFirstLine, MarginBottomForFirstLine);
            CreateVerticalLines(counter, _TextBlocks[1], _TextBlocks[2]);

            foreach (var l in _Lines)
            {
                _Canvas.Children.Add(l);
            }

            CreateStartHorizontalLine();

            foreach (var tb in _TextBlocks)
            {
                _Canvas.Children.Add(tb);
            }
            
            _Scroll.Content = _Canvas;
        }

        private void CreateTextBlocks(int counter, int MarginTopForFirstLine, int MarginBottomForFirstLine)
        {
            #region TextBlockses
            TextBlock tb1 = new TextBlock();
            TextBlock tb2 = new TextBlock();
            TextBlock tb3 = new TextBlock();

            tb1.Text = "Task name";
            tb2.Text = "Performed";
            tb3.Text = "Pause";

            tb1.Margin = SetMargin<TextBlock>(tb1, 10, MarginTopForFirstLine, (int)_Canvas.Width - 80, MarginBottomForFirstLine);
            tb2.Margin = SetMargin<TextBlock>(tb2, (int)_Canvas.Width - (int)tb1.Margin.Right + 100, MarginTopForFirstLine, (int)tb2.Margin.Left + 80, MarginBottomForFirstLine);
            tb3.Margin = SetMargin<TextBlock>(tb3, (int)tb2.Margin.Left + 60, MarginTopForFirstLine, (int)_Canvas.Width - (int)tb3.Margin.Left - 60, MarginBottomForFirstLine);

            _TextBlocks.Add(tb1);
            _TextBlocks.Add(tb2);
            _TextBlocks.Add(tb3);

            int MarginLeft = (int)tb3.Margin.Left + 50;
            StartXForRectangles = MarginLeft;
            int MarginRight = (int)_Canvas.Width - MarginLeft - 20;
            for (int i = 0; i < counter; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = (i + 1).ToString();
                tb.Margin = SetMargin<TextBlock>(tb, MarginLeft, MarginTopForFirstLine, MarginRight, MarginBottomForFirstLine);
                _TextBlocks.Add(tb);
                MarginLeft += 30;
            }
            #endregion
        }

        private void CreateVerticalLines(int counter, TextBlock tb2, TextBlock tb3)
        {
            #region Vertical Lines
            Line line1 = new Line();
            Line line2 = new Line();
            line1.Stroke = Brushes.Black;
            line2.Stroke = Brushes.Black;
            line1.X1 = (int)tb2.Margin.Left - 5;
            line1.X2 = (int)tb2.Margin.Left - 5;
            line1.Y1 = 0;
            line1.Y2 = _Canvas.Height;
            line2.X1 = (int)tb3.Margin.Left - 2;
            line2.X2 = (int)tb3.Margin.Left - 2;
            line2.Y1 = 0;
            line2.Y2 = _Canvas.Height;

            _Lines.Add(line1);
            _Lines.Add(line2);

            int XForLine = (int)tb3.Margin.Left + 40;
            for (int i = 0; i < counter; i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = XForLine;
                line.X2 = XForLine;
                line.Y1 = 0;
                line.Y2 = _Canvas.Height;
                _Lines.Add(line);
                XForLine += 30;
            }
            #endregion 
        }

        private void CreateStartHorizontalLine()
        {
            #region Horizontal Line
            CreateHorizontalLine(0, (int)_Canvas.Width, 25);
            #endregion
        }

        private void CreateCheckBoxes(CheckBoxType cbt, string Name)
        {
            CheckBox cb = new CheckBox();
            cb.IsChecked = false;
            cb.Name = SetControlName<CheckBox>(cb, Name);

            switch (cbt)
            {
                case CheckBoxType.Performed:
                    cb.Checked += (object sender, RoutedEventArgs e) =>
                    {
                        //FillRectangle(_Rectangles.Find(x => x.Name == Name.Trim(trimSymbol)), StatusColor.Gray);
                    };
                    SetCheckBoxMargin(cb, XForCbPerf, YForLines - 17);
                    _CheckBoxesPerf.Add(cb);
                    _Canvas.Children.Add(cb);
                    break;
                case CheckBoxType.Pause:
                    cb.Checked += (object sender, RoutedEventArgs e) =>
                    {
                        //FillRectangle(_Rectangles.Find(x => x.Name == Name.Trim(trimSymbol)), StatusColor.Yellow);
                    };
                    SetCheckBoxMargin(cb, XForCbPause, YForLines - 17);
                    _CheckBoxesPause.Add(cb);
                    _Canvas.Children.Add(cb);
                    break;
            }
        }

        private void CreateTextBlock(string text)
        {
            TextBlock tb = new TextBlock();
            tb.Text = text;
            tb.Margin = SetMargin<TextBlock>(tb, XForName, YForLines - 18, 0, 0);// 3:(int)_Canvas.Width - XForCbPerf; 4:(int)_Canvas.Height - YForLines - 25
            char trimSymbol = ' ';
            tb.Name = text.Trim(trimSymbol);
            _TasksTextBlocks.Add(tb);
            _Canvas.Children.Add(tb);
        }

        private void CreateHorizontalLine(int x1, int x2, int y)
        {
            Line line = new Line();
            line.Stroke = Brushes.Black;
            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = y;
            line.Y2 = y;
            _Lines.Add(line);
            _Canvas.Children.Add(line);
        }

        private void SetCheckBoxMargin(CheckBox cb, int Left, int Top)
        {
            Thickness margin = cb.Margin;
            margin.Left = Left;
            margin.Top = Top;
            cb.Margin = margin;
        }

        private Thickness SetMargin<T>(object control, int Left, int Top, int Right, int Bottom) where T : FrameworkElement
        {
            var _control = control as T;
            Thickness margin = _control.Margin;
            margin.Left = Left;
            margin.Top = Top;
            margin.Right = Right;
            margin.Bottom = Bottom;
            return margin;
        }

        private string SetControlName<T>(object control, string text) where T : FrameworkElement
        {
            char trimSymbol = ' ';
            var _control = control as T;
            return text.Trim(trimSymbol);
        }

        private void CreateRectangle(List<Pages> pages, int numberOfRectangles, StatusColor color, string Name, int LeftMargin, int TopMargin)
        {
            Rectangle rect = new Rectangle();
            FillRectangle(rect, color);
            rect.Name = SetControlName<Rectangle>(rect, Name);
            rect.Height = 20;
            SetMargin<Rectangle>(rect, LeftMargin, TopMargin, 0, 0);

            _Rectangles.Add(rect);
            //TODO:set size
        }

        private int CountNumberOfRect(Logic.Task task)
        {
            return (task.Finish - task.Start).Days;
        }

        private void FillRectangle(Rectangle rect, StatusColor color)
        {
            switch (color)
            {
                case StatusColor.Green:
                    rect.Fill = _Brushes[(int)StatusColor.Green];
                    break;
                case StatusColor.Gray:
                    rect.Fill = _Brushes[(int)StatusColor.Gray];
                    break;
                case StatusColor.Yellow:
                    rect.Fill = _Brushes[(int)StatusColor.Yellow];
                    break;
                case StatusColor.Red:
                    rect.Fill = _Brushes[(int)StatusColor.Red];
                    break;
                case StatusColor.White:
                    rect.Fill = _Brushes[(int)StatusColor.White];
                    break;
            }
        }
        //TODO: Search for checkboxes events (Search current task)
    }
}
