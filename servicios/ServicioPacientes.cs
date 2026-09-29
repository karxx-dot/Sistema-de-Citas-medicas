namespace ClinicaCitas;

public class ServicioPacientes
{
    private readonly IRepositorio<Paciente> _repo;

    public ServicioPacientes(IRepositorio<Paciente> repo)
    {
        _repo = repo;
    }

    public Paciente Registrar(string nombre, string correo, string telefono)
    {
        var paciente = new Paciente(nombre, correo, telefono);
        _repo.Guardar(paciente);
        return paciente;
    }
}
