using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.DTOS.Mappings;
using BarberConnect.Api.Models;
using BarberConnect.Api.Pagination;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace BarberConnect.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ServicoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        private readonly ILogger<ServicoController> _logger;

        public ServicoController(IUnitOfWork uof,
        ILogger<ServicoController> logger)
        {
            _uof = uof;
            _logger = logger;
        }





        [AllowAnonymous]
        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<ServicoDTO>>> Get([FromQuery]
                               ServicoParameters servicosParameters)
        {
            var servicos = await _uof.ServicoRepository.GetServicosAsync(servicosParameters);

            return ObterServicos(servicos);
        }


        [AllowAnonymous]
        [HttpGet("filter/nome/pagination")]
        public async Task<ActionResult<IEnumerable<ServicoDTO>>> GetServicosFiltradas(
                                               [FromQuery] ServicoFiltroNome servicosFiltro)
        {
            var servicosFiltradas = await _uof.ServicoRepository
                                         .GetServicosFiltroNomeAsync(servicosFiltro);

            return ObterServicos(servicosFiltradas);

        }




        private ActionResult<IEnumerable<ServicoDTO>> ObterServicos(IPagedList<Servico> servicos)
        {
            var metadata = new
            {
                servicos.Count,
                servicos.PageSize,
                servicos.PageCount,
                servicos.TotalItemCount,
                servicos.HasNextPage,
                servicos.HasPreviousPage
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));
            var servicosDto = servicos.ToServicoDTOList();
            return Ok(servicosDto);
        }





        [AllowAnonymous]
        [HttpGet("Servicos")]
        public async Task<ActionResult<IEnumerable<ServicoDTO>>> Get()
        {
            var servicos = await _uof.ServicoRepository.GetAllAsync();

            if (servicos is null)
            {
                _logger.LogWarning($"Não existem servicos...");
                return NotFound("Não existem servicos...");
            }

            var servicosDto = servicos.ToServicoDTOList();

            return Ok(servicosDto);
        }







        [Authorize]
        [HttpGet("{id:int}", Name = "ObterServico")]
        public async Task<ActionResult<ServicoDTO>> Get(int id)
        {
            var servico = await _uof.ServicoRepository.GetAsync(c => c.ServicoId == id);

            if (servico is null)
            {
                _logger.LogWarning($"Servico com id= {id} não encontrado...");
                return NotFound($"Servico com id= {id} não encontrado...");
            }

            var servicoDto = servico.ToServicoDTO();

            return Ok(servicoDto);
        }




        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ServicoDTO>> Post(ServicoDTO servicoDto)
        {
            if (servicoDto is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var servico = servicoDto.ToServico();

            var servicoCriado = _uof.ServicoRepository.Create(servico);
            await _uof.Commit();

            var novoServicoDto = servicoCriado.ToServicoDTO();

            return new CreatedAtRouteResult("ObterServico",
                new { id = novoServicoDto.ServicoId },
                novoServicoDto);
        }





        [HttpPut("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<ServicoDTO>> Put(int id, ServicoDTO servicoDto)
        {
            if (id != servicoDto.ServicoId)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var servico = servicoDto.ToServico();

            var servicoAtualizada = _uof.ServicoRepository.Update(servico);
            await _uof.Commit();

            var servicoAtualizadaDto = servicoAtualizada.ToServicoDTO();

            return Ok(servicoAtualizadaDto);
        }



        [AllowAnonymous]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServicoDTO>> Delete(int id)
        {
            var servico = await _uof.ServicoRepository.GetAsync(c => c.ServicoId == id);

            if (servico is null)
            {
                _logger.LogWarning($"servico com id={id} não encontrada...");
                return NotFound($"servico com id={id} não encontrada...");
            }

            var servicoExcluida = _uof.ServicoRepository.Delete(servico);
            await _uof.Commit();

            var servicoExcluidaDto = servicoExcluida.ToServicoDTO();

            return Ok(servicoExcluidaDto);
        }




    }
}