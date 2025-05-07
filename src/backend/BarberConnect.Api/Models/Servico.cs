

using System.ComponentModel.DataAnnotations;

namespace BarberConnect.Api.Models
{
    public class Servico
    {
        [Key]
        public int ServicoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }


        public ICollection<Barbeiro>? Barbeiros { get; set; }


    }
}