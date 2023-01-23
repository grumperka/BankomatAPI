using BankomatAPI.DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankomatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WlascicielController : ControllerBase
    {
        private readonly BankomatContext _context;

        public WlascicielController(BankomatContext context)
        {
            this._context = context;
        }

        // GET: api/<WlascicielController>
        [HttpGet]
        public object Get()
        {
            return this._context.Portfels.Join(this._context.Kontos,
                                                portfel => portfel.OwnerId,
                                                konto => konto.OwnerId,
                                                (portfel, konto) => new {
                                                    OwnerId = portfel.OwnerId,
                                                    PortfelId = portfel.Id,
                                                    KontoId = konto.Id,
                                                    Fortune = portfel.Sum + konto.Balance
                                                }).ToList();
        }

        // GET api/<WlascicielController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WlascicielController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WlascicielController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WlascicielController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
