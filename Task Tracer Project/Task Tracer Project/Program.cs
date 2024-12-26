using System.Threading.Channels;
using System.Threading.Tasks;

namespace Task_Tracer_Project
{
     class Program
    {
        static Task[] tasks = new Task[0];

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my task tracer");
            char userRepeat = 'y';
            do
            {
                Console.WriteLine("1. Add task\n2. View All Tasks\n3. Mark task Completed\n4. Remove Task\n5. Exit");
                Console.Write("Enter Your Choice: ");
                int userChoice = -1;
                do
                {
                    userChoice = int.Parse(Console.ReadLine());
                } while (userChoice >= 1 && userChoice <= 5);
                switch (userChoice)
                {
                    case 1:
                        addTask();
                        break;
                    case 2:
                        viewAllTasks();
                        break;
                    case 3:
                        Task task = new Task();
                        Console.Write("Enter Task TiTle that you Completed :)");
                        task.taskTitle = Console.ReadLine();
                        markTaskCompleted(task);
                        break;
                    case 4:
                        Task taskRemoved = new Task();
                        Console.WriteLine("Enter Task TiTle that you Need to Remove :)");
                        taskRemoved.taskTitle = Console.ReadLine();
                        removeTask(taskRemoved);
                        break;
                    default:
                        Console.WriteLine("Thanks. GoodBye!!");
                        Environment.Exit(0);
                        break;

                }
                Console.Write("Do You Want Another Process(Y/N): ");
                userRepeat = Char.ToLower(Char.Parse(Console.ReadLine()));
            } while (userRepeat == 'y');
        }

        static void addTask()
        {
            Task newTask = new Task();
            Console.Write("Enter Task Title: ");
            newTask.taskTitle = Console.ReadLine();
            Console.Write("Enter Task Status:\n1.Completed\n2.Pending\n3.Failed\n");
            if (Enum.TryParse<TaskStatus>(Console.ReadLine(), out var enumChoice))
            {
                newTask.Task_status = (TaskStatus)(enumChoice);
                Task[] newTasks = new Task[tasks.Length + 1];
                tasks.CopyTo(newTasks, 0);
                newTasks[^1] = newTask;
                tasks = newTasks;
                Console.WriteLine("-----------------------------------------");
            }
            else
            {
                Console.WriteLine("invalid Choice");
            }
        }

        static void viewAllTasks()
        {
            foreach (var item in tasks)
            {
                Console.WriteLine($"TaskTitle:{item.taskTitle}|taskStatus:{item.Task_status}|TaskTime:{item.TimeStamp}");
            }
        }

        static void markTaskCompleted(Task task)
        {
            bool taskFound = false;
            foreach (var item in tasks)
            {
                if (item.taskTitle == task.taskTitle)
                {
                    item.Task_status = TaskStatus.Completed;
                    taskFound = true;
                    break;
                }
            }

            if (!taskFound)
            {
                Console.WriteLine("Task not found.");
            }

        }

        static void removeTask(Task task)
        {

            Task[] newTasks = new Task[tasks.Length - 1];
            int index = 0;

            foreach (var item in tasks)
            {
                if (item.taskTitle != task.taskTitle)
                {
                    if (index < newTasks.Length)
                    {
                        newTasks[index] = item;
                        index++;
                    }
                }
            }

            tasks = newTasks;

        }

    }
}
