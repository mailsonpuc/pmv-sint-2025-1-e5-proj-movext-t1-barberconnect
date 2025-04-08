namespace BarberConnect.Api.Models
{
    public class BarbeiroModel
    {
        public int IdBarbeiro { get; set; }
        public string? NomeBarbeiro { get; set; }
        public string? TelefoneBarbeiro { get; set; }
        public List<ServicoModel>? Servicos { get; set; }
    }
}
