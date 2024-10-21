using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ThisTeam_EA2
{
    class InterfazUsuario
    {
        private List<Opcion> opcionesPrincipal;
        private Menu menuPrincipal;
        private bool dentroMenuPrincipal = true;
        private Escuela Escuela;

        public InterfazUsuario(Escuela escuela)
        {
            Escuela = escuela; // Inicializa la instancia de Escuela

            opcionesPrincipal = new List<Opcion>()
            {
                new Opcion("Carrera", Carrera),
                new Opcion("Materia", Materia),
                new Opcion("Grupo", Grupo),
                new Opcion("Maestro", Maestro),
                new Opcion("Alumno", Alumno),
                new Opcion("Salir", Salir),
            };

            menuPrincipal = new Menu("Menú Escuela", opcionesPrincipal);

            while (dentroMenuPrincipal)
            {
                menuPrincipal.MostrarMenu();
                int opcion = menuPrincipal.SeleccionarOpcion();
                opcionesPrincipal[opcion - 1].Action.Invoke();
            }
        }

        public void Carrera()
        {
            bool dentroMenuCarrera = true;

            List<Opcion> opcionesCarrera = new List<Opcion>
            {
                new Opcion("Registrar carrera.", RegistrarCarrera),
                new Opcion("Ver carreras existentes.", () => Console.WriteLine(Escuela.MostrarCarreras())),
                new Opcion("Actualizar carrera existente", ActualizarCarrera),
                new Opcion("Eliminar carrera existente.", EliminarCarrera),
                new Opcion("Regresar a Menú Principal", () => { dentroMenuCarrera = false; RegresarPrincipal(); })
            };

            Menu menuCarrera = new Menu("Menú de las Carreras", opcionesCarrera);

            while (dentroMenuCarrera)
            {
                menuCarrera.MostrarMenu();
                int opcion = menuCarrera.SeleccionarOpcion();
                Console.WriteLine();
                opcionesCarrera[opcion - 1].Action.Invoke();
                menuCarrera.Continuar();
            }
        }

        public void RegistrarCarrera()
        {
            try
            {
                Console.Write("Ingrese el nombre de la carrera: ");
                string nombreCarrera = Console.ReadLine();

                Console.Write("Ingrese el ID de la carrera: ");
                int idCarrera = int.Parse(Console.ReadLine());

                Carrera carrera = new Carrera(idCarrera, nombreCarrera);
                Escuela.AgregarCarrera(carrera);

                Console.WriteLine("Carrera registrada exitosamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El ID de la carrera debe ser un número válido.");
            }
        }

        public void ActualizarCarrera()
        {
            try
            {
                Console.Write("Ingrese el ID de la carrera que desea actualizar: ");
                int idCarrera = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el nuevo nombre de la carrera: ");
                string nuevoNombre = Console.ReadLine();

                Console.Write("Ingrese el nuevo ID de la carrera: ");
                int nuevoIdCarrera = int.Parse(Console.ReadLine());

                int resultado = Escuela.ActualizarCarrera(idCarrera, nuevoNombre, nuevoIdCarrera);

                if (resultado == 1)
                {
                    Console.WriteLine("Carrera actualizada exitosamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró la carrera con el ID especificado.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El ID de la carrera debe ser un número válido.");
            }
        }

        public void EliminarCarrera()
        {
            try
            {
                Console.Write("Ingrese el ID de la carrera que desea eliminar: ");
                int idCarrera = int.Parse(Console.ReadLine());
                Console.WriteLine(Escuela.EliminarCarrera(idCarrera));
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El ID de la carrera debe ser un número válido.");
            }
        }

        // Materia
        public void Materia()
        {
            bool dentroMenuMateria = true;

            List<Opcion> opcionesMateria = new List<Opcion>
            {
                new Opcion("Registrar materia.", RegistrarMateria),
                new Opcion("Ver materias existentes.", () => Console.WriteLine(Escuela.MostrarMaterias())),
                new Opcion("Actualizar materia existente", ActualizarMateria),
                new Opcion("Eliminar materia existente.", EliminarMateria),
                new Opcion("Regresar a Menú Principal", () => { dentroMenuMateria = false; RegresarPrincipal(); })
            };

            Menu menuMateria = new Menu("Menú de las Materias", opcionesMateria);

            while (dentroMenuMateria)
            {
                menuMateria.MostrarMenu();
                int opcion = menuMateria.SeleccionarOpcion();
                Console.WriteLine();
                opcionesMateria[opcion - 1].Action.Invoke();
                menuMateria.Continuar();
            }
        }

        public void RegistrarMateria()
        {
            try
            {
                Console.Write("Ingrese el nombre de la materia: ");
                string nombreMateria = Console.ReadLine();

                Console.Write("Ingrese el ID de la materia: ");
                int idMateria = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el número de créditos de la materia: ");
                int numeroCreditos = int.Parse(Console.ReadLine());

                Materia materia = new Materia(idMateria, nombreMateria, numeroCreditos);
                Escuela.AgregarMateria(materia);

                Console.WriteLine("Materia registrada exitosamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar un número válido para el ID o el número de créditos.");
            }
        }

        public void ActualizarMateria()
        {
            try
            {
                Console.Write("Ingrese el ID de la materia que desea actualizar: ");
                int idMateria = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el nuevo nombre de la materia: ");
                string nuevoNombre = Console.ReadLine();

                Console.Write("Ingrese el nuevo número de créditos de la materia: ");
                int nuevosCreditos = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el nuevo ID de la materia: ");
                int nuevoIdMateria = int.Parse(Console.ReadLine());

                int resultado = Escuela.ActualizarMateria(idMateria, nuevoNombre, nuevosCreditos, nuevoIdMateria);

                if (resultado == 1)
                {
                    Console.WriteLine("Materia actualizada exitosamente.");
                }
                else
                {
                    Console.WriteLine("La materia no fue encontrada.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar un número válido para el ID o los créditos.");
            }
        }

        public void EliminarMateria()
        {
            try
            {
                Console.Write("Ingrese el ID de la materia que desea eliminar: ");
                int idMateria = int.Parse(Console.ReadLine());
                Console.WriteLine(Escuela.EliminarMateria(idMateria));
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El ID de la materia debe ser un número válido.");
            }
        }

        // Grupo
        public void Grupo()
        {
            bool dentroMenuGrupo = true;

            List<Opcion> opcionesGrupo = new List<Opcion>
            {
                new Opcion("Crear grupo.", RegistrarGrupo),
                new Opcion("Ver grupos existentes.", () => Console.WriteLine(Escuela.MostrarGrupos())),
                new Opcion("Actualizar grupo existente", ActualizarGrupo),
                new Opcion("Eliminar grupo existente.", EliminarGrupo),
                new Opcion("Regresar a Menú Principal", () => { dentroMenuGrupo = false; RegresarPrincipal(); })
            };

            Menu menuGrupo = new Menu("Menú del Grupo", opcionesGrupo);

            while (dentroMenuGrupo)
            {
                menuGrupo.MostrarMenu();
                int opcion = menuGrupo.SeleccionarOpcion();
                Console.WriteLine();
                opcionesGrupo[opcion - 1].Action.Invoke();
                menuGrupo.Continuar();
            }
        }

        public void RegistrarGrupo()
        {
            try
            {
                Console.Write("Ingrese el ID del grupo: ");
                int idGrupo = int.Parse(Console.ReadLine());

                Grupo grupo = new Grupo(idGrupo);
                Escuela.AgregarGrupo(grupo);

                Console.WriteLine("Grupo registrado exitosamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El ID del grupo debe ser un número válido.");
            }
        }

        public void ActualizarGrupo()
        {
            try
            {
                Console.Write("Ingrese el ID del grupo que desea actualizar: ");
                int idGrupo = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el nuevo nombre del grupo: ");
                string nuevoNombre = Console.ReadLine();

                Console.Write("Ingrese el nuevo ID del grupo: ");
                int nuevoIdGrupo = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el ID de la materia: ");
                int idMateria = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el ID del maestro: ");
                int idMaestro = int.Parse(Console.ReadLine());

                string resultado = Escuela.ActualizarGrupo(idGrupo, nuevoIdGrupo, idMateria, idMaestro);

                Console.WriteLine(resultado);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Todos los IDs deben ser números válidos.");
            }
        }

        public void EliminarGrupo()
        {
            try
            {
                Console.Write("Ingrese el ID del grupo que desea eliminar: ");
                int idGrupo = int.Parse(Console.ReadLine());
                Console.WriteLine(Escuela.EliminarGrupo(idGrupo));
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El ID del grupo debe ser un número válido.");
            }
        }

        // Maestro
        public void Maestro()
        {
            bool dentroMenuMaestro = true;

            List<Opcion> opcionesMaestro = new List<Opcion>
            {
                new Opcion("Registrar maestro.", RegistrarMaestro),
                new Opcion("Ver maestros existentes.", () => Console.WriteLine(Escuela.MostrarMaestros())),
                new Opcion("Actualizar maestro existente", ActualizarMaestro),
                new Opcion("Eliminar maestro existente.", EliminarMaestro),
                new Opcion("Regresar a Menú Principal", () => { dentroMenuMaestro = false; RegresarPrincipal(); })
            };

            Menu menuMaestro = new Menu("Menú de los Maestros", opcionesMaestro);

            while (dentroMenuMaestro)
            {
                menuMaestro.MostrarMenu();
                int opcion = menuMaestro.SeleccionarOpcion();
                Console.WriteLine();
                opcionesMaestro[opcion - 1].Action.Invoke();
                menuMaestro.Continuar();
            }
        }

        public void RegistrarMaestro()
        {
            try
            {
                Console.Write("Ingrese el nombre del maestro: ");
                string nombreMaestro = Console.ReadLine();

                Console.Write("Ingrese el ID del maestro: ");
                int idMaestro = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el Correo Electronico del maestro: ");
                string correoElectronico = Console.ReadLine();

                Maestro maestro = new Maestro(idMaestro, nombreMaestro, correoElectronico);
                Escuela.AgregarMaestro(maestro);

                Console.WriteLine("Maestro registrado exitosamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El ID del maestro debe ser un número válido.");
            }
        }

        public void ActualizarMaestro()
        {
            try
            {
                Console.Write("Ingrese el ID del maestro que desea actualizar: ");
                int idMaestro = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el nuevo nombre del maestro: ");
                string nuevoNombre = Console.ReadLine();

                Console.Write("Ingrese el nuevo ID del maestro: ");
                int nuevoIdMaestro = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el nuevo Correo Electronico del maestro: ");
                string nuevoCorreo = Console.ReadLine();

                int resultado = Escuela.ActualizarMaestro(idMaestro, nuevoNombre, nuevoCorreo, nuevoIdMaestro);

                if (resultado == 1)
                {
                    Console.WriteLine("Maestro actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("El maestro no fue encontrado.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar un número válido para el ID.");
            }
        }

        public void EliminarMaestro()
        {
            try
            {
                Console.Write("Ingrese el ID del maestro que desea eliminar: ");
                int idMaestro = int.Parse(Console.ReadLine());
                Console.WriteLine(Escuela.EliminarMaestro(idMaestro));
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El ID del maestro debe ser un número válido.");
            }
        }

        // Alumno
        public void Alumno()
        {
            bool dentroMenuAlumno = true;

            List<Opcion> opcionesAlumno = new List<Opcion>
            {
                new Opcion("Registrar alumno.", RegistrarAlumno),
                new Opcion("Ver alumnos existentes.", () => Console.WriteLine(Escuela.MostrarAlumnos())),
                new Opcion("Actualizar alumno existente", ActualizarAlumno),
                new Opcion("Eliminar alumno existente.", EliminarAlumno),
                new Opcion("Regresar a Menú Principal", () => { dentroMenuAlumno = false; RegresarPrincipal(); })
            };

            Menu menuAlumno = new Menu("Menú de los Alumnos", opcionesAlumno);

            while (dentroMenuAlumno)
            {
                menuAlumno.MostrarMenu();
                int opcion = menuAlumno.SeleccionarOpcion();
                Console.WriteLine();
                opcionesAlumno[opcion - 1].Action.Invoke();
                menuAlumno.Continuar();
            }
        }

        public void RegistrarAlumno()
        {
            try
            {
                Console.Write("Ingrese el nombre del alumno: ");
                string nombreAlumno = Console.ReadLine();

                Console.Write("Ingrese el ID del alumno: ");
                int idAlumno = int.Parse(Console.ReadLine());

                Console.Write("Ingrese la edad del alumno: ");
                int edadAlumno = int.Parse(Console.ReadLine());

                Alumno alumno = new Alumno(idAlumno, nombreAlumno);
                Escuela.AgregarAlumno(alumno);

                Console.WriteLine("Alumno registrado exitosamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El ID o la edad del alumno deben ser números válidos.");
            }
        }

        public void ActualizarAlumno()
        {
            try
            {
                Console.Write("Ingrese el ID del alumno que desea actualizar: ");
                int idAlumno = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el nuevo nombre del alumno: ");
                string nuevoNombre = Console.ReadLine();

                Console.Write("Ingrese la nueva edad del alumno: ");
                int nuevaEdad = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el nuevo ID del alumno: ");
                int nuevoIdAlumno = int.Parse(Console.ReadLine());

                int resultado = Escuela.ActualizarAlumno(idAlumno, nuevoNombre, nuevoIdAlumno);

                if (resultado == 1)
                {
                    Console.WriteLine("Alumno actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("El alumno no fue encontrado.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Todos los valores deben ser válidos.");
            }
        }

        public void EliminarAlumno()
        {
            try
            {
                Console.Write("Ingrese el ID del alumno que desea eliminar: ");
                int idAlumno = int.Parse(Console.ReadLine());
                Console.WriteLine(Escuela.EliminarAlumno(idAlumno));
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El ID del alumno debe ser un número válido.");
            }
        }

        // Método para regresar al menú principal
        public void RegresarPrincipal()
        {
            Console.WriteLine("Regresando al menú principal...");
        }

        // Método para salir
        public void Salir()
        {
            Console.WriteLine("Saliendo del sistema. ¡Adiós!");
            dentroMenuPrincipal = false;
        }
    }
}
