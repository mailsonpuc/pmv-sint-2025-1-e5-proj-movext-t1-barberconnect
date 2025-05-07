

using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;

namespace BarberConnect.Api.Repositories
{
    public class HistoricoCorteRepository : Repository<HistoricoCorte>, IHistoricoCorteRepository
    {
        public HistoricoCorteRepository(AppDbContext context) : base(context)
        {
        }

        
    }
}