
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BarberConnect.Api.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }



        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        [MinLength(5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres.")]
        public string? Nome { get; set; }




        [Required(ErrorMessage = "O email é obrigatório.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        [MinLength(5, ErrorMessage = "O email deve ter no mínimo 5 caracteres.")]
        public string? Email { get; set; }




        [Required(ErrorMessage = "A senha é obrigatório.")]
        [StringLength(100, ErrorMessage = "A senha deve ter no máximo 100 caracteres.")]
        [MinLength(5, ErrorMessage = "A senha deve ter no mínimo 5 caracteres.")]
        public string? Senha { get; set; }




        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(80, ErrorMessage = "O telefone deve ter no máximo 80 caracteres.")]
        [MinLength(5, ErrorMessage = "A senha deve ter no mínimo 5 caracteres.")]
        public string? Telefone { get; set; }


        public DateTime Data_nascimento { get; set; }




        [Required(ErrorMessage = "O nome  da cidade é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da cidade deve ter no máximo 100 caracteres.")]
        [MinLength(5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres.")]
        public string? Cidade { get; set; }
    }
}