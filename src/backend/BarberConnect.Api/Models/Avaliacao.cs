
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

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        [ForeignKey("Agendamento")]
        public int IdAgendamento { get; set; }
        public Agendamento Agendamento { get; set; } = null!;
    }
}