namespace BarberConnect.Api.Models
{
    public class ServicoModel
    {
        public int IdServico { get; set; }
        public string? NomeServico { get; set; }
        public string? DescricaoServico { get; set; }
        public int Duracao { get; set; }
        public decimal Preco { get; set; }
    }
}
