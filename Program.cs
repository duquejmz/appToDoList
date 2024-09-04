using System;
using System.Collections.Generic;

namespace appToDoList
{
    public class Task
    {
        public string Descripcion { get; private set; }
        public DateTime? DueDate { get; private set; }
        public bool Completada { get; private set; }

        public Task(string descripcion, DateTime? dueDate = null)
        {
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion), "La descripción no puede ser nula");
            DueDate = dueDate;
            Completada = false;
        }

        public void MarkAsCompleted()
        {
            Completada = true;
        }

        public override string ToString()
        {
            string status = Completada ? "Completada" : "Pendiente";
            string dueDateString = DueDate.HasValue ? DueDate.Value.ToString("yyyy-MM-dd") : "Sin fecha limite";
            return $"{Descripcion} - Fecha Límite: {dueDateString} - Estado: {status}"; 
        }
    }

    class Program
    {
        static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nMenu To-Do List");
                Console.WriteLine("\n1. Agregar Tareas");
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

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                Console.WriteLine("\nLa descripción no puede estar vacía.");
                return;
            }

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

            tasks.Add(new Task(descripcion, dueDate));
            Console.WriteLine("\nTarea agregada");
        }

        static void ListTasks()
        {
            Console.WriteLine("\nTareas:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        static void CompleteTask()
        {
            Console.Write("\nIngrese el numero de tarea que desea marcar como completado: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks[taskNumber - 1].MarkAsCompleted();
                Console.WriteLine("\n¡Tarea marcada como completa!");
            }
            else
            {
                Console.WriteLine("\nNumero de Tarea Invalido.");
            }
        }

        static void DeleteTask()
        {
            Console.Write("\nIngrese el número de la tarea que desea eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks.RemoveAt(taskNumber - 1);
                Console.WriteLine("\nTarea Eliminada");
            }
            else
            {
                Console.WriteLine("\nNumero de tarea invalido.");
            }
        }
    }
}
