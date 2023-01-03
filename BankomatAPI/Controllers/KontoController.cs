using BankomatAPI.Classes;
using BankomatAPI.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankomatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontoController : ControllerBase
    {
        private readonly BankomatContext _context;

        public KontoController(BankomatContext context) { 
            _context = context;
        }

        // GET: api/<KontoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Konto>>> Get()
        {
            return await _context.Kontos.ToListAsync();
        }

        // GET api/<KontoController>/5
        [HttpGet("{id}")]
        public Konto? Get(int id)
        {
            var konto =  _context.Kontos.Where(w => w.Id == id).FirstOrDefault();

            return konto;
        }

    }
}
