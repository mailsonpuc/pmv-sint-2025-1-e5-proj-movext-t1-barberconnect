

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberConnect.Api.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Nome { get; set; }


        [StringLength(20)]
        public string? Telefone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}

