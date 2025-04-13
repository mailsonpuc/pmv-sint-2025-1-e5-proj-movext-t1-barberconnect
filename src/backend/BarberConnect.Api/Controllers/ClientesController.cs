
using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberConnect.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        //usando a interface do repository
        private readonly IRepository<Cliente> _repository;

        //construtor
        public ClientesController(IRepository<Cliente> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            var clientes = _repository.GetAll();
            return Ok(clientes);
        }





        [HttpGet("{id:int}", Name = "ObterClientePorId")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = _repository.Get(c => c.ClienteId == id);
            if (cliente is null)
            {
                return NotFound("Não encontrado");
            }

           return Ok(cliente);


        }




        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            if (cliente is null)
            {
                return BadRequest("Ocorreu um erro, cheque os dados");
            }

            var clienteCriado = _repository.Create(cliente);

            return new CreatedAtRouteResult("ObterClientePorId",
            new { id = clienteCriado.ClienteId }, clienteCriado);

        }




        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest("Ocorreu um erro");
            }

            _repository.Update(cliente);
            return Ok(cliente);
        }






        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var cliente = _repository.Get(c => c.ClienteId == id);
            if (cliente is null)
            {
                return NotFound("cliente não Localizado...");
            }



            var clienteExcluido = _repository.Delete(cliente);
            return Ok(clienteExcluido);
        }




    }
}