
using System.ComponentModel.DataAnnotations;

namespace BarberConnect.Api.DTOS
{
    public class ClienteDTO
    {
        [Key]
        public int ClienteId { get; set; }
        public string? Nome { get; set; }


        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Telefone { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_Nascimento { get; set; }


    }
}