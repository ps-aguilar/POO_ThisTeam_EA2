using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POO_ThisTeam_EA2
{
    internal class Grupo
    {
        private int idGrupo;
        private Materia materia;
        private Maestro maestroEncargado;
        private List<Alumno> alumnos;

        // Propiedad para acceder y modificar el ID del grupo.
        public int IdGrupo
        {
            get { return idGrupo; }
            set { idGrupo = value; }
        }

        // Propiedad para acceder a la materia del grupo.
        public Materia Materia
        {
            get { return materia; }
            set { materia = value; }
        }

        // Propiedad para acceder al maestro encargado del grupo.
        public Maestro MaestroEncargado
        {
            get { return maestroEncargado; }
            set { maestroEncargado = value; }
        }

        // Propiedad para acceder a la lista de alumnos del grupo.
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }


        //Constructor

        public Grupo(int idGrupo)
        {
            this.idGrupo = idGrupo;
            this.materia = null;
            this.maestroEncargado = null;
            this.alumnos = new List<Alumno>();
        }
    }
}
