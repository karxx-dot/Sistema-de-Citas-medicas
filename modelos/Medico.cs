namespace ClinicaCitas;

public class Medico : Entidad
{
    public string Nombre { get; }
    public string Correo { get; }
    public Especialidad? Especialidad { get; set; }

    public Medico(string nombre, string correo, Especialidad? especialidad = null)
    {
        Nombre = Validaciones.Requerido(nombre, "nombre");
        Correo = Validaciones.Requerido(correo, "correo");
        Especialidad = especialidad;
    }
}
