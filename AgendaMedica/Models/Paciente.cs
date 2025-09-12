using Microsoft.AspNetCore.Identity;

namespace AgendaMedica.Models
{
    public class Paciente
    {
        public Guid PacienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public DateOnly DataNasc { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Prontuario { get; set; }
        public string Email { get; set; }

        // Vincular a Identidade ao Paciente (IdentityUser)
        public string? UserId { get; set; } // FK
        public IdentityUser? IdentityUser { get; set; }
    }
}
