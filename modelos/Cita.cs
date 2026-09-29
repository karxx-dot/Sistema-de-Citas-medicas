namespace ClinicaCitas;

public class Cita : Entidad
{
    public Paciente Paciente { get; }
    public Medico Medico { get; }
    public DateTime FechaHora { get; set; }
    public EstadoCita Estado { get; private set; } = EstadoCita.Programada;

    public Cita(Paciente paciente, Medico medico, DateTime fechaHora)
    {
        Paciente = paciente;
        Medico = medico;
        FechaHora = fechaHora;
    }

    public void Cancelar()
    {
        if (Estado == EstadoCita.Cancelada)
        {
            throw new ErrorValidacion("La cita ya esta cancelada");
        }
        Estado = EstadoCita.Cancelada;
    }
}
