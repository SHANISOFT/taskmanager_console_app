
//My task manager console App ( shani k )  


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task_Manager
{
    class Program
    {
        static void Main()
        {
            TaskManager taskManager = new TaskManager();

            while (true)
            {
                Console.WriteLine("\nTask Manager Menu:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Mark Task as Completed");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Save and Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask(taskManager);
                        break;
                    case "2":
                        ViewTasks(taskManager);
                        break;
                    case "3":
                        MarkTaskAsCompleted(taskManager);
                        break;
                    case "4":
                        DeleteTask(taskManager);
                        break;
                    case "5":
                        taskManager.SaveTasksToJson();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddTask(TaskManager taskManager)
        {
            Console.WriteLine("Enter Task Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Task Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter Due Date (YYYY-MM-DD):");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
            {
                Task task = new Task
                {
                    Title = title,

                    Description = description,
                    DueDate = dueDate
                };
                taskManager.AddTask(task);
                Console.WriteLine("Task added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid date format. Task not added.");
            }
        }

        static void ViewTasks(TaskManager taskManager)
        {
            taskManager.ViewTasks();
        }

        static void MarkTaskAsCompleted(TaskManager taskManager)
        {
            Console.WriteLine("Enter the index of the task you want to mark as completed:");
            if (int.TryParse(Console.ReadLine(), out int taskIndex))
            {
                taskManager.MarkTaskAsCompleted(taskIndex);
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Invalid input. Task not marked.");
            }
        }

        static void DeleteTask(TaskManager taskManager)
        {
            Console.WriteLine("Enter the index of the task you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int taskIndex))
            {
                taskManager.DeleteTask(taskIndex);
                Console.WriteLine("Task deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Task not deleted.");
            }
        }
    }

}
