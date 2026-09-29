namespace ClinicaCitas;

public class ServicioCitas
{
    private readonly IRepositorio<Cita> _repo;

    public ServicioCitas(IRepositorio<Cita> repo)
    {
        _repo = repo;
    }

    public Cita Agendar(Paciente paciente, Medico medico, DateTime fechaHora)
    {
        ValidarDisponibilidad(medico, fechaHora);
        var cita = new Cita(paciente, medico, fechaHora);
        _repo.Guardar(cita);
        return cita;
    }

    public void Cancelar(string citaId)
    {
        var cita = _repo.Obtener(citaId);
        cita.Cancelar();
        _repo.Guardar(cita);
    }

    public void Reprogramar(string citaId, DateTime nuevaFecha)
    {
        var cita = _repo.Obtener(citaId);
        if (cita.Estado == EstadoCita.Cancelada)
        {
            throw new ErrorValidacion("No se puede reprogramar una cita cancelada");
        }
        ValidarDisponibilidad(cita.Medico, nuevaFecha, cita.Id);
        cita.FechaHora = nuevaFecha;
        _repo.Guardar(cita);
    }

    public List<Cita> PorPaciente(string pacienteId)
    {
        return _repo.Listar().Where(c => c.Paciente.Id == pacienteId).ToList();
    }

    public List<Cita> PorMedico(string medicoId)
    {
        return _repo.Listar().Where(c => c.Medico.Id == medicoId).ToList();
    }

    private void ValidarDisponibilidad(Medico medico, DateTime fechaHora, string? ignorarId = null)
    {
        Validaciones.FechaFutura(fechaHora);
        var ocupado = _repo.Listar().Any(c =>
            c.Medico.Id == medico.Id
            && c.FechaHora == fechaHora
            && c.Estado == EstadoCita.Programada
            && c.Id != ignorarId);
        if (ocupado)
        {
            throw new ErrorValidacion("El medico no esta disponible en ese horario");
        }
    }
}
