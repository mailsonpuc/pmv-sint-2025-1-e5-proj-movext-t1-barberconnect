
using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repository.Interfaces;

namespace BarberConnect.Api.Repository
{
    public class AgendamentoRepository : Repository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(AppDbContext context) : base(context)
        {

        }

    }
}