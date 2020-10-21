using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Logic
{
    public class Task
    {
        public string TaskName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Person Responsible { get; set; }
        public int TaskStatus { get; set; }
        public int TaskStatusColor { get; set; }
        public List<Task> Childrens { get; set; }

        public Task()
        {
            Childrens = new List<Task>();
        }

        public Task(string name, string sdesc, string ldesc, DateTime start, DateTime finish, Person person)
        {
            TaskName = name;
            ShortDescription = sdesc;
            LongDescription = ldesc;
            Start = start;
            Finish = finish;
            Responsible = person;

            Childrens = new List<Task>();
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
    }
}
