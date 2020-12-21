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
        public List<List<Pages>> pages_ { get; private set; }
        public Frames frame_ { get; private set; }
        public int CurrentPage { get; set; }
        public int CurrentYear { get; set; }
        public DateTime Year { get; set; }

        public Navigator(Grid grid)
        {
            pages_ = new List<List<Pages>>();
            frame_ = new Frames();
            frame_.CreateFrame(grid);
            CurrentPage = 0;
            CurrentYear = 0;
            Year = DateTime.Now;
        }

        public void AddPages(Frames fr)
        {
            int year = DateTime.Now.Year;

            for (int i = 0; i <= frame_.NumberOfYears; i++)
            {
                List<Pages> p = new List<Pages>();
                for (int j = 0; j < 12; j++)
                {
                    p.Add(PageConstructor(fr, year, j + 1));
                }
                pages_.Add(p);
                ++year;
            }
        }

        private Pages PageConstructor(Frames fr, int year, int month)
        {
            Pages page = new Pages();
            page.CreatePage(fr, year, month);
            return page;
        }
    }
}
