

using BarberConnect.Api.Models;

namespace BarberConnect.Api.DTOS.Mappings
{
    public static class AvaliacaoDTOMappingExtensions
    {
        public static AvaliacaoDTO? ToAvaliacaoDTO(this Avaliacao avaliacao)
        {
            if (avaliacao is null)
            {
                return null;
            }

            return new AvaliacaoDTO
            {
                AvaliacaoId = avaliacao.AvaliacaoId,
                Nota = avaliacao.Nota,
                Comentario = avaliacao.Comentario,
                Data = avaliacao.Data,
                AgendamentoId = avaliacao.AgendamentoId,
                ClienteId = avaliacao.ClienteId,
                BarbeiroId = avaliacao.BarbeiroId
            };
        }







        public static Avaliacao? ToAvaliacao(this AvaliacaoDTO avaliacaoDto)
        {
            if (avaliacaoDto is null)
            {
                return null;
            }

            return new Avaliacao
            {
                AvaliacaoId = avaliacaoDto.AvaliacaoId,
                Nota = avaliacaoDto.Nota,
                Comentario = avaliacaoDto.Comentario,
                Data = avaliacaoDto.Data,
                AgendamentoId = avaliacaoDto.AgendamentoId,
                ClienteId = avaliacaoDto.ClienteId,
                BarbeiroId = avaliacaoDto.BarbeiroId
            };
        }








        public static IEnumerable<AvaliacaoDTO> ToAvaliacaoDTOList(this IEnumerable<Avaliacao> avaliacaos)
        {

            if (avaliacaos is null || !avaliacaos.Any())
            {
                return new List<AvaliacaoDTO>();
            }


            return avaliacaos.Select(av => new AvaliacaoDTO
            {
                AvaliacaoId   = av.AvaliacaoId,
                Nota          = av.Nota,
                Comentario    = av.Comentario,
                Data          = av.Data,
                AgendamentoId = av.AgendamentoId,
                ClienteId     = av.ClienteId,
                BarbeiroId    = av.BarbeiroId
            }).ToList();

        }
    }
}