// Services/ITaskService.cs
using System.Collections.Generic;
using appToDoList.Models;

namespace appToDoList.Services
{
	public interface ITaskService
	{
		void AddTask(string descripcion, DateTime? dueDate);
        IList<appToDoList.Models.Task> GetTasks();
        void CompleteTask(int taskNumber);
		void DeleteTask(int taskNumber);
	}
}
