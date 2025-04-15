

using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repository.Interfaces;

namespace BarberConnect.Api.Repository
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(AppDbContext context) : base(context)
        {

        }
    }
}