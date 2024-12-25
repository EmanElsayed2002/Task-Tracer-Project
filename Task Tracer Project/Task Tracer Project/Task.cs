using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Tracer_Project
{
    public enum TaskStatus
    {
        Completed,
        Pending,
        Failed
    }



    class Task
    {
        public string taskTitle { get; set; }
        public TaskStatus Task_status { get; set; }
        public DateTime TimeStamp { get; } = DateTime.Now;
        public Task()
        {
            Console.WriteLine("Your Task is initalized");
        }

        public Task(string title ,TaskStatus state )
        {
            taskTitle = title;
            Task_status = state;            
        }

        public override string ToString()
        {
            return $"TaskTitle:{taskTitle}|Task_status:{Task_status}";
        }
    }
}
