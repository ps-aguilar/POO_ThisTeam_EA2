namespace POO_ThisTeam_EA2
{
    internal class Program
    {
        static void InterfazUsuario(Escuela escuela) // Aceptar un parámetro Escuela
        {
            try
            {
                // Pasar la instancia de Escuela al constructor de InterfazUsuario
                InterfazUsuario interfazUsuario = new InterfazUsuario(escuela);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("El valor ingresado no es válido");
                Console.WriteLine("\nPresione cualquier tecla para regresar al Menu");
                Console.ReadLine();
                Console.Clear();
                InterfazUsuario(escuela); // Pasar la misma instancia de Escuela al volver a llamar
            }
        }

        static void Main(string[] args)
        {
            // Crear una instancia de Escuela
            Escuela escuela = new Escuela();

            // Llamar a InterfazUsuario pasando la instancia de Escuela
            InterfazUsuario(escuela);
        }
    }
}
