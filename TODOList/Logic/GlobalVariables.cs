using System;
using System.Collections.Generic;

namespace TODOList.Logic
{
    public static class GlobalVariables
    {
        public static DateTime CurrentDate { get; set; }
        public static List<Project> Projects { get; set; }
        public static Project BufferPrj = new Project();
        public static Task BufferTask;// = new Task();
    }
}
