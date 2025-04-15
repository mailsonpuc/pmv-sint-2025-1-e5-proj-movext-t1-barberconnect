using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repository.Interfaces;

namespace BarberConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly IRepository<Servico> _repository;

        public ServicosController(IRepository<Servico> repository)
        {
            _repository = repository;
        }

        // GET: api/Servicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servico>>> GetServicos()
        {
            var servicos = await _repository.GetAllAsync();
            return Ok(servicos);
        }

        // GET: api/Servicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servico>> GetServico(int id)
        {
            var servico = await _repository.GetAsync(s => s.Id == id);

            if (servico == null)
            {
                return NotFound("Serviço não encontrado");
            }

            return servico;
        }

        // PUT: api/Servicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServico(int id, Servico servico)
        {
            if (id != servico.Id)
            {
                return BadRequest("ID do serviço não corresponde");
            }

            try
            {
                await _repository.UpdateAsync(servico);
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o serviço");
            }
        }

        // POST: api/Servicos
        [HttpPost]
        public async Task<ActionResult<Servico>> PostServico(Servico servico)
        {
            if (servico == null)
            {
                return BadRequest("Dados do serviço inválidos");
            }

            try
            {
                var servicoCriado = await _repository.CreateAsync(servico);
                return CreatedAtAction(nameof(GetServico), 
                    new { id = servicoCriado.Id }, 
                    servicoCriado);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao criar o serviço");
            }
        }

        // DELETE: api/Servicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServico(int id)
        {
            var servico = await _repository.GetAsync(s => s.Id == id);
            if (servico == null)
            {
                return NotFound("Serviço não encontrado");
            }

            try
            {
                await _repository.DeleteAsync(servico);
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao excluir o serviço");
            }
        }
    }
}