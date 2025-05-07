
using BarberConnect.Api.Models;

namespace BarberConnect.Api.DTOS.Mappings
{
    public static class BarbeiroDTOMappingExtensions
    {
        public static BarbeiroDTO? ToBarbeiroDTO(this Barbeiro barbeiro)
        {
            if (barbeiro is null)
            {
                return null;
            }

            return new BarbeiroDTO
            {
                BarbeiroId = barbeiro.BarbeiroId,
                Nome = barbeiro.Nome,
                Email = barbeiro.Email,
                Senha = barbeiro.Senha,
                Telefone = barbeiro.Telefone
            };
        }







        public static Barbeiro? ToBarbeiro(this BarbeiroDTO barbeiroDTO)
        {
            if (barbeiroDTO is null)
            {
                return null;
            }

            return new Barbeiro
            {
                BarbeiroId = barbeiroDTO.BarbeiroId,
                Nome = barbeiroDTO.Nome,
                Email = barbeiroDTO.Email,
                Senha = barbeiroDTO.Senha,
                Telefone = barbeiroDTO.Telefone
            };
        }








        public static IEnumerable<BarbeiroDTO> ToBarbeiroDTOList(this IEnumerable<Barbeiro> barbeiros)
        {

            if (barbeiros is null || !barbeiros.Any())
            {
                return new List<BarbeiroDTO>();
            }


            return barbeiros.Select(ba => new BarbeiroDTO
            {
                BarbeiroId = ba.BarbeiroId,
                Nome = ba.Nome,
                Email = ba.Email,
                Senha = ba.Senha,
                Telefone = ba.Telefone
            }).ToList();

        }

    }
}