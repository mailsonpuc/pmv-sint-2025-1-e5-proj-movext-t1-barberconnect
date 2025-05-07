

using System.ComponentModel.DataAnnotations;

namespace BarberConnect.Api.DTOS
{
    public class AvaliacaoDTO
    {
        [Key]
        public int AvaliacaoId { get; set; }
        public int Nota { get; set; }
        public string? Comentario { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public int AgendamentoId { get; set; }
        public int ClienteId { get; set; }
        public int BarbeiroId { get; set; }



    }
}