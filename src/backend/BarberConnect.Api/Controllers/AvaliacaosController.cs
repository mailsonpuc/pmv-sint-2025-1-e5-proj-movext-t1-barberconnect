using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using BarberConnect.Api.Comunication;

namespace BarberConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AvaliacaosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao([FromBody] AvaliaçãoRequest request)
        {
            var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.IdAgendamento == request.IdAgendamento);

            if (agendamento == null)
            {
                return NotFound();
            }

            if (agendamento.Status != "Concluído")
            {
                return BadRequest("Avaliação só pode ser realizada após concluída");
            }

            if (await _context.Avaliacoes.AnyAsync(e => e.IdAgendamento == request.IdAgendamento))
            {
                return BadRequest("Este agendamento já foi avaliado.");
            }

            var avaliacao = new Avaliacao()
            {
                Nota = request.Nota,
                Comentario = request.Comentario,
                BarbeiroId = agendamento.IdBarbeiro,
                ClienteId = agendamento.IdCliente,
                IdAgendamento = agendamento.IdAgendamento

            };
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetAvaliacao), new { id = avaliacao.IdAvaliacao }, avaliacao);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> GetAvaliacao([FromRoute] int id)
        {
            var avaliacao = await _context.Avaliacoes
                .Include(e => e.Cliente)
                .Include(e => e.Barbeiro)
                .Include(e => e.Agendamento)
                .FirstOrDefaultAsync(e => e.IdAvaliacao == id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            return avaliacao;
        }
        [HttpGet("barbeiro/{barbeiroId}")]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacoesPorBarbeiro(int barbeiroId)
        {
            return await _context.Avaliacoes
                .Include(e => e.Cliente)
                .Include(e => e.Agendamento)
                .Where(e => e.BarbeiroId == barbeiroId)
                .ToListAsync();
        }
    }
}
