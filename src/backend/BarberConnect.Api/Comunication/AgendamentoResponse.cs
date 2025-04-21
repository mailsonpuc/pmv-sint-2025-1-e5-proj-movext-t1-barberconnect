using BarberConnect.Api.Models;

namespace BarberConnect.Api.Comunication
{
    public class AgendamentoResponse
    {
        public int IdAgendamento { get; set; }
        public string? Status { get; set; }
        public bool? LembreteEnviado { get; set; }

        public Cliente Cliente { get; set; }
        public Servico Servico { get; set; }
        public HorarioDisponivel HorarioDisponivel { get; set; }
        public Barbeiro Barbeiro { get; set; }

        public AgendamentoResponse(Agendamento agendamento)
        {
            IdAgendamento = agendamento.IdAgendamento;
            Status = agendamento.Status;
            LembreteEnviado = agendamento.LembreteEnviado;
            Cliente = agendamento.Cliente;
            Servico = agendamento.Servico;
            HorarioDisponivel = agendamento.HorarioDisponivel;
            Barbeiro = agendamento.Barbeiro;
        }

    }
}
