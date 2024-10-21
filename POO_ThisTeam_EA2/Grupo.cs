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

        //Propiedad para acceder al ID.
        public int IdGrupo { get { return idGrupo; } }
        //Propiedad para acceder a la materia.
        public Materia Materia { get { return materia; } }
        //Propiedad para acceder al maestro.
        public Maestro MaestroEncargado { get { return maestroEncargado; } }
        //Propiedad para acceder a los alumnos.
        public List<Alumno> Alumnos { get { return alumnos; } }

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
