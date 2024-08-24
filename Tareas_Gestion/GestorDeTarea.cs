using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class GestorDeTareas
{
    // Lista privada para almacenar las tareas
    private List<Tarea> _listaDeTareas;

    // Inicia la lista de tareas
    public GestorDeTareas()
    {
        _listaDeTareas = new List<Tarea>();
    }

    // para agregar una nueva tarea a la lista
    public void AgregarTarea(string descripcion, DateTime? fechaLimite = null)
    {
        Tarea nuevaTarea = new Tarea(descripcion, fechaLimite);
        _listaDeTareas.Add(nuevaTarea);
    }

    // para obtener todas las tareas
    public List<Tarea> ObtenerTareas()
    {
        return _listaDeTareas;
    }

    // para marcar una tarea como completada
    public bool MarcarTareaComoCompletada(int indice)
    {
        // Para verificar que el numero de tareas ingresada si exista
        if (indice >= 0 && indice < _listaDeTareas.Count)
        {
            _listaDeTareas[indice].MarcarComoCompletada();
            return true;
        }
        return false; 
    }

    // para eliminar una tarea de la lista
    public bool EliminarTarea(int indice)
    {
        // Verificar que numero ingresada este dentro del rango
        if (indice >= 0 && indice < _listaDeTareas.Count)
        {
            _listaDeTareas.RemoveAt(indice);
            return true; 
        }
        return false; 
    }
}
