namespace ClinicaCitas;

public abstract class Entidad
{
    public string Id { get; } = Guid.NewGuid().ToString("N")[..8];
}
