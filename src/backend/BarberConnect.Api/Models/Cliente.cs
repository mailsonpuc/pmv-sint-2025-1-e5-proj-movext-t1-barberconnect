using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarberConnect.Api.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [StringLength(100)]
        public string? Senha { get; set; }

        [Required]
        [StringLength(13)]
        public string? Telefone { get; set; }

        public DateTime Data_nascimento { get; set; }

        [Required]
        [StringLength(100)]
        public string? Cidade { get; set; }
    }
}