

using System.ComponentModel.DataAnnotations;

namespace BarberConnect.Api.DTOS
{
    public class ServicoDTO
    {
        [Key]
        public int ServicoId { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }
    }
}