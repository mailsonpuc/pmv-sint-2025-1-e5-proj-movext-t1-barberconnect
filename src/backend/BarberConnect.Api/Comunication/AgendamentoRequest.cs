namespace BarberConnect.Api.Comunication
{
    public class AgendamentoRequest
    {
        public string? Status { get; set; }
        public int IdCliente { get; set; }
        public int IdServico { get; set; }
        public int IdHorario { get; set; }
        public int IdBarbeiro { get; set; }
    }
}
