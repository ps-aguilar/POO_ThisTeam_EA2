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

        // Materia
        public void AgregarMateria(Materia materia)
        {
            materiasExistentes.Add(materia);
        }

        public int ActualizarMateria(int idMateria, string nuevoNombre, int nuevosCreditos, int nuevoIdMateria)
        {
            for (int i = 0; i < materiasExistentes.Count; i++)
            {
                if (materiasExistentes[i].IdMateria == idMateria)
                {
                    materiasExistentes[i].NombreMateria = nuevoNombre;
                    materiasExistentes[i].Creditos = nuevosCreditos;
                    materiasExistentes[i].IdMateria = nuevoIdMateria;
                    return 1; // Se modificó correctamente.
                }
            }

            return -1; // No se encontró la materia.
        }

        public string MostrarMaterias()
        {
            if (materiasExistentes.Count == 0)
            {
                return "No hay materias registradas."; // Si no hay materias.
            }

            string resultado = "Materias registradas:\n";
            for (int i = 0; i < materiasExistentes.Count; i++)
            {
                resultado += $"ID: {materiasExistentes[i].IdMateria}, Nombre: {materiasExistentes[i].NombreMateria}, Créditos: {materiasExistentes[i].Creditos}\n";
            }

            return resultado; // Retorna la lista de materias.
        }

        public string EliminarMateria(int idMateria)
        {
            for (int i = 0; i < materiasExistentes.Count; i++)
            {
                if (materiasExistentes[i].IdMateria == idMateria)
                {
                    materiasExistentes.RemoveAt(i); // Elimina la materia.
                    return $"La materia con ID {idMateria} ha sido eliminada."; // Mensaje de éxito.
                }
            }

            return $"La materia con ID {idMateria} no existe."; // Si no se encontró.
        }

        // Grupo

        public void AgregarGrupo(Grupo grupo)
        {
            gruposExistentes.Add(grupo);
        }

        public string ActualizarGrupo(int idGrupo, int nuevoIdGrupo, int idMateria, int idMaestro)
        {
            // Buscar el grupo por su ID
            for (int i = 0; i < gruposExistentes.Count; i++)
            {
                if (gruposExistentes[i].IdGrupo == idGrupo)
                {
                    // Buscar materia y maestro
                    Materia materiaEncontrada = BuscarMateria(idMateria);
                    Maestro maestroEncontrado = BuscarMaestro(idMaestro);

                    // Actualizar el grupo si ambos existen
                    if (materiaEncontrada != null && maestroEncontrado != null)
                    {
                        gruposExistentes[i].IdGrupo = nuevoIdGrupo;
                        gruposExistentes[i].Materia = materiaEncontrada;
                        gruposExistentes[i].MaestroEncargado = maestroEncontrado;
                        return "Grupo actualizado exitosamente."; // Mensaje de éxito
                    }
                    else
                    {
                        if (materiaEncontrada == null)
                        {
                            return "El ID de la materia no existe."; // Mensaje de error
                        }
                        if (maestroEncontrado == null)
                        {
                            return "El ID del maestro no existe."; // Mensaje de error
                        }
                    }
                }
            }

            return "Grupo no encontrado."; // Mensaje de error
        }

        public string MostrarGrupos()
        {
            if (gruposExistentes.Count == 0)
            {
                return "No hay grupos registrados.";
            }

            string resultado = "Grupos registrados:\n";
            for (int i = 0; i < gruposExistentes.Count; i++)
            {
                resultado += $"ID: {gruposExistentes[i].IdGrupo}\n";
            }

            return resultado;
        }

        public string EliminarGrupo(int idGrupo)
        {
            // Buscar el grupo por su ID.
            for (int i = 0; i < gruposExistentes.Count; i++)
            {
                if (gruposExistentes[i].IdGrupo == idGrupo)
                {
                    gruposExistentes.RemoveAt(i); // Elimina el grupo.
                    return $"El grupo con ID {idGrupo} ha sido eliminado.";
                }
            }

            return $"El grupo con ID {idGrupo} no existe.";
        }

        // Método para buscar una materia por su ID
        private Materia BuscarMateria(int idMateria)
        {
            for (int i = 0; i < materiasExistentes.Count; i++)
            {
                if (materiasExistentes[i].IdMateria == idMateria)
                {
                    return materiasExistentes[i];
                }
            }
            return null; // Retorna null si no se encuentra
        }

        // Método para buscar un maestro por su ID
        private Maestro BuscarMaestro(int idMaestro)
        {
            for (int i = 0; i < maestrosExistentes.Count; i++)
            {
                if (maestrosExistentes[i].IdMaestro == idMaestro)
                {
                    return maestrosExistentes[i];
                }
            }
            return null; // Retorna null si no se encuentra
        }

        //Maestro

        public void AgregarMaestro(Maestro maestro)
        {
            maestrosExistentes.Add(maestro);
        }

        public int ActualizarMaestro(int idMaestro, string nuevoNombre, string nuevoCorreo, int nuevoIdMaestro)
        {
            for (int i = 0; i < maestrosExistentes.Count; i++)
            {
                if (maestrosExistentes[i].IdMaestro == idMaestro)
                {
                    maestrosExistentes[i].NombreCompleto = nuevoNombre;
                    maestrosExistentes[i].CorreoElectronico = nuevoCorreo;
                    maestrosExistentes[i].IdMaestro = nuevoIdMaestro;
                    return 1; // Actualización exitosa.
                }
            }
            return -1; // Maestro no encontrado.
        }

        public string MostrarMaestros()
        {
            if (maestrosExistentes.Count == 0)
            {
                return "No hay maestros registrados.";
            }

            string resultado = "Maestros registrados:\n";

            for (int i = 0; i < maestrosExistentes.Count; i++)
            {
                resultado += $"ID: {maestrosExistentes[i].IdMaestro}, Nombre: {maestrosExistentes[i].NombreCompleto}, Correo: {maestrosExistentes[i].CorreoElectronico}\n";
            }

            return resultado;
        }

        public string EliminarMaestro(int idMaestro)
        {
            for (int i = 0; i < maestrosExistentes.Count; i++)
            {
                if (maestrosExistentes[i].IdMaestro == idMaestro)
                {
                    maestrosExistentes.RemoveAt(i);
                    return $"El maestro con ID {idMaestro} ha sido eliminado.";
                }
            }

            return $"El maestro con ID {idMaestro} no existe.";
        }

        public string AsignarMaestroAGrupo(int idMaestro, int idGrupo)
        {
            Maestro maestro = null;
            Grupo grupo = null;

            // Buscar el maestro por su ID usando un bucle for
            for (int i = 0; i < maestrosExistentes.Count; i++)
            {
                if (maestrosExistentes[i].IdMaestro == idMaestro)
                {
                    maestro = maestrosExistentes[i];
                    break; // Salir del bucle cuando se encuentre el maestro
                }
            }

            // Buscar el grupo por su ID usando un bucle for
            for (int i = 0; i < gruposExistentes.Count; i++)
            {
                if (gruposExistentes[i].IdGrupo == idGrupo)
                {
                    grupo = gruposExistentes[i];
                    break; // Salir del bucle cuando se encuentre el grupo
                }
            }

            // Verificar si el maestro y el grupo fueron encontrados
            if (maestro == null)
            {
                return $"El maestro con ID {idMaestro} no existe.";
            }

            if (grupo == null)
            {
                return $"El grupo con ID {idGrupo} no existe.";
            }

            // Asignar el grupo al maestro
            maestro.GruposImpartidos.Add(grupo);
            return $"El maestro {maestro.NombreCompleto} ha sido asignado al grupo ID {grupo.IdGrupo.ToString()}.";
        }

        // Alumnos
        public void AgregarAlumno(Alumno alumno)
        {
            alumnosInscritos.Add(alumno);
        }

        public int ActualizarAlumno(int idAlumno, string nuevoNombre, int nuevoIdAlumno)
        {
            for (int i = 0; i < alumnosInscritos.Count; i++)
            {
                if (alumnosInscritos[i].IdAlumno == idAlumno)
                {
                    alumnosInscritos[i].NombreCompleto = nuevoNombre;
                    alumnosInscritos[i].IdAlumno = nuevoIdAlumno;
                    return 1; // Actualización exitosa.
                }
            }
            return -1; // Alumno no encontrado.
        }

        public string MostrarAlumnos()
        {
            if (alumnosInscritos.Count == 0)
            {
                return "No hay alumnos registrados.";
            }

            string resultado = "Alumnos registrados:\n";

            for (int i = 0; i < alumnosInscritos.Count; i++)
            {
                resultado += $"ID: {alumnosInscritos[i].IdAlumno}, Nombre: {alumnosInscritos[i].NombreCompleto}\n";
            }

            return resultado;
        }

        public string EliminarAlumno(int idAlumno)
        {
            for (int i = 0; i < alumnosInscritos.Count; i++)
            {
                if (alumnosInscritos[i].IdAlumno == idAlumno)
                {
                    alumnosInscritos.RemoveAt(i);
                    return $"El alumno con ID {idAlumno} ha sido eliminado.";
                }
            }

            return $"El alumno con ID {idAlumno} no existe.";
        }

        public string AsignarAlumnoAGrupo(int idAlumno, int idGrupo)
        {
            Alumno alumno = null;
            Grupo grupo = null;

            // Buscar el alumno por su ID usando un bucle for
            for (int i = 0; i < alumnosInscritos.Count; i++)
            {
                if (alumnosInscritos[i].IdAlumno == idAlumno)
                {
                    alumno = alumnosInscritos[i];
                    break; // Salir del bucle cuando se encuentre el alumno
                }
            }

            // Buscar el grupo por su ID usando un bucle for
            for (int i = 0; i < gruposExistentes.Count; i++)
            {
                if (gruposExistentes[i].IdGrupo == idGrupo)
                {
                    grupo = gruposExistentes[i];
                    break; // Salir del bucle cuando se encuentre el grupo
                }
            }

            // Verificar si el alumno y el grupo fueron encontrados
            if (alumno == null)
            {
                return $"El alumno con ID {idAlumno} no existe.";
            }

            if (grupo == null)
            {
                return $"El grupo con ID {idGrupo} no existe.";
            }

            // Asignar el grupo al alumno
            alumno.GruposInscritos.Add(grupo);
            return $"El alumno {alumno.NombreCompleto} ha sido asignado al grupo con ID {grupo.IdGrupo.ToString()}.";
        }
    }
}
