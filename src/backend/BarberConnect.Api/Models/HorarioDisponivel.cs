

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BarberConnect.Api.Models
{
    public class HorarioDisponivel
    {
        [Key]
        public int HorarioDisponivelId { get; set; }

        public int BarbeiroId { get; set; }
        [JsonIgnore]
        public Barbeiro? Barbeiro { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }

        public bool Disponivel { get; set; } = true; // Valor padrão
    }

}