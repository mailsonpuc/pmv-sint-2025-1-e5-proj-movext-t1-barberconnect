using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repository.Interfaces;

namespace BarberConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly IRepository<Agendamento> _repository;

        public AgendamentosController(IRepository<Agendamento> repository)
        {
            _repository = repository;
        }

        // GET: api/Agendamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentos()
        {
            var agendamentos = await _repository.GetAllAsync();
            return Ok(agendamentos);
        }

        // GET: api/Agendamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
        {
            var agendamento = await _repository.GetAsync(a => a.IdAgendamento == id);

            if (agendamento == null)
            {
                return NotFound("Agendamento não encontrado");
            }

            return agendamento;
        }

        // PUT: api/Agendamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamento(int id, Agendamento agendamento)
        {
            if (id != agendamento.IdAgendamento)
            {
                return BadRequest("ID do agendamento não corresponde");
            }

            try
            {
                await _repository.UpdateAsync(agendamento);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o agendamento");
            }
        }

        // POST: api/Agendamentos
        [HttpPost]
        public async Task<ActionResult<Agendamento>> PostAgendamento(Agendamento agendamento)
        {
            if (agendamento == null)
            {
                return BadRequest("Dados do agendamento inválidos");
            }

            try
            {
                var agendamentoCriado = await _repository.CreateAsync(agendamento);
                return CreatedAtAction(nameof(GetAgendamento), 
                    new { id = agendamentoCriado.IdAgendamento }, 
                    agendamentoCriado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao criar o agendamento");
            }
        }

        // DELETE: api/Agendamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamento(int id)
        {
            var agendamento = await _repository.GetAsync(a => a.IdAgendamento == id);
            if (agendamento == null)
            {
                return NotFound("Agendamento não encontrado");
            }

            try
            {
                await _repository.DeleteAsync(agendamento);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao excluir o agendamento");
            }
        }
    }
}