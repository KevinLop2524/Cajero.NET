namespace CajeroLite.App
{
    using CajeroApp.Data;
    using CajeroApp.Operaciones;
    using CajeroApp.IO;

    public class Program
    {
        public static void Main()
        {
            IO.MostrarTitulo("Bienvenido a CajeroLite");
            string usuario = IniciarSesion();
            if (usuario != null)
            {
                MostrarMenu(usuario);
            }
        }

        public static string IniciarSesion()
        {
            for (int intentos = 0; intentos < 3; intentos++)
            {
                string id = IO.LeerTexto("Ingrese su ID de usuario: ");
                string pin = IO.LeerPin("Ingrese su PIN: ");
                if (Data.ValidarUsuario(id, pin))
                {
                    IO.MostrarMensaje("Inicio de sesión exitoso.");
                    return id;
                }
                IO.MostrarError("ID o PIN incorrecto.");
            }
            IO.MostrarError("Demasiados intentos fallidos. Saliendo...");
            return null;                                                                                                     
        }

        public static void MostrarMenu(string usuario)
        {
            int opcion;
            do
            {
                IO.MostrarTitulo("Menú principal");
                IO.MostrarMensaje("1. Consultar saldo");
                IO.MostrarMensaje("2. Depositar");
                IO.MostrarMensaje("3. Retirar");
                IO.MostrarMensaje("4. Salir");

                opcion = int.Parse(IO.LeerTexto("Seleccione una opción: "));

                switch (opcion)
                {
                    case 1: Operaciones.ConsultarSaldo(usuario); break;
                    case 2: Operaciones.Depositar(usuario); break;
                    case 3: Operaciones.Retirar(usuario); break;
                }
            } while (opcion != 4);
        }
    }
}