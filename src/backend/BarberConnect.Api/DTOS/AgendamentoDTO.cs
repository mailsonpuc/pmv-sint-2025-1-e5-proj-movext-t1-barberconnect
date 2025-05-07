

using System.ComponentModel.DataAnnotations;

namespace BarberConnect.Api.DTOS
{
    public class AgendamentoDTO
    {
        [Key]
        public int AgendamentoId { get; set; }

        public StatusAgendamento Status { get; set; }
        public bool LembreteEnviado { get; set; }


        public int ClienteId { get; set; }
        public int ServicoId { get; set; }
        public int HorarioId { get; set; }
        public int BarbeiroId { get; set; }
     

        public enum StatusAgendamento { Agendado, Concluído, Cancelado }
    }
}