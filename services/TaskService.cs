// TaskService.cs
using System;
using System.Collections.Generic;
using appToDoList.Models; // Asegúrate de que este namespace esté incluido

namespace appToDoList.Services
{
    public class TaskService : ITaskService
    {
        private List<appToDoList.Models.Task> tasks = new List<appToDoList.Models.Task>();

        public void AddTask(string descripcion, DateTime? dueDate)
        {
            tasks.Add(new appToDoList.Models.Task(descripcion, dueDate));
        }

        public IList<appToDoList.Models.Task> GetTasks()
        {
            return tasks;
        }

        public void CompleteTask(int taskNumber)
        {
            if (taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks[taskNumber - 1].MarkAsCompleted();
            }
        }

        public void DeleteTask(int taskNumber)
        {
            if (taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks.RemoveAt(taskNumber - 1);
            }
        }
    }
}
