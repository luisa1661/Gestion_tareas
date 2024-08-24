using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Menu
{
    // gestor de tareas que maneja la lista de tareas
    private GestorDeTareas _gestorDeTareas;

    public Menu(GestorDeTareas gestorDeTareas)
    {
        _gestorDeTareas = gestorDeTareas;
    }

    // muestra el menú y maneja laa interacciones del usuario
    public void Mostrar()
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("Gestión de Tareas");
            Console.WriteLine("1. Agregar Tarea");
            Console.WriteLine("2. Listar Tareas");
            Console.WriteLine("3. Marcar Tarea como Completada");
            Console.WriteLine("4. Eliminar Tarea");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarTarea();
                    break;
                case "2":
                    ListarTareas();
                    break;
                case "3":
                    MarcarTareaComoCompletada();
                    break;
                case "4":
                    EliminarTarea();
                    break;
                case "5":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("La opcion ingreasad no es valida. Presione Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    // agregar una nueva tarea
    private void AgregarTarea()
    {
        Console.Clear();
        Console.WriteLine("Agregar nueva tarea");

        Console.Write("Descripción: ");
        string descripcion = Console.ReadLine();

        Console.Write("Fecha límite (opcional, formato: yyyy-mm-dd): ");
        string fechaInput = Console.ReadLine();
        DateTime? fechaLimite = null;

        if (!string.IsNullOrEmpty(fechaInput) && DateTime.TryParse(fechaInput, out DateTime fecha))
        {
            fechaLimite = fecha;
        }

        _gestorDeTareas.AgregarTarea(descripcion, fechaLimite);

        Console.WriteLine("Tarea agregada. Presione Enter para continuar...");
        Console.ReadLine();
    }

    // listar todas las tareas
    private void ListarTareas()
    {
        Console.Clear();
        Console.WriteLine("Lista de tareas");

        var tareas = _gestorDeTareas.ObtenerTareas();
        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas registradas.");
        }
        else
        {
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    // marcar una tarea como completada
    private void MarcarTareaComoCompletada()
    {
        Console.Clear();
        Console.WriteLine("Marcar tarea como completada");

        ListarTareas();

        Console.Write("Seleccione el número de la tarea a marcar como completada: ");
        if (int.TryParse(Console.ReadLine(), out int numeroTarea) && numeroTarea >= 1)
        {
            if (_gestorDeTareas.MarcarTareaComoCompletada(numeroTarea - 1))
            {
                Console.WriteLine("Tarea marcada como completada.");
            }
            else
            {
                Console.WriteLine("Número de tarea no válido.");
            }
        }
        else
        {
            Console.WriteLine("Número de tarea no válido.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    // para eliminar una tarea
    private void EliminarTarea()
    {
        Console.Clear();
        Console.WriteLine("Eliminar tarea");

        ListarTareas();

        Console.Write("Seleccione el número de la tarea a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int numeroTarea) && numeroTarea >= 1)
        {
            if (_gestorDeTareas.EliminarTarea(numeroTarea - 1))
            {
                Console.WriteLine("Tarea eliminada.");
            }
            else
            {
                Console.WriteLine("Número de tarea no válido.");
            }
        }
        else
        {
            Console.WriteLine("Número de tarea no válido.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }
}

