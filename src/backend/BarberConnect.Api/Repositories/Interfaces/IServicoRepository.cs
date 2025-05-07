

using BarberConnect.Api.Models;
using BarberConnect.Api.Pagination;
using X.PagedList;

namespace BarberConnect.Api.Repositories.Interfaces
{
    public interface IServicoRepository : IRepository<Servico>
    {

        Task<IPagedList<Servico>> GetServicosAsync(ServicoParameters servicosParams);
        Task<IPagedList<Servico>> GetServicosFiltroNomeAsync(ServicoFiltroNome servicosParams);
    }
}