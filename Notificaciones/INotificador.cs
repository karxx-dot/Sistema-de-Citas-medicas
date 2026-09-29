namespace ClinicaCitas;

public interface INotificador
{
    void Enviar(Paciente paciente, string mensaje);
}
