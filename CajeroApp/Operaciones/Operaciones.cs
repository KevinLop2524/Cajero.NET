namespace CajeroApp.Operaciones
{
    using CajeroApp.Data;
    using CajeroApp.IO;

    public static class Operaciones
    {
        public static void ConsultarSaldo(string id)
        {
            decimal saldo = Data.ObtenerSaldo(id);
            IO.MostrarMensaje($"Su saldo actual es: {saldo:C}");
            IO.Pausar();
        }

        public static void Depositar(string id)
        {
            int monto;
            string entrada = IO.LeerTexto("Ingrese el monto a depositar: ");

            while (!int.TryParse(entrada, out monto) || monto <= 0 || monto % 100 != 0 || monto>2500000)
            {
                IO.MostrarError("Monto inválido. Ingrese un número entero multiplo de 100 y menor que $2'500.000");
                entrada = IO.LeerTexto("Ingrese el monto a depositar: ");
            }

            decimal saldoActual = Data.ObtenerSaldo(id);
            Data.ActualizarSaldo(id, saldoActual + monto);
            IO.MostrarMensaje("Depósito realizado correctamente.");

            IO.Pausar();
        }


        public static void Retirar(string id)
        {
            int monto;
            string entrada = IO.LeerTexto("Ingrese el monto a retirar: ");

            while (!int.TryParse(entrada, out monto) || monto < 100 || monto%100!=0)
            {
                IO.MostrarError("Monto inválido. Solicite retirar un multiplo de 100");
                entrada = IO.LeerTexto("Ingrese el monto a retirar: ");
            }

            decimal saldoActual = Data.ObtenerSaldo(id);

            if (monto > saldoActual)
            {
                IO.MostrarError("Fondos insuficientes.");
            }
            else
            {
                Data.ActualizarSaldo(id, saldoActual - monto);
                IO.MostrarMensaje("Retiro realizado exitosamente.");
            }

            IO.Pausar();
        }

    }
}

