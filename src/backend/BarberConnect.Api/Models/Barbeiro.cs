

using System.ComponentModel.DataAnnotations;

namespace BarberConnect.Api.Models
{
    public class Barbeiro
    {
        [Key]
        public int BarbeiroId { get; set; }
        public string? Nome { get; set; }


        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Telefone { get; set; }

        public ICollection<Servico>? Servicos { get; set; }

    }
}