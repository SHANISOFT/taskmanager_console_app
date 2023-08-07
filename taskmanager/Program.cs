// See https://aka.ms/new-console-template for more information
using System;
[Serializable]
public class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}