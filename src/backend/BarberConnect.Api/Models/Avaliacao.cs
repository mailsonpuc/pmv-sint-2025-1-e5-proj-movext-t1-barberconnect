

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BarberConnect.Api.Models
{
    public class Avaliacao
    {
        [Key]
        public int AvaliacaoId { get; set; }
        public int Nota { get; set; }
        public string? Comentario { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }


        public int AgendamentoId { get; set; }
        [JsonIgnore]
        public Agendamento? Agendamento { get; set; }


        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente? Cliente { get; set; }


        public int BarbeiroId { get; set; }
        [JsonIgnore]
        public Barbeiro? Barbeiro { get; set; }


    }

}