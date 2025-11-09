using System;

namespace CajeroApp.IO
{
    public static class IO
    {
        public static void MostrarTitulo(string texto)
        {
            Console.Clear();
            Console.WriteLine("==== " + texto + " ====\n");
        }

        public static void MostrarMensaje(string texto)
        {
            Console.WriteLine(texto);
        }

        public static void MostrarError(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        public static string LeerTexto(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine() ?? "";
        }

        public static string LeerPin(string mensaje)
        {
            Console.Write(mensaje);
            string pin = "";
            ConsoleKeyInfo tecla;
            while ((tecla = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                if (char.IsDigit(tecla.KeyChar))
                {
                    pin += tecla.KeyChar;
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            return pin;
        }

        public static void Pausar()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
