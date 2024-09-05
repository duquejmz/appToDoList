// Program.cs
using System;
using appToDoList.Services;
using appToDoList.Models;

namespace appToDoList
{
    class Program
    {
        static ITaskService taskService = new TaskService();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nMenu To-Do List\n");
                Console.WriteLine("1. Agregar Tareas");
                Console.WriteLine("2. Listar tareas registradas");
                Console.WriteLine("3. Marcar tareas como completadas");
                Console.WriteLine("4. Eliminar Tareas");
                Console.WriteLine("5. Salir");

                var option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1":
                            AddTask();
                            break;
                        case "2":
                            ListTasks();
                            break;
                        case "3":
                            CompleteTask();
                            break;
                        case "4":
                            DeleteTask();
                            break;
                        case "5":
                            Console.WriteLine("\nHa salido del programa");
                            return;
                        default:
                            Console.WriteLine("\nOpción invalida, intenta de nuevo.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nHa ocurrido un error: {ex.Message}");
                }
            }
        }

        static void AddTask()
        {
            Console.WriteLine("\nIngresa la descripción de la tarea: ");
            string descripcion = Console.ReadLine();

            Console.WriteLine("\nIngrese la Fecha Limite (yyyy-mm-dd) o presione enter para omitir: ");
            string dueDateInput = Console.ReadLine();

            DateTime? dueDate = null;
            if (!string.IsNullOrEmpty(dueDateInput))
            {
                if (DateTime.TryParse(dueDateInput, out DateTime parseDate))
                {
                    dueDate = parseDate;
                }
                else
                {
                    Console.WriteLine("\nFormato de Fecha Invalido. La tarea se agregara sin fecha de vencimiento.");
                }
            }

            taskService.AddTask(descripcion, dueDate);
        }

        static void ListTasks()
        {
            Console.WriteLine("\nTareas:");
            var tasks = taskService.GetTasks();
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        static void CompleteTask()
        {
            Console.Write("\nIngrese el número de tarea que desea marcar como completado: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber))
            {
                taskService.CompleteTask(taskNumber);
            }
            else
            {
                Console.WriteLine("\nNúmero de tarea inválido.");
            }
        }

        static void DeleteTask()
        {
            Console.Write("\nIngrese el número de la tarea que desea eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber))
            {
                taskService.DeleteTask(taskNumber);
            }
            else
            {
                Console.WriteLine("\nNúmero de tarea inválido.");
            }
        }
    }
}
