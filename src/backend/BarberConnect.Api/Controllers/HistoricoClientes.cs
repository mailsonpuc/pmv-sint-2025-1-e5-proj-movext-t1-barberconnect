using BarberConnect.Api.Comunication;
using BarberConnect.Api.Context;
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
        public async Task<ActionResult<IEnumerable<AgendamentoBarbeiroDTO>>> GetHistoricoAtendimentos(
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate,
        [FromQuery] string? status,
        [FromQuery] string? clienteNome,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
        {
            // Obter ID do barbeiro autenticado
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var barbeiro = await _context.Barbeiros
                .FirstOrDefaultAsync(b => b.UsuarioId == usuarioId);

            if (barbeiro == null)
            {
                return NotFound("Barbeiro não encontrado.");
            }

            // Query base
            var query = _context.Agendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Servico)
                .Where(a => a.IdBarbeiro == barbeiro.Id)
                .AsQueryable();

            // Aplicar filtros
            if (startDate != null)
            {
                query = query.Where(a => a.DataHora >= startDate);
            }

            if (endDate != null)
            {
                query = query.Where(a => a.DataHora <= endDate);
            }

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
                .OrderByDescending(a => a.DataHora)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new HistoricoResponse

                {
                    Id = a.Id,
                    DataHora = a.DataHora,
                    ClienteNome = a.Cliente.Nome,
                    ServicoNome = a.Servico.Nome,
                    Status = a.Status
                })
                .ToListAsync();

            return Ok(agendamentos);
        }
    }
}
