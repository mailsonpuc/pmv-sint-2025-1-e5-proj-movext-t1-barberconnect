

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberConnect.Api.Models
{
    public class Agendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgendamento { get; set; }

        [StringLength(100)]
        public string? Status { get; set; }

        public bool? LembreteEnviado { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;

        [ForeignKey("Servico")]
        public int IdServico { get; set; }
        public Servico Servico { get; set; } = null!;

        [ForeignKey("HorarioDisponivel")]
        public int IdHorario { get; set; }
        public HorarioDisponivel HorarioDisponivel { get; set; } = null!;
    }
}