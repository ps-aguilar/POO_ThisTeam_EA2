using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ThisTeam_EA2
{
    internal class Escuela
    {
        //Lista que almacena los grupos existentes en la escuela.
        private List<Grupo> gruposExistentes;
        //Lista que almacena los maestros existentes en la escuela.
        private List<Maestro> maestrosExistentes;
        //Lista que almacena los alumnos inscritos en la escuela.
        private List<Alumno> alumnosInscritos;
        //Lista que almacena las carreras en la escuela.
        private List<Carrera> carrerasExistentes;
        //Lista que almacena las materias existentes en la escuela.
        private List<Materia> materiasExistentes;


        //Constructor que inicializa las listas.
        public Escuela()
        {
            gruposExistentes = new List<Grupo>();
            maestrosExistentes = new List<Maestro>();
            alumnosInscritos = new List<Alumno>();
            carrerasExistentes = new List<Carrera>()
            {
                new Carrera(1, "Ingeniería en Software"),
                new Carrera(2, "Medicina"),
                new Carrera(3, "Arquitectura"),
            };
            materiasExistentes = new List<Materia>();
        }


        //Carreras
        public void AgregarCarrera(Carrera carrera)
        {
            carrerasExistentes.Add(carrera);
        }

        public int ActualizarCarrera(int idCarrera, string nuevoNombre, int nuevoIdCarrera)
        {
            // Buscar la carrera por su ID usando un ciclo for.
            for (int i = 0; i < carrerasExistentes.Count; i++)
            {
                if (carrerasExistentes[i].IdCarrera == idCarrera)
                {
                    // Si encuentra la carrera, actualizar sus valores.
                    carrerasExistentes[i].NombreCarrera = nuevoNombre;
                    carrerasExistentes[i].IdCarrera = nuevoIdCarrera;
                    return 1; // Devuelve 1 para indicar que se modificó correctamente.
                }
            }

            return -1; // Devuelve -1 si no se encontró la carrera.
        }
        
        public string MostrarCarreras()
        {
            if (carrerasExistentes.Count == 0)
            {
                return "No hay carreras disponibles."; // Si la lista está vacía.
            }

            string resultado = "Carreras disponibles:\n";

            // Recorre la lista de carreras y concatena el ID y Nombre de cada carrera.
            for (int i = 0; i < carrerasExistentes.Count; i++)
            {
                resultado += $"ID: {carrerasExistentes[i].IdCarrera}, Nombre: {carrerasExistentes[i].NombreCarrera}\n";
            }

            return resultado; // Devuelve el string con las carreras.
        }

        public string EliminarCarrera(int idCarrera)
        {
            // Recorre la lista de carreras para buscar la carrera con el ID proporcionado.
            for (int i = 0; i < carrerasExistentes.Count; i++)
            {
                if (carrerasExistentes[i].IdCarrera == idCarrera)
                {
                    carrerasExistentes.RemoveAt(i); // Elimina la carrera.
                    return $"La carrera con ID {idCarrera} ha sido eliminada."; // Mensaje de éxito.
                }
            }

            return $"La carrera con ID {idCarrera} no existe."; // Si no se encuentra la carrera.
        }

        // Maestro
        
    }
}
