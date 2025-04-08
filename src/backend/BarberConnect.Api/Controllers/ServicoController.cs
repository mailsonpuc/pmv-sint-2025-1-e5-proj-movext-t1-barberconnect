using BarberConnect.Api.Context;
using BarberConnect.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarberConnect.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        //construtor
        public ServicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ServicoModel>> Get()
        {
            return _context.Servicos.ToList();
        }

        [HttpPost]
        public ActionResult<IEnumerable<ServicoModel>> Post(ServicoModel model)
        {
            if (model == null)
                return BadRequest("Ocorreu um erro, cheque os dados");

            _context.Servicos.Add(model);
            _context.SaveChanges();

            var servicos = _context.Servicos.ToList();
            return Ok(servicos);
        }
    }
}
