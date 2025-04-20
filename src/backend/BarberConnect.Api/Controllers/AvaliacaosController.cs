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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
        [Authorize(Policy = "Cliente")] 
        public async Task<ActionResult<AvaliacaoResponse>> PostAvaliacao(
        [FromBody] AvaliacaoRequest request)
        {
            
         

            // Buscar agendamento
            var agendamento = await _context.Agendamentos
                .FirstOrDefaultAsync(a =>
                    a.IdAgendamento  == request.IdAgendamento );

            if (agendamento == null)
            {
                return BadRequest("Agendamento não encontrado ou não concluído.");
            }

            // Verificar se já existe avaliação
            if (await _context.Avaliacoes.AnyAsync(a => a.IdAgendamento == request.IdAgendamento))
            {
                return Conflict("Este agendamento já foi avaliado.");
            }

            // Criar avaliação
            var avaliacao = new Avaliacao
            {
                Nota = request.Nota,
                Comentario = request.Comentario,
                IdAgendamento = agendamento.IdAgendamento,
                ClienteId = agendamento.IdCliente,
                BarbeiroId = agendamento.IdBarbeiro
            };

            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();

            // Retornar DTO com dados relevantes
            return CreatedAtAction(nameof(GetAvaliacao), new { id = avaliacao.IdAvaliacao },
                new AvaliacaoResponse(avaliacao));

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
