using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POO_ThisTeam_EA2
{
    internal class Maestro
    {
        //ID del maestro.
        private int idMaestro;
        //Nombre del maestro.
        private string nombreCompleto;
        //Correo Electronico del maestro.
        private string correoElectronico;
        //Lista de grupos de los que se encarga el maestro.
        private List<Grupo> gruposImpartidos;

        public int IdMaestro
        {
            get { return idMaestro; }
            set { idMaestro = value; }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }

        public List<Grupo> GruposImpartidos
        {
            get { return gruposImpartidos; }
        }

        //Constructor 
        public Maestro(int idMaestro, string nombreCompleto, string correoElectronico)
        {
            this.idMaestro = idMaestro;
            this.nombreCompleto = nombreCompleto;
            this.correoElectronico = correoElectronico;
            gruposImpartidos = new List<Grupo>();
        }
    }
}
