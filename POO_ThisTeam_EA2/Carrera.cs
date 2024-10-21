using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POO_ThisTeam_EA2
{
    internal class Carrera
    {
        //ID de Carrera.
        private int idCarrera;
        //Nombre de la carrera.
        private string nombreCarrera;
        //Coordinador de carrera
        private Maestro coordinador;

        // Propiedad para acceder y modificar el ID.
        public int IdCarrera
        {
            get { return idCarrera; }
            set { idCarrera = value; } 
        }

        // Propiedad para acceder y modificar el nombre de la carrera.
        public string NombreCarrera
        {
            get { return nombreCarrera; }
            set { nombreCarrera = value; } 
        }

        // Propiedad para acceder y modificar el coordinador.
        public Maestro Coordinador
        {
            get { return coordinador; }
            set { coordinador = value; } 
        }

        //Constructor

        public Carrera(int idCarrera, string nombreCarrera)
        {
            this.idCarrera = idCarrera;
            this.nombreCarrera = nombreCarrera;
            this.coordinador = null;
        }


    }
}
