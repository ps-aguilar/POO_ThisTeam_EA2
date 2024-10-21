using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ThisTeam_EA2
{
    internal class Escuela
    {
        private List<Grupo> gruposExistentes;
        private List<Maestro> maestrosExistentes;
        private List<Alumno> alumnosInscritos;
        private List<Carrera> carrerasExistentes;
        private List<Materia> materiasExistentes;

        public Escuela()
        {
            gruposExistentes = new List<Grupo>();
            maestrosExistentes = new List<Maestro>();
            alumnosInscritos = new List<Alumno>();
            carrerasExistentes = new List<Carrera>
            {
                new Carrera(1, "Ingeniería en Software"),
                new Carrera(2, "Medicina"),
                new Carrera(3, "Arquitectura"),
            };
            materiasExistentes = new List<Materia>();
        }

        // Carreras
        public void AgregarCarrera(Carrera carrera)
        {
            carrerasExistentes.Add(carrera);
        }

        public int ActualizarCarrera(int idCarrera, string nuevoNombre, int nuevoIdCarrera)
        {
            for (int i = 0; i < carrerasExistentes.Count; i++)
            {
                if (carrerasExistentes[i].IdCarrera == idCarrera)
                {
                    carrerasExistentes[i].NombreCarrera = nuevoNombre;
                    carrerasExistentes[i].IdCarrera = nuevoIdCarrera;
                    return 1; // Modificado correctamente
                }
            }
            return -1; // No se encontró la carrera
        }

        public string MostrarCarreras()
        {
            if (carrerasExistentes.Count == 0)
            {
                return "No hay carreras disponibles.";
            }

            string resultado = "Carreras disponibles:\n";
            for (int i = 0; i < carrerasExistentes.Count; i++)
            {
                resultado += $"ID: {carrerasExistentes[i].IdCarrera}, Nombre: {carrerasExistentes[i].NombreCarrera}\n";
            }
            return resultado;
        }

        public string EliminarCarrera(int idCarrera)
        {
            for (int i = 0; i < carrerasExistentes.Count; i++)
            {
                if (carrerasExistentes[i].IdCarrera == idCarrera)
                {
                    carrerasExistentes.RemoveAt(i);
                    return $"La carrera con ID {idCarrera} ha sido eliminada.";
                }
            }
            return $"La carrera con ID {idCarrera} no existe.";
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
                    return 1; // Modificado correctamente
                }
            }
            return -1; // No se encontró la materia
        }

        public string MostrarMaterias()
        {
            if (materiasExistentes.Count == 0)
            {
                return "No hay materias registradas.";
            }

            string resultado = "Materias registradas:\n";
            for (int i = 0; i < materiasExistentes.Count; i++)
            {
                resultado += $"ID: {materiasExistentes[i].IdMateria}, Nombre: {materiasExistentes[i].NombreMateria}, Créditos: {materiasExistentes[i].Creditos}\n";
            }
            return resultado;
        }

        public string EliminarMateria(int idMateria)
        {
            for (int i = 0; i < materiasExistentes.Count; i++)
            {
                if (materiasExistentes[i].IdMateria == idMateria)
                {
                    materiasExistentes.RemoveAt(i);
                    return $"La materia con ID {idMateria} ha sido eliminada.";
                }
            }
            return $"La materia con ID {idMateria} no existe.";
        }

        // Grupo
        public void AgregarGrupo(Grupo grupo)
        {
            gruposExistentes.Add(grupo);
        }

        public string ActualizarGrupo(int idGrupo, int nuevoIdGrupo, int idMateria, int idMaestro)
        {
            for (int i = 0; i < gruposExistentes.Count; i++)
            {
                if (gruposExistentes[i].IdGrupo == idGrupo)
                {
                    Materia materiaEncontrada = BuscarMateria(idMateria);
                    Maestro maestroEncontrado = BuscarMaestro(idMaestro);

                    if (materiaEncontrada != null && maestroEncontrado != null)
                    {
                        gruposExistentes[i].IdGrupo = nuevoIdGrupo;
                        gruposExistentes[i].Materia = materiaEncontrada;
                        gruposExistentes[i].MaestroEncargado = maestroEncontrado;
                        return "Grupo actualizado exitosamente.";
                    }
                    else
                    {
                        if (materiaEncontrada == null)
                        {
                            return "El ID de la materia no existe.";
                        }
                        if (maestroEncontrado == null)
                        {
                            return "El ID del maestro no existe.";
                        }
                    }
                }
            }
            return "Grupo no encontrado.";
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
            for (int i = 0; i < gruposExistentes.Count; i++)
            {
                if (gruposExistentes[i].IdGrupo == idGrupo)
                {
                    gruposExistentes.RemoveAt(i);
                    return $"El grupo con ID {idGrupo} ha sido eliminado.";
                }
            }
            return $"El grupo con ID {idGrupo} no existe.";
        }

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

        // Maestro
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
                    return 1; // Actualización exitosa
                }
            }
            return -1; // Maestro no encontrado
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

            for (int i = 0; i < maestrosExistentes.Count; i++)
            {
                if (maestrosExistentes[i].IdMaestro == idMaestro)
                {
                    maestro = maestrosExistentes[i];
                    break; // Salir del bucle
                }
            }

            for (int i = 0; i < gruposExistentes.Count; i++)
            {
                if (gruposExistentes[i].IdGrupo == idGrupo)
                {
                    grupo = gruposExistentes[i];
                    break; // Salir del bucle
                }
            }

            if (maestro == null)
            {
                return "Maestro no encontrado.";
            }
            if (grupo == null)
            {
                return "Grupo no encontrado.";
            }

            grupo.MaestroEncargado = maestro;
            return $"Maestro {maestro.NombreCompleto} asignado al grupo {grupo.IdGrupo} correctamente.";
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
                    return 1; // Actualización exitosa
                }
            }
            return -1; // Alumno no encontrado
        }

        public string MostrarAlumnos()
        {
            if (alumnosInscritos.Count == 0)
            {
                return "No hay alumnos inscritos.";
            }

            string resultado = "Alumnos inscritos:\n";
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
    }
}
