using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberConnect.Api.Context;
using BarberConnect.Api.Models;

namespace BarberConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoCortesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistoricoCortesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HistoricoCortes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoCorte>>> GetHistoricosCorte()
        {
            return await _context.HistoricosCorte.ToListAsync();
        }

        // GET: api/HistoricoCortes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoCorte>> GetHistoricoCorte(int id)
        {
            var historicoCorte = await _context.HistoricosCorte.FindAsync(id);

            if (historicoCorte == null)
            {
                return NotFound();
            }

            return historicoCorte;
        }

        // PUT: api/HistoricoCortes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoricoCorte(int id, HistoricoCorte historicoCorte)
        {
            if (id != historicoCorte.IdHistorico)
            {
                return BadRequest();
            }

            _context.Entry(historicoCorte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricoCorteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HistoricoCortes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistoricoCorte>> PostHistoricoCorte(HistoricoCorte historicoCorte)
        {
            _context.HistoricosCorte.Add(historicoCorte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoricoCorte", new { id = historicoCorte.IdHistorico }, historicoCorte);
        }

        // DELETE: api/HistoricoCortes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoricoCorte(int id)
        {
            var historicoCorte = await _context.HistoricosCorte.FindAsync(id);
            if (historicoCorte == null)
            {
                return NotFound();
            }

            _context.HistoricosCorte.Remove(historicoCorte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoricoCorteExists(int id)
        {
            return _context.HistoricosCorte.Any(e => e.IdHistorico == id);
        }
    }
}
