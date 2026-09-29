namespace ClinicaCitas;

public class NotificadorCorreo : INotificador
{
    public void Enviar(Paciente paciente, string mensaje)
    {
        Console.WriteLine($"[CORREO a {paciente.Correo}] {mensaje}");
    }
}
