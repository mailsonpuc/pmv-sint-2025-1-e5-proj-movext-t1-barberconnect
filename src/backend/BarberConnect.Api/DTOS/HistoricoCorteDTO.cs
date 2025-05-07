

using System.ComponentModel.DataAnnotations;

namespace BarberConnect.Api.DTOS
{
    public class HistoricoCorteDTO
    {
        [Key]
        public int HistoricoCorteId { get; set; }
        public string? Foto { get; set; }
        public string? Observacoes { get; set; }

        public int AgendamentoId { get; set; }
      
    }
}