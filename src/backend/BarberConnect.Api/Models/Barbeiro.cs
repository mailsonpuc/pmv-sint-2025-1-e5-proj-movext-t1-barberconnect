

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberConnect.Api.Models
{
    public class Barbeiro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Nome { get; set; }

        [StringLength(20)]
        public string? Telefone { get; set; }



        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
        public ICollection<Servico> Servico { get; set; } = new List<Servico>();
    }
}