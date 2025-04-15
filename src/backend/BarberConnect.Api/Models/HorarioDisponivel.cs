

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberConnect.Api.Models
{
    public class HorarioDisponivel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHorario { get; set; }

        [ForeignKey("Barbeiro")]
        public int IdBarbeiro { get; set; }
        public Barbeiro Barbeiro { get; set; } = null!;

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan? HoraInicio { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan? HoraFim { get; set; }
    }
}