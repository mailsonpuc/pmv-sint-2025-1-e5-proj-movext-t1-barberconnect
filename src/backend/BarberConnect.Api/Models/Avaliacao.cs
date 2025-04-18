
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberConnect.Api.Models
{
    public class Avaliacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAvaliacao { get; set; }

        public int? Nota { get; set; }

        public string? Comentario { get; set; }

        [ForeignKey("Agendamento")]
        public int IdAgendamento { get; set; }
        public Agendamento Agendamento { get; set; } = null!;
        public int ClienteId { get; set; } 
        public int BarbeiroId { get; set; }
        public Cliente Cliente { get; set; }
        public Barbeiro Barbeiro { get; set; }
    }
}