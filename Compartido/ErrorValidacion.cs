namespace ClinicaCitas;

public class ErrorValidacion : Exception
{
    public ErrorValidacion(string mensaje) : base(mensaje)
    {
    }
}
