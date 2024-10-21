using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POO_ThisTeam_EA2
{
    internal class Alumno
    {
        //ID del alumno.
        private int idAlumno;
        //Nombre del alumno.
        private string nombreCompleto;
        //Carrera del alumno.
        private Carrera carrera;
        //Lista de cursos en los que el alumno está inscrito.
        private List<Grupo> gruposInscritos;


        public int IdAlumno
        {
            get { return idAlumno; }
            set { idAlumno = value; }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        public Carrera Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }

        public List<Grupo> GruposInscritos
        {
            get { return gruposInscritos; }
        }

        //Constructor 
        public Alumno(int idAlumno, string nombreCompleto)
        {
            this.idAlumno = idAlumno;
            this.nombreCompleto = nombreCompleto;
            this.carrera = null;
            gruposInscritos = new List<Grupo>();
        }
    }
}
