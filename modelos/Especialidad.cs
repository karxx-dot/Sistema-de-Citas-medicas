namespace ClinicaCitas;

public class Especialidad : Entidad
{
    public string Nombre { get; }

    public Especialidad(string nombre)
    {
        Nombre = Validaciones.Requerido(nombre, "nombre");
    }
}
