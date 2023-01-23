using BankomatAPI.DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankomatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonetaController : ControllerBase
    {
        private readonly BankomatContext _context;

        public MonetaController(BankomatContext context)
        {
            this._context = context;
        }


        // GET: api/<MonetaController>
        /*
        [HttpGet]
        public object Get()
        {
            return  _context.Monetas.Join(_context.Automats.DefaultIfEmpty(),
                                                moneta => moneta.VendingMachineId,
                                                automat => automat.Id,
                                                (moneta, automat) => new { 
                                                    Id = moneta.Id,
                                                    Value = moneta.Value,
                                                    VMId = automat == null ? 0 : automat.Id,
                                                    VMName = automat == null ? "NA" : automat.Name
                                                }).ToList();
        } */

        // GET api/<MonetaController>/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            return _context.Monetas.Where(w => w.VendingMachineId == id).Join(_context.Automats,
                                                moneta => moneta.VendingMachineId,
                                                automat => automat.Id,
                                                (moneta, automat) => new {
                                                    Id = moneta.Id,
                                                    Value = moneta.Value,
                                                    VMId = automat.Id,
                                                    VMName = automat.Name
                                                }).ToList();
        }

        // POST api/<MonetaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MonetaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MonetaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
