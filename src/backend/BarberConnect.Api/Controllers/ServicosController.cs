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
    public class ServicosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Servicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicoResponse>>> GetServicos()
        {
            var servicos = await _context.Servicos
                .Include(s => s.Barbeiro)
                .ToListAsync();

            return Ok(servicos.Select(s => new ServicoResponse(s)));
        }

        // GET: api/Servicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoResponse>> GetServico(int id)
        {
            var servico = await _context.Servicos
                .Include(s => s.Barbeiro)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (servico == null)
            {
                return NotFound("Serviço não encontrado");
            }

            return Ok(new ServicoResponse(servico));
        }

        // POST: api/Servicos
        [HttpPost]
        public async Task<ActionResult<ServicoResponse>> PostServico([FromBody] ServicoRequest request)
        {
            if (request == null)
            {
                return BadRequest("Dados do serviço inválidos");
            }

            var servico = new Servico
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Preco = request.Preco,
                Duracao = request.Duracao,
                BarbeiroId = request.BarbeiroId
            };

            _context.Servicos.Add(servico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServico), new { id = servico.Id }, new ServicoResponse(servico));
        }

        // PUT: api/Servicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServico(int id, [FromBody] ServicoRequest request)
        {
            var servico = await _context.Servicos.FindAsync(id);

            if (servico == null)
            {
                return NotFound("Serviço não encontrado");
            }

            servico.Nome = request.Nome;
            servico.Descricao = request.Descricao;
            servico.Preco = request.Preco;
            servico.Duracao = request.Duracao;
            servico.BarbeiroId = request.BarbeiroId;

            _context.Entry(servico).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Servicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServico(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);

            if (servico == null)
            {
                return NotFound("Serviço não encontrado");
            }

            _context.Servicos.Remove(servico);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
