

using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;

namespace BarberConnect.Api.Repositories
{
    public class BarbeiroRepository : Repository<Barbeiro>, IBarbeiroRepository
    {
        public BarbeiroRepository(AppDbContext context) : base(context)
        {
        }
    }
}