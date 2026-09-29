namespace ClinicaCitas;

public interface IRepositorio<T> where T : Entidad
{
    void Guardar(T entidad);
    T Obtener(string id);
    IEnumerable<T> Listar();
}
