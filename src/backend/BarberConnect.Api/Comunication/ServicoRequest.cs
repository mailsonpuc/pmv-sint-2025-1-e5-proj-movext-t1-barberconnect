namespace BarberConnect.Api.Comunication
{
    public class ServicoRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Duracao { get; set; }
        public int BarbeiroId { get; set; }
    }
}
