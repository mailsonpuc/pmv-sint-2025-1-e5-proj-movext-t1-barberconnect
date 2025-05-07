

using BarberConnect.Api.Models;

namespace BarberConnect.Api.DTOS.Mappings
{
    public static class AgendamentoDTOMappingExtensions
    {
        public static AgendamentoDTO? ToAgendamentoDTO(this Agendamento agendamento)
        {
            if (agendamento is null)
            {
                return null;
            }

            return new AgendamentoDTO
            {
                AgendamentoId = agendamento.AgendamentoId,
                Status = (AgendamentoDTO.StatusAgendamento)agendamento.Status,
                LembreteEnviado = agendamento.LembreteEnviado,
                ClienteId = agendamento.ClienteId,
                ServicoId = agendamento.ServicoId,
                HorarioId = agendamento.HorarioId,
                BarbeiroId = agendamento.BarbeiroId
            };
        }







        public static Agendamento? ToAgendamento(this AgendamentoDTO agendamentoDto)
        {
            if (agendamentoDto is null)
            {
                return null;
            }

            return new Agendamento
            {
                AgendamentoId = agendamentoDto.AgendamentoId,
                Status = (Agendamento.StatusAgendamento)agendamentoDto.Status,
                LembreteEnviado = agendamentoDto.LembreteEnviado,
                ClienteId = agendamentoDto.ClienteId,
                ServicoId = agendamentoDto.ServicoId,
                HorarioId = agendamentoDto.HorarioId,
                BarbeiroId = agendamentoDto.BarbeiroId
            };
        }








        public static IEnumerable<AgendamentoDTO> ToAgendamentoDTOList(this IEnumerable<Agendamento> agendamentos)
        {

            if (agendamentos is null || !agendamentos.Any())
            {
                return new List<AgendamentoDTO>();
            }


            return agendamentos.Select(ag => new AgendamentoDTO
            {
                AgendamentoId = ag.AgendamentoId,
                Status = (AgendamentoDTO.StatusAgendamento)ag.Status,
                LembreteEnviado = ag.LembreteEnviado,
                ClienteId = ag.ClienteId,
                ServicoId = ag.ServicoId,
                HorarioId = ag.HorarioId,
                BarbeiroId = ag.BarbeiroId
            }).ToList();

        }
    }
}