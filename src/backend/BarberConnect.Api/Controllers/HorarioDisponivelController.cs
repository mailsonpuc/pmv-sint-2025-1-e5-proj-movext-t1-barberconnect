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
    public class HorarioDisponivelController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        private readonly ILogger<HorarioDisponivelController> _logger;

        public HorarioDisponivelController(IUnitOfWork uof, ILogger<HorarioDisponivelController> logger)
        {
            _uof = uof;
            _logger = logger;
        }







        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorarioDisponivelDTO>>> Get()
        {
            var horariosDisponivels = await _uof.HorarioDisponivelRepository.GetAllAsync();

            if (horariosDisponivels is null)
            {
                _logger.LogWarning($"Não existem horariosDisponivels ...");
                return NotFound("Não existem horariosDisponivels ...");
            }

            var horariosDisponivelsDto = horariosDisponivels.ToHorarioDisponivelDTOList();

            return Ok(horariosDisponivelsDto);
        }





        [Authorize]
        [HttpGet("{id:int}", Name = "ObterHorarioDisponivel")]
        public async Task<ActionResult<HorarioDisponivelDTO>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var horarioDisponivel = await _uof.HorarioDisponivelRepository.GetAsync(c => c.HorarioDisponivelId == id);

            if (horarioDisponivel is null)
            {
                _logger.LogWarning($"horarioDisponivel com id= {id} não encontrado...");
                return NotFound($"horarioDisponivel com id= {id} não encontrado...");
            }

            var horarioDisponivelDto = horarioDisponivel.ToHorarioDisponivelDTO();

            return Ok(horarioDisponivelDto);
        }





        [Authorize]
        [HttpPost]
        public async Task<ActionResult<HorarioDisponivelDTO>> Post(HorarioDisponivelDTO horarioDisponivelDto)
        {
            if (horarioDisponivelDto is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var horarioDisponivel = horarioDisponivelDto.ToHorarioDisponivel();

            var horarioDisponivelCriado = _uof.HorarioDisponivelRepository.Create(horarioDisponivel);
            await _uof.Commit();

            var novohorarioDisponivelDto = horarioDisponivelCriado.ToHorarioDisponivelDTO();

            return new CreatedAtRouteResult("ObterHorarioDisponivel",
                new { id = novohorarioDisponivelDto.HorarioDisponivelId },
                novohorarioDisponivelDto);
        }




        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<HorarioDisponivelDTO>> Put(int id, HorarioDisponivelDTO horarioDisponivelDto)
        {
            if (id != horarioDisponivelDto.HorarioDisponivelId)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var horarioDisponivel = horarioDisponivelDto.ToHorarioDisponivel();

            var horarioDisponivelAtualizada = _uof.HorarioDisponivelRepository.Update(horarioDisponivel);
            await _uof.Commit();

            var horarioDisponivelAtualizadaDto = horarioDisponivelAtualizada.ToHorarioDisponivelDTO();

            return Ok(horarioDisponivelAtualizadaDto);
        }





        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HorarioDisponivelDTO>> Delete(int id)
        {
            var horarioDisponivel = await _uof.HorarioDisponivelRepository.GetAsync(c => c.HorarioDisponivelId == id);

            if (horarioDisponivel is null)
            {
                _logger.LogWarning($"horarioDisponivel com id={id} não encontrada...");
                return NotFound($"horarioDisponivel com id={id} não encontrada...");
            }

            var horarioDisponivelExcluida = _uof.HorarioDisponivelRepository.Delete(horarioDisponivel);
            await _uof.Commit();

            var horarioDisponivelExcluidaDto = horarioDisponivelExcluida.ToHorarioDisponivelDTO();

            return Ok(horarioDisponivelExcluidaDto);
        }





    }
}