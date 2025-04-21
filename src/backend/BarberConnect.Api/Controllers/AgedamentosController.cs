using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using BarberConnect.Api.Comunication;

namespace BarberConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgendamentoResponse>> GetAgendamento(int id)
        {
            var agendamento = await _context.Agendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Servico)
                .Include(a => a.HorarioDisponivel)
                .Include(a => a.Barbeiro)
                .FirstOrDefaultAsync(a => a.IdAgendamento == id);

            if (agendamento == null)
                return NotFound("Agendamento não encontrado");

            return Ok(new AgendamentoResponse(agendamento));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoResponse>>> GetAgendamentos()
        {
            var agendamentos = await _context.Agendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Servico)
                .Include(a => a.HorarioDisponivel)
                .Include(a => a.Barbeiro)
                .ToListAsync();

            return Ok(agendamentos.Select(a => new AgendamentoResponse(a)));
        }

        [HttpPost]
        public async Task<ActionResult<AgendamentoResponse>> PostAgendamento([FromBody] AgendamentoRequest request)
        {
            if (request == null)
                return BadRequest("Dados inválidos");

            var agendamento = new Agendamento
            {
                Status = request.Status,
                LembreteEnviado = false,
                IdCliente = request.IdCliente,
                IdServico = request.IdServico,
                IdHorario = request.IdHorario,
                IdBarbeiro = request.IdBarbeiro
            };

            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgendamento), new { id = agendamento.IdAgendamento }, new AgendamentoResponse(agendamento));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamento(int id, [FromBody] AgendamentoRequest request)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);

            if (agendamento == null)
                return NotFound("Agendamento não encontrado");

            agendamento.Status = request.Status;
            agendamento.IdCliente = request.IdCliente;
            agendamento.IdServico = request.IdServico;
            agendamento.IdHorario = request.IdHorario;
            agendamento.IdBarbeiro = request.IdBarbeiro;

            _context.Entry(agendamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamento(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);

            if (agendamento == null)
                return NotFound("Agendamento não encontrado");

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
