

using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using BarberConnect.Api.Pagination;
using BarberConnect.Api.Repositories.Interfaces;
using X.PagedList;

namespace BarberConnect.Api.Repositories
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(AppDbContext context) : base(context)
        {
        }



        //algoritmo da paginação por nome
        public async Task<IPagedList<Servico>> GetServicosAsync(ServicoParameters
                                                                       servicosParams)
        {
            var servicos = await GetAllAsync();

            // OrderBy síncrono
            var servicosOrdenadas = servicos.OrderBy(p => p.ServicoId).ToList();

            var resultado = await servicosOrdenadas.ToPagedListAsync(servicosParams.PageNumber,
                                                                       servicosParams.PageSize);

            return resultado;
        }



        public async Task<IPagedList<Servico>> GetServicosFiltroNomeAsync(
            ServicoFiltroNome servicosParams)
        {
            var servicos = await GetAllAsync();

            if (!string.IsNullOrEmpty(servicosParams.Nome))
            {
                servicos = servicos.Where(c => c.Nome.Contains(servicosParams.Nome));
            }

            var servicosFiltradas = await servicos.ToPagedListAsync(
                                                 servicosParams.PageNumber,
                                                 servicosParams.PageSize);

            return servicosFiltradas;
        }



    }
}