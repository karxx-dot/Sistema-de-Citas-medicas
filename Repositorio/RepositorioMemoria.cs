namespace ClinicaCitas;

public class RepositorioMemoria<T> : IRepositorio<T> where T : Entidad
{
    private readonly Dictionary<string, T> _datos = new();

    public void Guardar(T entidad)
    {
        _datos[entidad.Id] = entidad;
    }

    public T Obtener(string id)
    {
        if (!_datos.TryGetValue(id, out var entidad))
        {
            throw new ErrorValidacion($"No existe el registro {id}");
        }
        return entidad;
    }

    public IEnumerable<T> Listar()
    {
        return _datos.Values.ToList();
    }
}
