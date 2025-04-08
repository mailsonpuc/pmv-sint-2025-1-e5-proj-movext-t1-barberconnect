using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberConnect.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        //construtor
        public ClientesController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return _context.Clientes.ToList();
        }





        [HttpGet("{id:int}", Name = "ObterClientePorId")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = _context.Clientes?.FirstOrDefault(p => p.ClienteId == id);
            if (cliente is null)
            {
                return NotFound("Não encontrado");
            }

            return cliente;

        }




        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            if (cliente is null)
            {
                return BadRequest("Ocorreu um erro, cheque os dados");
            }
            _context.Clientes?.Add(cliente);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterClientePorId",
            new { id = cliente.ClienteId }, cliente);

        }




        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest("Ocorreu um erro");
            }

            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(cliente);
        }






        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var cliente = _context.Clientes?.FirstOrDefault(p => p.ClienteId == id);
            if (cliente is null)
            {
                return NotFound("cliente não Localizado...");
            }

            _context.Clientes?.Remove(cliente);
            _context.SaveChanges();

            return Ok(cliente);
        }




    }
}