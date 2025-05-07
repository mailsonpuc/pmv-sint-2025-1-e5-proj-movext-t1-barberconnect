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
    public class ClienteController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IUnitOfWork uof, ILogger<ClienteController> logger)
        {
            _uof = uof;
            _logger = logger;
        }







        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clientes = await _uof.ClienteRepository.GetAllAsync();

            if (clientes is null)
            {
                _logger.LogWarning($"Não existem clientes ...");
                return NotFound("Não existem clientes...");
            }

            var clientesDto = clientes.ToClienteDTOList();

            return Ok(clientesDto);
        }






        [Authorize]
        [HttpGet("{id:int}", Name = "ObterCliente")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var cliente = await _uof.ClienteRepository.GetAsync(c => c.ClienteId == id);

            if (cliente is null)
            {
                _logger.LogWarning($"cliente com id= {id} não encontrado...");
                return NotFound($"cliente com id= {id} não encontrado...");
            }

            var clienteDto = cliente.ToClienteDTO();

            return Ok(clienteDto);
        }






        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Post(ClienteDTO ClienteDto)
        {
            if (ClienteDto is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var cliente = ClienteDto.ToCliente();

            var clienteCriado = _uof.ClienteRepository.Create(cliente);
            await _uof.Commit();

            var novoClienteDto = clienteCriado.ToClienteDTO();

            return new CreatedAtRouteResult("ObterCliente",
                new { id = novoClienteDto.ClienteId },
                novoClienteDto);
        }




        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ClienteDTO>> Put(int id, ClienteDTO clienteDto)
        {
            if (id != clienteDto.ClienteId)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var cliente = clienteDto.ToCliente();

            var clienteAtualizada = _uof.ClienteRepository.Update(cliente);
            await _uof.Commit();

            var clienteAtualizadaDto = clienteAtualizada.ToClienteDTO();

            return Ok(clienteAtualizadaDto);
        }





        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ClienteDTO>> Delete(int id)
        {
            var cliente = await _uof.ClienteRepository.GetAsync(c => c.ClienteId == id);

            if (cliente is null)
            {
                _logger.LogWarning($"cliente com id={id} não encontrado...");
                return NotFound($"cliente com id={id} não encontrado...");
            }

            var clienteExcluida = _uof.ClienteRepository.Delete(cliente);
            await _uof.Commit();

            var clienteExcluidaDto = clienteExcluida.ToClienteDTO();

            return Ok(clienteExcluidaDto);
        }






    }
}