namespace ClinicaCitas;

public class ServicioRecordatorios
{
    private readonly INotificador _notificador;

    public ServicioRecordatorios(INotificador notificador)
    {
        _notificador = notificador;
    }

    public void EnviarRecordatorio(Cita cita)
    {
        if (cita.Estado != EstadoCita.Programada)
        {
            throw new ErrorValidacion("Solo se recuerdan citas programadas");
        }
        var mensaje = $"Recordatorio: cita con {cita.Medico.Nombre} el {cita.FechaHora:dd/MM/yyyy 'a las' HH:mm}";
        _notificador.Enviar(cita.Paciente, mensaje);
    }
}
