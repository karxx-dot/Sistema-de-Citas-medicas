using ClinicaCitas;

var pacientes = new ServicioPacientes(new RepositorioMemoria<Paciente>());
var especialidades = new ServicioEspecialidades(new RepositorioMemoria<Especialidad>());
var medicos = new ServicioMedicos(new RepositorioMemoria<Medico>());
var citas = new ServicioCitas(new RepositorioMemoria<Cita>());
var recordatorios = new ServicioRecordatorios(new NotificadorCorreo());

var ana = pacientes.Registrar("Ana Perez", "ana@mail.com", "809-555-1111");
var cardio = especialidades.Registrar("Cardiologia");
var dr = medicos.Registrar("Dr. Luis Gomez", "luis@clinica.com");
medicos.AsignarEspecialidad(dr.Id, cardio);

var fecha = DateTime.Now.AddDays(2);
var cita = citas.Agendar(ana, dr, fecha);
recordatorios.EnviarRecordatorio(cita);

citas.Reprogramar(cita.Id, fecha.AddHours(3));
Console.WriteLine($"{citas.PorPaciente(ana.Id).Count} cita(s) de Ana");
Console.WriteLine($"{citas.PorMedico(dr.Id).Count} cita(s) del doctor");

citas.Cancelar(cita.Id);
Console.WriteLine($"Estado: {cita.Estado}");
