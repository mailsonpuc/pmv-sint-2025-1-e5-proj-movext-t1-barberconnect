

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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


        [JsonIgnore]
        public Usuario Usuario { get; set; }


        [JsonIgnore]
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}

