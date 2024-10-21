using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POO_ThisTeam_EA2
{
    internal class Materia
    {
        private int idMateria;
        private string nombreMateria;
        private int creditos;

        //Propiedades

        public int IdMateria { get { return idMateria; } }
        //Propiedad para acceder al nombre.
        public string NombreMateria { get { return nombreMateria; } }
        //Propiedad para acceder a la edad.
        public int Creditos { get { return Creditos; } }

        //Constructor
        public Materia(int idMateria, string nombreMateria,  int creditos)
        {
            this.idMateria = idMateria;
            this.nombreMateria = nombreMateria;
            this.creditos = creditos;
        }


    }
}
