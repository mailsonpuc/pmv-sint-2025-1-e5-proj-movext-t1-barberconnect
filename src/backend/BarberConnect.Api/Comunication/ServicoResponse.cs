using BarberConnect.Api.Models;

namespace BarberConnect.Api.Comunication
{
    public class ServicoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Duracao { get; set; }
        public Barbeiro Barbeiro { get; set; }

        public ServicoResponse(Servico servico)
        {
            Id = servico.Id;
            Nome = servico.Nome;
            Descricao = servico.Descricao;
            Preco = servico.Preco;
            Duracao = servico.Duracao;
            Barbeiro = servico.Barbeiro;
        }
    }
}
