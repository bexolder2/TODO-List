using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TODOList.Drawing.Navigation
{
    public class Navigator
    {
        public List<Pages> pages_ { get; private set; }
        public Frames frame_ { get; private set; }
        public int CurrentPage { get; set; }

        public Navigator(Grid grid)
        {
            pages_ = new List<Pages>();
            frame_ = new Frames();
            frame_.CreateFrame(grid);
            CurrentPage = 0;
        }

        public void AddPage(int month)
        {
            Pages page = new Pages();
            page.CreatePage(month);
            pages_.Add(page);
        }
    }
}
