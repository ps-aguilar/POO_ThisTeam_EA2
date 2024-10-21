using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ThisTeam_EA2
{
    internal class Menu
    {
        private List<Opcion> opciones;  // Lista de opciones que se mostrarán en el menú
        private string titulo;           // Título del menú

        public Menu(string titulo, List<Opcion> opciones)
        {
            this.titulo = titulo;
            this.opciones = opciones;
        }

        public void Continuar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar");
            Console.ReadKey();
        }

        public void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("**** {0} ****\n", titulo);
            for (int i = 0; i < opciones.Count; i++)
            {
                Console.Write("{0}) ", (i + 1));
                Console.WriteLine("{0}", opciones[i].Message);
            }
            Console.Write("\nSelecciona una opción: ");
        }


        public int SeleccionarOpcion()
        {
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > opciones.Count)
            {
                Console.WriteLine("Opción no válida, intenta de nuevo.");
                MostrarMenu(); // Vuelve a mostrar el menú
            }
            return opcion;
        }
    }
}
