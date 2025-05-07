
using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;

namespace BarberConnect.Api.Repositories
{
    public class AgendamentoRepository : Repository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(AppDbContext context) : base(context)
        {
        }
    }
}