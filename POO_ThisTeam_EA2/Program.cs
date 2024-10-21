namespace POO_ThisTeam_EA2
{
    internal class Program
    {
        static void InterfazUsuario()
        {
            try
            {
                InterfazUsuario interfazUsuario = new InterfazUsuario();
            }

            catch
            {
                Console.Clear();
                Console.WriteLine("El valor ingresado no es válido");
                Console.WriteLine("\nPresione cualquier tecla para regresar al Menu");
                Console.ReadLine();
                Console.Clear();
                InterfazUsuario();
            }
        }

        static void Main(string[] args)
        {
            InterfazUsuario();
        }
    }
}
