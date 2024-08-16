using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.Models;

namespace To_Do_List
{
    internal class Program
    {
        // Lista generica
        private static List<Tarea> listaTareas = new List<Tarea>();
        static void Main(string[] args)
        {

            bool salir = false;

            while (!salir) // mientras salir sea false ejecuta cuando sea true,  el case 5 salir
                           //pasara a ser true y la ejecucion terminara)
            {   // inicia mostrando el menu
                MostrarMenu();

                try
                {
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        // cada case lleva al metodo seleccionado
                        case 1:
                            AgregarTarea();
                            break;
                        case 2:
                            MostrarTareas();
                            break;
                        case 3:
                            CompletarTarea();
                            break;
                        case 4:
                            EliminarTarea();
                            break;
                        case 5:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("**********************************");
                            Console.WriteLine("*                                *");
                            Console.WriteLine("*  ^~^ Error, opcion no valida   *");
                            Console.WriteLine("*                                *");
                            Console.WriteLine("**********************************");
                            break;

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("**********************************");
                    Console.WriteLine("*                                *");
                    Console.WriteLine("*  ^~^ Error, entrada no valida  *");
                    Console.WriteLine("*         elige un numero        *");
                    Console.WriteLine("**********************************");
                }
            }


        }

        private static void MostrarMenu()
        {

            Console.WriteLine("**********************************");
            Console.WriteLine("*           To-Do List           *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*  1. Agregar Tarea              *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*  2. Mostrar Tareas             *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*  3. Completar Tarea            *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*  4. Eliminar Tarea             *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*  5. Salir                      *");
            Console.WriteLine("*                                *");
            Console.WriteLine("**********************************");

        }

        private static void AgregarTarea()
        {
            // Inicio estos metodos con el Console.Clear() para no saturar la consola de informacion
            Console.Clear();

            Console.WriteLine("Introduce el titulo de la tarea:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Introduce la descripcion de la tarea");
            string descripcion = Console.ReadLine();

            Console.WriteLine("Introduce la fecha limite en el formato; Día-Mes-Año");
            string inputFecha = Console.ReadLine();
            DateTime? fechaLimite = null;

            if (!string.IsNullOrEmpty(inputFecha))
            {
                string formato = "dd-MM-yyyy";
                DateTime fechaTemp;
                // le doy el formato dd-mm-yyyy para que sea mas facil ya que es el que usan casi todos
                while (!DateTime.TryParseExact(inputFecha, formato, null, System.Globalization.DateTimeStyles.None, out fechaTemp))
                {
                    Console.WriteLine("******************************************");
                    Console.WriteLine("*                                        *");
                    Console.WriteLine("*  ^~^ Error, formato de fecha invalido  *");
                    Console.WriteLine("*                                        *");
                    Console.WriteLine("******************************************");
                    inputFecha = Console.ReadLine();
                    if (string.IsNullOrEmpty(inputFecha))
                    {
                        break; // si deja en blanco despues del error se sale del bucle
                    }
                }

                if (!string.IsNullOrEmpty(inputFecha))
                {
                    fechaLimite = fechaTemp; // Solo asigna fecha si es valida
                }
            }
            // en caso de todo estar bien guarda la tarea y se puede ver en MostrarTareas()
            listaTareas.Add(new Tarea(titulo, descripcion, fechaLimite));
            Console.WriteLine("*************************************");
            Console.WriteLine("*                                   *");
            Console.WriteLine("* ^U^ ¡Tarea Agregado Exitosamente! *");
            Console.WriteLine("*                                   *");
            Console.WriteLine("*************************************");
        }

        private static void MostrarTareas()
        {
            // Limpia la consola para que sea más facil mostrar las tareas
            Console.Clear();

            Console.WriteLine("Lista de tareas:");
            // si no hay ninguna tarea te saca el siguiente mensaje
            if (listaTareas.Count == 0)
            {
                Console.WriteLine("******************************************");
                Console.WriteLine("*                                        *");
                Console.WriteLine("*  ^o^ Oops, no hay tareas en tu lista   *");
                Console.WriteLine("*             ¡Agrega una! :D            *");
                Console.WriteLine("******************************************");
                return;
            }
            else
            {
                // doy un indice a cada tarea (para el usuario apareceria como 1), para poder hacer el metodo BorrarTarea()
                for (int i = 0; i < listaTareas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {listaTareas[i]}");
                }
            }


        }

        private static void CompletarTarea()
        {

            Console.Clear();
            // Ver las tareas que tengo y cual deseo marcar como completa
            MostrarTareas();

            Console.Write("Introduce el número de la tarea que deseas marcar como completa: ");
            try
            {
                int indice = int.Parse(Console.ReadLine()) - 1; // resta 1 al numero ingresado para ajustar el indice

                // verifica que el indice no sea negativo y que no sea mayor al numero total de elemento en la lista
                if (indice >= 0 && indice < listaTareas.Count)
                {
                    listaTareas[indice].Completar();// utiliza el metodo que escribi en la clase Tarea.cs
                    Console.WriteLine("**************************************");
                    Console.WriteLine("*                                    *");
                    Console.WriteLine("* ^U^¡Tarea Completada Exitosamente! *");
                    Console.WriteLine("*                                    *");
                    Console.WriteLine("**************************************");
                }
                else
                {
                    Console.WriteLine("******************************************");
                    Console.WriteLine("*                                        *");
                    Console.WriteLine("*  ^~^ Error, numero de tarea invalido   *");
                    Console.WriteLine("*                                        *");
                    Console.WriteLine("******************************************");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("**********************************");
                Console.WriteLine("*                                *");
                Console.WriteLine("*  ^~^ Error, entrada no valida  *");
                Console.WriteLine("*         elige un numero        *");
                Console.WriteLine("**********************************");
                return;
            }

        }

        private static void EliminarTarea()
        {

            Console.Clear();

            MostrarTareas();

            Console.Write("Introduce el número de la tarea que deseas eliminar: ");

            try
            {
                int indice = int.Parse(Console.ReadLine()) - 1; // resta 1 al numero ingresado para ajustar el indice
                // verifica que el indice no sea negativo y que no sea mayor al numero total de elemento en la lista
                if (indice >= 0 && indice < listaTareas.Count)
                {
                    listaTareas.RemoveAt(indice);
                    Console.WriteLine("**************************************");
                    Console.WriteLine("*                                    *");
                    Console.WriteLine("*  ^U^ Tarea Eliminada Exitosamente! *");
                    Console.WriteLine("*                                    *");
                    Console.WriteLine("**************************************");
                }
                else
                {
                    Console.WriteLine("******************************************");
                    Console.WriteLine("*                                        *");
                    Console.WriteLine("*  ^~^ Error, numero de tarea invalido   *");
                    Console.WriteLine("*                                        *");
                    Console.WriteLine("******************************************");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("**********************************");
                Console.WriteLine("*                                *");
                Console.WriteLine("*  ^~^ Error, entrada no valida  *");
                Console.WriteLine("*         elige un numero        *");
                Console.WriteLine("**********************************");
                return;
            }

        }

    }
}