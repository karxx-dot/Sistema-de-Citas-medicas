namespace ClinicaCitas;

public class ServicioEspecialidades
{
    private readonly IRepositorio<Especialidad> _repo;

    public ServicioEspecialidades(IRepositorio<Especialidad> repo)
    {
        _repo = repo;
    }

    public Especialidad Registrar(string nombre)
    {
        var especialidad = new Especialidad(nombre);
        _repo.Guardar(especialidad);
        return especialidad;
    }
}
