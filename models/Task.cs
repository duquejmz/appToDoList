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
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion), "La descripci�n no puede ser nula");
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
            string dueDateString = DueDate.HasValue ? DueDate.Value.ToString("yyyy-MM-dd") : "Sin fecha l�mite";
            return $"{Descripcion} - Fecha L�mite: {dueDateString} - Estado: {status}";
        }
    }
}
