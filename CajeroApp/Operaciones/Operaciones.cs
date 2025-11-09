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
            decimal monto;
            string entrada = IO.LeerTexto("Ingrese el monto a depositar: ");

            while (!decimal.TryParse(entrada, out monto) || monto <= 0)
            {
                IO.MostrarError("Monto inválido. Ingrese un número decimal mayor que 0.");
                entrada = IO.LeerTexto("Ingrese el monto a depositar: ");
            }

            decimal saldoActual = Data.ObtenerSaldo(id);
            Data.ActualizarSaldo(id, saldoActual + monto);
            IO.MostrarMensaje("Depósito realizado correctamente.");

            IO.Pausar();
        }


        public static void Retirar(string id)
        {
            decimal monto;
            string entrada = IO.LeerTexto("Ingrese el monto a retirar: ");

            while (!decimal.TryParse(entrada, out monto) || monto <= 0)
            {
                IO.MostrarError("Monto inválido. Ingrese un número decimal mayor que 0.");
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

