

using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;

namespace BarberConnect.Api.Repositories
{
    public class HorarioDisponivelRepository: Repository<HorarioDisponivel>, IHorarioDisponivelRepository
    {
        public HorarioDisponivelRepository(AppDbContext context) : base(context)
        {
        }
    }
}