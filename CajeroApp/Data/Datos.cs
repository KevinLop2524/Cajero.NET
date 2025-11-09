namespace CajeroApp.Data
{
    using System;
    public static class Data
    {
        public static string[] Usuarios = [ "1001", "2002" ];
        public static string[] Pines = [ "1234", "5678" ];
        public static decimal[] Saldos = [ 500000m, 1200000m ];

        public static bool ValidarUsuario(string id, string pin)
        {
            int posicion = Array.IndexOf(Usuarios, id);
            if (posicion == -1) {
                return false;
            }
          
            string acceso = Pines[posicion];
            if (pin == acceso){
                    return true;
                }
                return false;
        }

        public static bool ValidarId(string id) {
            int posicionId = Array.IndexOf(Usuarios, id);
            if (posicionId == -1) return false;
            return true;
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