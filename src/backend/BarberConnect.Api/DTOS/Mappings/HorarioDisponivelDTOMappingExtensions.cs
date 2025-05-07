// Importa o namespace que contém o modelo de domínio HorarioDisponivel
using BarberConnect.Api.Models;

namespace BarberConnect.Api.DTOS.Mappings
{
    // Classe estática contendo métodos de extensão para mapear entre DTO e modelo de domínio
    public static class HorarioDisponivelDTOMappingExtensions
    {
        // Método de extensão que converte um objeto HorarioDisponivel em HorarioDisponivelDTO
        public static HorarioDisponivelDTO? ToHorarioDisponivelDTO(this HorarioDisponivel horarioDisponivel)
        {
            // Verifica se o objeto é nulo. Se for, retorna null
            if (horarioDisponivel is null)
            {
                return null;
            }

            // Cria e retorna um novo DTO preenchido com os dados do modelo de domínio
            return new HorarioDisponivelDTO
            {
                HorarioDisponivelId = horarioDisponivel.HorarioDisponivelId,
                BarbeiroId = horarioDisponivel.BarbeiroId,
                Date = horarioDisponivel.Date,
                HoraInicio = horarioDisponivel.HoraInicio,
                HoraFim = horarioDisponivel.HoraFim,
                Disponivel = horarioDisponivel.Disponivel
            };
        }

        // Método de extensão que converte um DTO em um objeto HorarioDisponivel (modelo de domínio)
        public static HorarioDisponivel? ToHorarioDisponivel(this HorarioDisponivelDTO horarioDisponivelDto)
        {
            // Verifica se o DTO é nulo. Se for, retorna null
            if (horarioDisponivelDto is null)
            {
                return null;
            }

            // Cria e retorna um novo objeto do modelo de domínio preenchido com os dados do DTO
            return new HorarioDisponivel
            {
                HorarioDisponivelId = horarioDisponivelDto.HorarioDisponivelId,
                BarbeiroId = horarioDisponivelDto.BarbeiroId,
                Date = horarioDisponivelDto.Date,
                HoraInicio = horarioDisponivelDto.HoraInicio,
                HoraFim = horarioDisponivelDto.HoraFim,
                Disponivel = horarioDisponivelDto.Disponivel
            };
        }

        // Método de extensão que converte uma lista de objetos HorarioDisponivel em uma lista de DTOs
        public static IEnumerable<HorarioDisponivelDTO> ToHorarioDisponivelDTOList(this IEnumerable<HorarioDisponivel> horarioDisponivels)
        {
            // Verifica se a lista é nula ou está vazia. Se for, retorna uma lista vazia de DTOs
            if (horarioDisponivels is null || !horarioDisponivels.Any())
            {
                return new List<HorarioDisponivelDTO>();
            }

            // Converte cada objeto da lista para um DTO e retorna como uma nova lista
            return horarioDisponivels.Select(horario => new HorarioDisponivelDTO
            {
                HorarioDisponivelId = horario.HorarioDisponivelId,
                BarbeiroId = horario.BarbeiroId,
                Date = horario.Date,
                HoraInicio = horario.HoraInicio,
                HoraFim = horario.HoraFim,
                Disponivel = horario.Disponivel
            }).ToList();
        }
    }
}
