﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Logic
{
    public class Task : IDataErrorInfo
    {
        public string TaskName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Person Responsible { get; set; }
        public string BufferResponsible { get; set; } //TODO:buff -> Responsible.Name
        public int TaskStatus { get; set; }
        public int TaskStatusColor { get; set; }
        public List<Task> Children { get; set; }

        public Task()
        {
            Children = new List<Task>();
            Responsible = new Person();
            Start = DateTime.Now;
            Finish = DateTime.Now;
        }

        public Task(string name, string sdesc, string ldesc, DateTime start, DateTime finish, Person person)
        {
            TaskName = name;
            ShortDescription = sdesc;
            LongDescription = ldesc;
            Start = start;
            Finish = finish;
            Responsible = person;

            Children = new List<Task>();
        }

        public void SetStatus(Status status)
        {
            TaskStatus = (int)status;
            TaskStatusColor = TaskStatus;
        }

        public void AddChildren()
        {

        }

        public void DeleteChildren()
        {

        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "TaskName":
                        if(TaskName == null)
                        {
                            error = "Enter correct name.";
                        }
                        break;
                    case "ShortDescription":
                        break;
                    case "LongDescription":
                        break;
                    case "Start":
                        if (Start.Date < DateTime.Now.Date)
                        {
                            error = "Enter correct start date.";
                        }
                        break;
                    case "Finish":
                        if(Finish.Date < DateTime.Now.Date & Finish.Date < Start.Date)
                        {
                            error = "Enter correct finish date.";
                        }
                        break;
                    case "BufferResponsible":
                        if (BufferResponsible == null)
                        {
                            error = "Enter correct person name.";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

    }
}
