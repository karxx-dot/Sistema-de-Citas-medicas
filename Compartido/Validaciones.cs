namespace ClinicaCitas;

public static class Validaciones
{
    public static string Requerido(string? valor, string campo)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new ErrorValidacion($"El campo '{campo}' es obligatorio");
        }
        return valor.Trim();
    }

    public static void FechaFutura(DateTime fecha)
    {
        if (fecha <= DateTime.Now)
        {
            throw new ErrorValidacion("La fecha debe ser futura");
        }
    }
}
