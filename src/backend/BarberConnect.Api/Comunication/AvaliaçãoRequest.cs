using System.ComponentModel.DataAnnotations;

namespace BarberConnect.Api.Comunication
{
    public class AvaliaçãoRequest
    {
        [Range(1, 5)]
        public int Nota { get; set; }

        public int IdAgendamento { get; set; }

        public string? Comentario { get; set; }

        

    }
}
