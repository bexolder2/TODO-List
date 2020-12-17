using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TODOList.Drawing.Navigation;

namespace TODOList.Drawing
{
    public class DrawDiagram
    {
        public Navigator navigator { get; private set; }

        public DrawDiagram(Grid grid)
        {
            navigator = new Navigator(grid);
        }
    }
}
