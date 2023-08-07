using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Task_Manager
{
    public class TaskManager
    {

        List<Task> tasks;
        const string FilePath = @"C:\\tasks.json";

        public TaskManager()
        {
            tasks = new List<Task>();
            LoadTasksFromJson(); // Load tasks from the JSON file on startup
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void ViewTasks()
        {
            Console.WriteLine("Tasks:");
            int index = 1;
            foreach (var task in tasks)
            {
                Console.WriteLine($"{index}. {task.Title} - Due Date: {task.DueDate} - Status: {(task.IsCompleted ? "Completed" : "Not Completed")}");
                index++;
            }
        }
        public void MarkTaskAsCompleted(int taskIndex)
        {
            if (taskIndex >= 1 && taskIndex <= tasks.Count)
            {
                tasks[taskIndex - 1].IsCompleted = true;
            }
        }

        public void DeleteTask(int taskIndex)
        {
            if (taskIndex >= 1 && taskIndex <= tasks.Count)
            {
                tasks.RemoveAt(taskIndex - 1);
            }
        }

        public void SaveTasksToJson()
        {
            string jsonString = JsonSerializer.Serialize(tasks);
            File.WriteAllText(FilePath, jsonString);
        }

        public void LoadTasksFromJson()
        {
            if (File.Exists(FilePath))
            {
                string jsonString = File.ReadAllText(FilePath);
                tasks = JsonSerializer.Deserialize<List<Task>>(jsonString);
            }
        }
    }
}

