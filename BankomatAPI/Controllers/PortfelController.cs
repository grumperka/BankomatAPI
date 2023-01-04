using Microsoft.AspNetCore.Mvc;
using BibliotekaKlas;
using BankomatAPI.DAL;
using Microsoft.EntityFrameworkCore;
using BibliotekaKlas.Classes;

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
        [HttpGet]
        [Route("GetBanknots/{id}")]
        public List<Banknot> GetBanknots(int id)
        {
            return this._context.Banknots.Where(w => w.WalletId == id).ToList();
        }

        [HttpGet]
        [Route("GetMonetas/{id}")]
        public List<Moneta> GetMonetas(int id)
        {
            return this._context.Monetas.Where(w => w.WalletId == id).ToList();
        }

        [HttpGet]
        [Route("GetBalance/{id}")]
        public double GetBalance(int id)
        {
            var wallet = this._context.Portfels.Find(id);
            return wallet.Sum;
        }


    }
}
