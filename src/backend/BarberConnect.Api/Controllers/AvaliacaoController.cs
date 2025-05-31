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
    public class AvaliacaoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly ILogger<AvaliacaoController> _logger;

        public AvaliacaoController(IUnitOfWork uof, ILogger<AvaliacaoController> logger) //conserto AvaliacaoController
        {
            _uof = uof;
            _logger = logger;
        }





        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvaliacaoDTO>>> Get()
        {
            var avaliacoes = await _uof.AvaliacaoRepository.GetAllAsync();

            if (avaliacoes is null)
            {
                _logger.LogWarning($"Não existem avaliacoes ...");
                return NotFound("Não existem avaliacoes...");
            }

            var avaliacoesDto = avaliacoes.ToAvaliacaoDTOList();

            return Ok(avaliacoesDto);
        }



        [Authorize]
        [HttpGet("{id:int}", Name = "ObterAvaliacao")]
        public async Task<ActionResult<AvaliacaoDTO>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var avaliacao = await _uof.AvaliacaoRepository.GetAsync(c => c.AvaliacaoId == id);

            if (avaliacao is null)
            {
                _logger.LogWarning($"avaliacao com id= {id} não encontrado...");
                return NotFound($"avaliacao com id= {id} não encontrado...");
            }

            var avaliacaoDto = avaliacao.ToAvaliacaoDTO();

            return Ok(avaliacaoDto);
        }








        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AvaliacaoDTO>> Post(AvaliacaoDTO avaliacaoDto)
        {
            if (avaliacaoDto is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var avaliacao = avaliacaoDto.ToAvaliacao();

            var avaliacaoCriada = _uof.AvaliacaoRepository.Create(avaliacao);
            await _uof.Commit();

            var novaAvaliacaoDto = avaliacaoCriada.ToAvaliacaoDTO();

            return new CreatedAtRouteResult("ObterAvaliacao",
                new { id = novaAvaliacaoDto.AvaliacaoId },
                novaAvaliacaoDto);
        }





        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<AvaliacaoDTO>> Put(int id, AvaliacaoDTO avaliacaoDto)
        {
            if (id != avaliacaoDto.AvaliacaoId)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var avaliacao = avaliacaoDto.ToAvaliacao();

            var avaliacaoAtualizada = _uof.AvaliacaoRepository.Update(avaliacao);
            await _uof.Commit();

            var avaliacaoAtualizadaDto = avaliacaoAtualizada.ToAvaliacaoDTO();

            return Ok(avaliacaoAtualizadaDto);
        }





        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AvaliacaoDTO>> Delete(int id)
        {
            var avaliacao = await _uof.AvaliacaoRepository.GetAsync(c => c.AvaliacaoId == id);

            if (avaliacao is null)
            {
                _logger.LogWarning($"avaliacao com id={id} não encontrado...");
                return NotFound($"avaliacao com id={id} não encontrado...");
            }

            var avaliacaoExcluida = _uof.AvaliacaoRepository.Delete(avaliacao);
            await _uof.Commit();

            var avaliacaooExcluidaDto = avaliacaoExcluida.ToAvaliacaoDTO(); //conserto de parenteses aqui

            return Ok(avaliacaooExcluidaDto);
        }


    




    }
}