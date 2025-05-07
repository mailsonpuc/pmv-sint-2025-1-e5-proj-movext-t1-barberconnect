

using System.ComponentModel.DataAnnotations;

namespace BarberConnect.Api.DTOS
{
    public class HorarioDisponivelDTO
    {
        [Key]
        public int HorarioDisponivelId { get; set; }
        public int BarbeiroId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public bool Disponivel { get; set; } = true; // Valor padrão
    }
}