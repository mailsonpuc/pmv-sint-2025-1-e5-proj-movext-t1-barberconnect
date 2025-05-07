

using BarberConnect.Api.Models;

namespace BarberConnect.Api.DTOS.Mappings
{
    public static class ClienteDTOMappingExtensions
    {
        public static ClienteDTO? ToClienteDTO(this Cliente cliente)
        {
            if (cliente is null)
            {
                return null;
            }

            return new ClienteDTO
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Senha = cliente.Senha,
                Telefone = cliente.Telefone,
                Data_Nascimento = cliente.Data_Nascimento
            };
        }







        public static Cliente? ToCliente(this ClienteDTO clienteDTO)
        {
            if (clienteDTO is null)
            {
                return null;
            }

            return new Cliente
            {
                ClienteId = clienteDTO.ClienteId,
                Nome = clienteDTO.Nome,
                Email = clienteDTO.Email,
                Senha = clienteDTO.Senha,
                Telefone = clienteDTO.Telefone,
                Data_Nascimento = clienteDTO.Data_Nascimento
            };
        }








        public static IEnumerable<ClienteDTO> ToClienteDTOList(this IEnumerable<Cliente> clientes)
        {

            if (clientes is null || !clientes.Any())
            {
                return new List<ClienteDTO>();
            }


            return clientes.Select(cli => new ClienteDTO
            {
                ClienteId = cli.ClienteId,
                Nome = cli.Nome,
                Email = cli.Email,
                Senha = cli.Senha,
                Telefone = cli.Telefone,
                Data_Nascimento = cli.Data_Nascimento
            }).ToList();

        }
    }
}