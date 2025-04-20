using BarberConnect.Api.Models;

public class AvaliacaoResponse
{
    public int Id { get; set; }
    public int Nota { get; set; }
    public string? Comentario { get; set; }
    public DateTime DataAvaliacao { get; set; }
    public string BarbeiroNome { get; set; }
    public string ClienteNome { get; set; }
    public DateTime DataAgendamento { get; set; }

    public AvaliacaoResponse(Avaliacao avaliacao)
    {
        Id = avaliacao.IdAvaliacao;
        Nota = avaliacao.Nota;
        Comentario = avaliacao.Comentario;
        BarbeiroNome = avaliacao.Barbeiro.Nome;
        ClienteNome = avaliacao.Cliente.Nome;

    }
}