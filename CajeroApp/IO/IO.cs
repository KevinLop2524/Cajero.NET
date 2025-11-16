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
            int maxLength = 4;//se declara el maximo de cuantos caracteres puede añadir a la contraseña
            Console.Write(mensaje);
            string pin = "";
            ConsoleKeyInfo tecla;
            while ((tecla = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                //hacer que cuando el usuario presione la tecla delete se elimine del pin el ultimo caracter, muy interesante
                if (tecla.Key == ConsoleKey.Backspace && pin.Length>0)
                {
                 pin= pin.Substring(0, pin.Length-1);
                 Console.Write("\b \b");
                 continue;   
                }
                
                if (char.IsDigit(tecla.KeyChar))
                {

                    //se valida que el pin sea menor al maximo de caracteres
                    if (pin.Length < maxLength)
                    {
                        pin += tecla.KeyChar;
                        Console.Write("*");
                    }
                }
            }
            Console.WriteLine();
            return pin;
        }

        public static void Pausar()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey(true);
        }
    }
}
