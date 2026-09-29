namespace ClinicaCitas;

public class Paciente : Entidad
{
    public string Nombre { get; }
    public string Correo { get; }
    public string Telefono { get; }

    public Paciente(string nombre, string correo, string telefono)
    {
        Nombre = Validaciones.Requerido(nombre, "nombre");
        Correo = Validaciones.Requerido(correo, "correo");
        Telefono = Validaciones.Requerido(telefono, "telefono");
    }
}
