using BarberConnect.Api.Comunication;
using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BarberConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoClientes : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistoricoClientes(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("historico")]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetHistoricoAtendimentos(
        
        [FromQuery] string? status,
        [FromQuery] string? clienteNome,
        [FromQuery] int barbeiroId,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
        
        {
            

            // Query base
            var query = _context.Agendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Servico)
                .Where(a => a.IdBarbeiro == barbeiroId)
                .AsQueryable();

            // Aplicar filtros
            

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(a => a.Status == status);
            }

            if (!string.IsNullOrEmpty(clienteNome))
            {
                query = query.Where(a => a.Cliente.Nome.Contains(clienteNome));
            }

            // Paginação
            var agendamentos = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new HistoricoResponse

                {
                    Id = a.IdBarbeiro,
                    ClienteNome = a.Cliente.Nome,
                    ServicoNome = a.Servico.Nome,
                    Status = a.Status
                })
                .ToListAsync();

            return Ok(agendamentos);
        }
    }
}
