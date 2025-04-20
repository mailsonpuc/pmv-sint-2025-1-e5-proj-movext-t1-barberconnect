
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberConnect.Api.Models
{
    public class Servico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public int Duracao { get; set; }

        public int BarbeiroId { get; set; }

        public Barbeiro Barbeiro { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}