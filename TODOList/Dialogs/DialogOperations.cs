﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Logic;

namespace TODOList.Dialogs
{
    public static class DialogOperations
    {
        public static event Action InitProject;
        //public static event Action NewTask;
        public static void GetNewProjectData(Project project)
        {
            GlobalVariables.newPr = null;
            GlobalVariables.newPr = new DialogXaml.NewProject();
            InitProject?.Invoke();
            GlobalVariables.newPr.ShowDialog();
            GlobalVariables.DrawingTabControl.drawTT.GetTreeViewItemFocus();//TODO: При закрытии без создания ошибка
        }

        public static void GetTaskData(GlobalVariables.Operations operation = GlobalVariables.Operations.Add)
        {
            GlobalVariables.newTask = null;
            GlobalVariables.newTask = new DialogXaml.NewTask();
            if (operation == GlobalVariables.Operations.Edit)
            {
                GlobalVariables.DrawingTabControl.drawTT.
                    Search(Program.Prj.Find(x => x.ProjectName == GlobalVariables.DrawingTabControl.GetFocusTabItemHeader()),
                                                 GlobalVariables.Operations.FillBuffer);
                GlobalVariables.newTask.EditMode();
            }    
            //NewTask?.Invoke();
            GlobalVariables.newTask.ShowDialog(); 
        }
    }
}
