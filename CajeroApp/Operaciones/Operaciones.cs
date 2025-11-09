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
            decimal monto = decimal.Parse(IO.LeerTexto("Ingrese el monto a depositar: "));
            if (monto > 0)
            {
                decimal saldoActual = Data.ObtenerSaldo(id);
                Data.ActualizarSaldo(id, saldoActual + monto);
                IO.MostrarMensaje("Depósito realizado correctamente.");
            }
            else IO.MostrarError("Monto inválido.");
            IO.Pausar();
        }

        public static void Retirar(string id)
        {
            decimal monto = decimal.Parse(IO.LeerTexto("Ingrese el monto a retirar: "));
            decimal saldoActual = Data.ObtenerSaldo(id);

            if (monto <= 0) IO.MostrarError("Monto inválido.");
            else if (monto > saldoActual) IO.MostrarError("Fondos insuficientes.");
            else
            {
                Data.ActualizarSaldo(id, saldoActual - monto);
                IO.MostrarMensaje("Retiro realizado exitosamente.");
            }
            IO.Pausar();
        }
    }
}
