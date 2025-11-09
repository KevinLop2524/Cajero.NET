namespace CajeroApp.Data
{
    public static class Data
    {
        public static string[] Usuarios = { "1001", "2002" };
        public static string[] Pines = { "1234", "5678" };
        public static decimal[] Saldos = { 500000m, 1200000m };

        public static bool ValidarUsuario(string id, string pin)
        {
            for (int i = 0; i < Usuarios.Length; i++)
            {
                if (Usuarios[i] == id && Pines[i] == pin)
                    return true;
            }
            return false;
        }

        public static decimal ObtenerSaldo(string id)
        {
            for (int i = 0; i < Usuarios.Length; i++)
            {
                if (Usuarios[i] == id) return Saldos[i];
            }
            return 0;
        }
        
        public static void ActualizarSaldo(string id, decimal nuevoSaldo)
        {
            for (int i=0; i< Usuarios.Length; i++)
            {
                if(Usuarios[i] == id)
                {
                    Saldos[i] = nuevoSaldo;
                    break;
                }
            }
        }
    }
}