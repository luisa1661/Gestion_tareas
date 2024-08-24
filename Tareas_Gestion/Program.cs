using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // instancia del gestor de tareas
        GestorDeTareas gestorDeTareas = new GestorDeTareas();

        // instancia del menú, pasando el gestor de tareas
        Menu menu = new Menu(gestorDeTareas);

        // menú y gestionar la interacción del usuario
        menu.Mostrar();
    }
}

