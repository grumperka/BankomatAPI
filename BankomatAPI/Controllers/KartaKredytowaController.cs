using BankomatAPI.DAL;
using BibliotekaKlas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankomatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KartaKredytowaController : ControllerBase
    {

        private readonly BankomatContext _context;

        public KartaKredytowaController(BankomatContext context)
        {
            this._context = context;
        }

        // GET: api/<KartaKredytowaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KartaKredytowa>>> Get()
        {
            return await this._context.KartaKredytowas.ToListAsync();
        }

        [HttpGet("{accountId}")]
        public async Task<ActionResult<KartaKredytowa>> GetCreditCard(int accountId)
        {
            return await this._context.KartaKredytowas.Where(w => w.AccountId == accountId).FirstOrDefaultAsync();
        }

        // GET api/<KartaKredytowaController>/5
        [HttpPost("{accountId}")]
        public IActionResult Get(int accountId, [FromBody] string pin)
        {
            var kartaKredytowa = this._context.KartaKredytowas.Where(w => w.AccountId == accountId).FirstOrDefault();

            if (kartaKredytowa != null) {
                var decryptedString = AesOperation.DecryptString(this._context.Key, kartaKredytowa.PIN);

                if (decryptedString.Equals(pin)) {
                    return Ok();
                }
                else return Forbid();
            }

            return NotFound();
        }

    }
}
