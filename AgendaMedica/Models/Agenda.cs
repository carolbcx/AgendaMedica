namespace AgendaMedica.Models
{
    public class Agenda
    {
        public Guid AgendaId { get; set; }
        public Guid PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
        public Guid MedicoId { get; set; }
        public Medico? Medico { get; set; }
        public DateTime DataConsulta { get; set; }
        public string? Status { get; set; }

    }
}