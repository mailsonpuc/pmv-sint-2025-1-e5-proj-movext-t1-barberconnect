

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberConnect.Api.Models
{
    public class Oferece
    {
        [Key, Column(Order = 0)]
        public int IdBarbeiro { get; set; }

        [Key, Column(Order = 1)]
        public int IdServico { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        public int Duracao { get; set; } // em minutos

        [ForeignKey("IdBarbeiro")]
        public Barbeiro Barbeiro { get; set; } = null!;

        [ForeignKey("IdServico")]
        public Servico Servico { get; set; } = null!;
    }
}