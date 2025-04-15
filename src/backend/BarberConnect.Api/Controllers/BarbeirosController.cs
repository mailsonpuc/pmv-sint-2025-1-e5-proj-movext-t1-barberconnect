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
    public class BarbeirosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BarbeirosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Barbeiros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barbeiro>>> GetBarbeiros()
        {
            return await _context.Barbeiros.ToListAsync();
        }

        // GET: api/Barbeiros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Barbeiro>> GetBarbeiro(int id)
        {
            var barbeiro = await _context.Barbeiros.FindAsync(id);

            if (barbeiro == null)
            {
                return NotFound();
            }

            return barbeiro;
        }

        // PUT: api/Barbeiros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarbeiro(int id, Barbeiro barbeiro)
        {
            if (id != barbeiro.Id)
            {
                return BadRequest();
            }

            _context.Entry(barbeiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarbeiroExists(id))
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

        // POST: api/Barbeiros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Barbeiro>> PostBarbeiro(Barbeiro barbeiro)
        {
            _context.Barbeiros.Add(barbeiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBarbeiro", new { id = barbeiro.Id }, barbeiro);
        }

        // DELETE: api/Barbeiros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarbeiro(int id)
        {
            var barbeiro = await _context.Barbeiros.FindAsync(id);
            if (barbeiro == null)
            {
                return NotFound();
            }

            _context.Barbeiros.Remove(barbeiro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarbeiroExists(int id)
        {
            return _context.Barbeiros.Any(e => e.Id == id);
        }
    }
}
