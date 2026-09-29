namespace ClinicaCitas;

public class ServicioMedicos
{
    private readonly IRepositorio<Medico> _repo;

    public ServicioMedicos(IRepositorio<Medico> repo)
    {
        _repo = repo;
    }

    public Medico Registrar(string nombre, string correo, Especialidad? especialidad = null)
    {
        var medico = new Medico(nombre, correo, especialidad);
        _repo.Guardar(medico);
        return medico;
    }

    public void AsignarEspecialidad(string medicoId, Especialidad especialidad)
    {
        var medico = _repo.Obtener(medicoId);
        medico.Especialidad = especialidad;
        _repo.Guardar(medico);
    }
}
