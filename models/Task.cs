// Models/Task.cs
using System;

namespace appToDoList.Models
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
            string dueDateString = DueDate.HasValue ? DueDate.Value.ToString("yyyy-MM-dd") : "Sin fecha límite";
            return $"{Descripcion} - Fecha Límite: {dueDateString} - Estado: {status}";
        }
    }
}
