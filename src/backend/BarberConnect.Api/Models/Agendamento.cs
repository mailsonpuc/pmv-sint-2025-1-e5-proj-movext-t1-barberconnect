

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BarberConnect.Api.Models
{
    public class Agendamento
    {
        [Key]
        public int AgendamentoId { get; set; }

        public StatusAgendamento Status { get; set; }
        public bool LembreteEnviado { get; set; }


        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente? Cliente { get; set; }


        public int ServicoId { get; set; }
        [JsonIgnore]
        public Servico? Servico { get; set; }


        public int HorarioId { get; set; }
        [JsonIgnore]
        public HorarioDisponivel? Horario { get; set; }



        public int BarbeiroId { get; set; }
        [JsonIgnore]
        public Barbeiro? Barbeiro { get; set; }

        public enum StatusAgendamento { Agendado, Concluído, Cancelado }

    }

}