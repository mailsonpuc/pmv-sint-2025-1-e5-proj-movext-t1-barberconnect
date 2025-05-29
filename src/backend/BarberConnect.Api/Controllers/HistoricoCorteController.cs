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
    [ApiConventionType(typeof(DefaultApiConventions))] //documenta todos os retorno statusCode do controller
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoCorteController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly ILogger<HistoricoCorteController> _logger;

        public HistoricoCorteController(IUnitOfWork uof, ILogger<HistoricoCorteController> logger)
        {
            _uof = uof;
            _logger = logger;
        }








        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoCorteDTO>>> Get()
        {
            var historicoCortes = await _uof.HistoricoCorteRepository.GetAllAsync();

            if (historicoCortes is null)
            {
                _logger.LogWarning($"Não existem historicoCortes ...");
                return NotFound("Não existem historicoCortes...");
            }

            var historicoCortesDto = historicoCortes.ToHistoricoCorteDTOList();

            return Ok(historicoCortesDto);
        }








        [Authorize]
        [HttpGet("{id:int}", Name = "ObterHistorioCorte")]
        public async Task<ActionResult<HistoricoCorteDTO>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var historicoCorte = await _uof.HistoricoCorteRepository.GetAsync(c => c.HistoricoCorteId == id);

            if (historicoCorte is null)
            {
                _logger.LogWarning($"historicoCorte com id= {id} não encontrado...");
                return NotFound($"historicoCorte com id= {id} não encontrado...");
            }

            var historicoCorteDto = historicoCorte.ToHistoricoCortDTO();

            return Ok(historicoCorte);
        }








        [Authorize]
        [HttpPost]
        public async Task<ActionResult<HistoricoCorteDTO>> Post(HistoricoCorteDTO historicoCorteDto)
        {
            if (historicoCorteDto is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var historicoCorte = historicoCorteDto.ToHistoricoCorte();

            var historicoCorteCriado = _uof.HistoricoCorteRepository.Create(historicoCorte);
            await _uof.Commit();

            var novohistoricoCorteDto = historicoCorteCriado.ToHistoricoCortDTO();

            return new CreatedAtRouteResult("ObterHistorioCorte",
                new { id = novohistoricoCorteDto.HistoricoCorteId },
                novohistoricoCorteDto);
        }





        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<HistoricoCorteDTO>> Put(int id, HistoricoCorteDTO historicoCorteDto)
        {
            if (id != historicoCorteDto.HistoricoCorteId)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var historicoCorte = historicoCorteDto.ToHistoricoCorte();

            var historicoCorteAtualizada = _uof.HistoricoCorteRepository.Update(historicoCorte);
            await _uof.Commit();

            var historicoCorteAtualizadaDto = historicoCorteAtualizada.ToHistoricoCortDTO();

            return Ok(historicoCorteAtualizadaDto);
        }






        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HistoricoCorteDTO>> Delete(int id)
        {
            var historicoCorte = await _uof.HistoricoCorteRepository.GetAsync(c => c.HistoricoCorteId == id);

            if (historicoCorte is null)
            {
                _logger.LogWarning($"historicoCorte com id={id} não encontrada...");
                return NotFound($"historicoCorte com id={id} não encontrada...");
            }

            var historicoCorteExcluida = _uof.HistoricoCorteRepository.Delete(historicoCorte);
            await _uof.Commit();

            var historicoCortelExcluidaDto = historicoCorteExcluida.ToHistoricoCortDTO();

            return Ok(historicoCortelExcluidaDto);
        }






    }
}