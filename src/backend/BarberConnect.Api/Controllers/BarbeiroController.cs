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
    public class BarbeiroController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly ILogger<BarbeiroController> _logger;

        public BarbeiroController(IUnitOfWork uof, ILogger<BarbeiroController> logger)
        {
            _uof = uof;
            _logger = logger;
        }







        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BarbeiroDTO>>> Get()
        {
            var barbeiros = await _uof.BarbeiroRepository.GetAllAsync();

            if (barbeiros is null)
            {
                _logger.LogWarning($"Não existem barbeiros ...");
                return NotFound("Não existem barbeiros...");
            }

            var barbeirosDto = barbeiros.ToBarbeiroDTOList();

            return Ok(barbeirosDto);
        }




        [Authorize]
        [HttpGet("{id:int}", Name = "ObterBarbeiro")]
        public async Task<ActionResult<BarbeiroDTO>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            
            var barbeiro = await _uof.BarbeiroRepository.GetAsync(c => c.BarbeiroId == id);

            if (barbeiro is null)
            {
                _logger.LogWarning($"barbeiro com id= {id} não encontrado...");
                return NotFound($"barbeiro com id= {id} não encontrado...");
            }

            var barbeiroDto = barbeiro.ToBarbeiroDTO();

            return Ok(barbeiroDto);
        }







        [Authorize]
        [HttpPost]
        public async Task<ActionResult<BarbeiroDTO>> Post(BarbeiroDTO BarbeiroDto)
        {
            if (BarbeiroDto is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var barbeiro = BarbeiroDto.ToBarbeiro();

            var barbeiroCriado = _uof.BarbeiroRepository.Create(barbeiro);
            await _uof.Commit();

            var novoBarbeiroDto = barbeiroCriado.ToBarbeiroDTO();
            _logger.LogInformation($"ID do barbeiro criado: {novoBarbeiroDto.BarbeiroId}");


            return new CreatedAtRouteResult("ObterBarbeiro",
                new { id = novoBarbeiroDto.BarbeiroId },
                novoBarbeiroDto);
        }






        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<BarbeiroDTO>> Put(int id, BarbeiroDTO barbeiroDto)
        {
            if (id != barbeiroDto.BarbeiroId)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var barbeiro = barbeiroDto.ToBarbeiro();

            var barbeiroAtualizada = _uof.BarbeiroRepository.Update(barbeiro);
            await _uof.Commit();

            var barbeiroAtualizadaDto = barbeiroAtualizada.ToBarbeiroDTO();

            return Ok(barbeiroAtualizadaDto);
        }





        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<BarbeiroDTO>> Delete(int id)
        {
            var barbeiro = await _uof.BarbeiroRepository.GetAsync(c => c.BarbeiroId == id);

            if (barbeiro is null)
            {
                _logger.LogWarning($"barbeiro com id={id} não encontrado...");
                return NotFound($"barbeiro com id={id} não encontrado...");
            }

            var barbeiroExcluida = _uof.BarbeiroRepository.Delete(barbeiro);
            await _uof.Commit();

            var barbeiroExcluidaDto = barbeiroExcluida.ToBarbeiroDTO();

            return Ok(barbeiroExcluidaDto);
        }





    }
}