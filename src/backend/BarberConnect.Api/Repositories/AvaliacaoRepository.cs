

using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;

namespace BarberConnect.Api.Repositories
{
    public class AvaliacaoRepository : Repository<Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(AppDbContext context) : base(context)
        {
        }
    }
}