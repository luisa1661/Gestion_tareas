using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tarea
{
    // almacena la descripción de la tarea
    public string Descripcion { get; set; }

    // almacena la fecha límite de la tarea (opcional)
    public DateTime? FechaLimite { get; set; }

    // indica si la tarea está completada o no
    public bool Completada { get; private set; }

    // Constructor de la clase Tarea
    public Tarea(string descripcion, DateTime? fechaLimite = null)
    {
        Descripcion = descripcion;
        FechaLimite = fechaLimite;
        Completada = false; 
    }

    // para marcar la tarea como completada
    public void MarcarComoCompletada()
    {
        Completada = true;
    }

    // para obtener una representación en cadena de la tarea
    public override string ToString()
    {
        string fecha = FechaLimite.HasValue ? FechaLimite.Value.ToString("yyyy-MM-dd") : "Sin fecha";
        // Estado de la tarea: "Completada" o "Pendiente"
        string estado = Completada ? "Completada" : "Pendiente";
        return $"{Descripcion} (Fecha límite: {fecha}) - {estado}";
    }
}

