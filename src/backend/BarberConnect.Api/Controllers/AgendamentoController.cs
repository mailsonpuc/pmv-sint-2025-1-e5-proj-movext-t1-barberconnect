using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.DTOS.Mappings;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarberConnect.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly ILogger<AgendamentoController> _logger;


        public AgendamentoController(IUnitOfWork uof, ILogger<AgendamentoController> logger)
        {
            _uof = uof;
            _logger = logger;
        }




        /// <summary>
        /// Obtém todos os agendamentos.
        /// </summary>
        /// <returns>Lista de agendamentos</returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoDTO>>> Get()
        {
            var agendamentos = await _uof.AgendamentoRepository.GetAllAsync();

            if (agendamentos is null)
            {
                _logger.LogWarning($"Não existem agendamentos...");
                return NotFound("Não existem agendamentos...");
            }

            var agendamentosDto = agendamentos.ToAgendamentoDTOList();

            return Ok(agendamentosDto);
        }










        [Authorize]
        [HttpGet("{id:int}", Name = "ObterAgendamento")]
        public async Task<ActionResult<AgendamentoDTO>> Get(int id)
        {
            var agendamento = await _uof.AgendamentoRepository.GetAsync(c => c.AgendamentoId == id);

            if (agendamento is null)
            {
                _logger.LogWarning($"agendamento com id= {id} não encontrado...");
                return NotFound($"agendamento com id= {id} não encontrado...");
            }

            var agendamentoDto = agendamento.ToAgendamentoDTO();

            return Ok(agendamentoDto);
        }






        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AgendamentoDTO>> Post(AgendamentoDTO agendamentoDto)
        {
            if (agendamentoDto is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var agendamento = agendamentoDto.ToAgendamento();

            var agendamentoCriado = _uof.AgendamentoRepository.Create(agendamento);
            await _uof.Commit();

            var novoAgendamentoDto = agendamentoCriado.ToAgendamentoDTO();

            return new CreatedAtRouteResult("ObterAgendamento",
                new { id = novoAgendamentoDto.AgendamentoId },
                novoAgendamentoDto);
        }




        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<AgendamentoDTO>> Put(int id, AgendamentoDTO agendamentoDto)
        {
            if (id != agendamentoDto.AgendamentoId)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var agendamento = agendamentoDto.ToAgendamento();

            var agendamentoAtualizada = _uof.AgendamentoRepository.Update(agendamento);
            await _uof.Commit();

            var agendamentoAtualizadaDto = agendamentoAtualizada.ToAgendamentoDTO();

            return Ok(agendamentoAtualizadaDto);
        }





        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AgendamentoDTO>> Delete(int id)
        {
            var agendamento = await _uof.AgendamentoRepository.GetAsync(c => c.AgendamentoId == id);

            if (agendamento is null)
            {
                _logger.LogWarning($"agendamento com id={id} não encontrado...");
                return NotFound($"agendamento com id={id} não encontrado...");
            }

            var agendamentoExcluido = _uof.AgendamentoRepository.Delete(agendamento);
            await _uof.Commit();

            var agendamentoExcluidoDto = agendamentoExcluido.ToAgendamentoDTO();

            return Ok(agendamentoExcluidoDto);
        }






    }
}