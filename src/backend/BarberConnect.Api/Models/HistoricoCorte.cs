

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BarberConnect.Api.Models
{
    public class HistoricoCorte
    {
        [Key]
        public int HistoricoCorteId { get; set; }
        public string? Foto { get; set; }
        public string? Observacoes { get; set; }

        public int AgendamentoId { get; set; }
        [JsonIgnore]
        public Agendamento? Agendamento { get; set; }
    }

}