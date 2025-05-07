

using BarberConnect.Api.Models;

namespace BarberConnect.Api.DTOS.Mappings
{
    public static class HistoricoCorteDTOMappingExtensions
    {
        public static HistoricoCorteDTO? ToHistoricoCortDTO(this HistoricoCorte historicoCorte)
        {
            if (historicoCorte is null)
            {
                return null;
            }

            return new HistoricoCorteDTO
            {
                HistoricoCorteId = historicoCorte.HistoricoCorteId,
                Foto = historicoCorte.Foto,
                AgendamentoId = historicoCorte.AgendamentoId
            };
        }







        public static HistoricoCorte? ToHistoricoCorte(this HistoricoCorteDTO historicoCorteDTO)
        {
            if (historicoCorteDTO is null)
            {
                return null;
            }

            return new HistoricoCorte
            {
                HistoricoCorteId = historicoCorteDTO.HistoricoCorteId,
                Foto = historicoCorteDTO.Foto,
                AgendamentoId = historicoCorteDTO.AgendamentoId
            };
        }








        public static IEnumerable<HistoricoCorteDTO> ToHistoricoCorteDTOList(this IEnumerable<HistoricoCorte> historicoCortes)
        {

            if (historicoCortes is null || !historicoCortes.Any())
            {
                return new List<HistoricoCorteDTO>();
            }


            return historicoCortes.Select(historico => new HistoricoCorteDTO
            {
                HistoricoCorteId = historico.HistoricoCorteId,
                Foto = historico.Foto,
                AgendamentoId = historico.AgendamentoId
            }).ToList();

        }

    }
}