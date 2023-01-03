using Microsoft.AspNetCore.Mvc;
using BankomatAPI.Classes;
using BankomatAPI.DAL;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankomatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfelController : ControllerBase
    {
        private readonly BankomatContext _context;

        public PortfelController(BankomatContext context) { 
            _context = context;
        }

        // GET: api/<PortfelController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Portfel>>> Get()
        {
            return await this._context.Portfels.ToListAsync();
        }

        // GET api/<PortfelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PortfelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PortfelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PortfelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
