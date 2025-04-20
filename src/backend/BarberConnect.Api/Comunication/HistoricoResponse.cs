namespace BarberConnect.Api.Comunication
{
    public class HistoricoResponse
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string ClienteNome { get; set; }
        public string ServicoNome { get; set; }
        public string Status { get; set; }
    }
}
