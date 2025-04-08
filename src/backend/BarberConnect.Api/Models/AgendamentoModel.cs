namespace BarberConnect.Api.Models
{
    public class AgendamentoModel
    {
        public int IdAgendamento { get; set; }
        public DateTime DataAgendamento { get; set; }
        public TimeSpan HoraAgendamento { get; set; }
        public string? Status { get; set; }
        public bool LembreteEnviado { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
