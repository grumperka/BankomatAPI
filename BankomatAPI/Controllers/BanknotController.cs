using BankomatAPI.Classes;
using BankomatAPI.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Timers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankomatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanknotController : ControllerBase
    {
        private readonly BankomatContext _context;

        public BanknotController(BankomatContext context)
        {
            _context = context;
        }

        // GET: api/<BanknotController>
        [HttpGet]
        [Route("Bankomat/{ATMId}")]
        public List<Banknot> GetATM(int ATMId)
        {
            var results = GetBankomatsBanknots(ATMId);
            return results;
        }

        [HttpGet]
        [Route("Portfel/{walletd}")]
        public List<Banknot> GetWallet(int walletd)
        {
            var results = GetBankomatsBanknots(walletd);
            return results;
        }


        // GET api/<BanknotController>/5
        [HttpPost]
        [Route("WithdrawMoney/{bankomatId}")]
        public IActionResult WithdrawMoney(int bankomatId, [FromBody] Transakcja transakcja) //do portfela
        {
            if (transakcja.Value != null || transakcja.Value <= 10 || transakcja.Value % 10 != 0)
            {
                var bankomat = this._context.Bankomats.Find(transakcja.ATMId);
                bankomat.BanknotsList = GetBankomatsBanknots(transakcja.ATMId);
                var konto = this._context.Kontos.Where(w => w.Id == transakcja.AccountId).FirstOrDefault();
                var portfel = this._context.Portfels.Where(w => w.OwnerId == konto.OwnerId).FirstOrDefault();
                portfel.BanknotsList = GetPortfelBanknots(portfel.Id);


                bool isEnough = konto.isEnough(transakcja.Value); //czy na koncie starczy

                if (isEnough == false)
                {
                    return NotFound();
                }

                List<Banknot> result = bankomat.withdrawMoneyFromATM(transakcja.Value); //wyplacanie z bankomatu

                if (result == null)
                {
                    return NotFound();
                }

                bool balanceChange = konto.WithdrawingOperation(transakcja.Value); //zmiana stanu konta 
                bool results = portfel.AddRange(result); //banknoty do portfela

                if (results && balanceChange)
                {
                    transakcja.DateTime = DateTime.Now;
                    _context.Transakcjas.Add(transakcja);
                    _context.SaveChanges();
                    return Ok();
                } 
                else return BadRequest();

            } 
            else return BadRequest();
        }
        
        [HttpPost]
        [Route("DeposingMoney/{bankomatId}")]
        public IActionResult DeposingMoney(int bankomatId, [FromBody] Transakcja transakcja) //do bankomatu
        {
            if (transakcja.Value != null || transakcja.Value <= 10 || transakcja.Value % 10 != 0)
            {
                var bankomat = this._context.Bankomats.Find(bankomatId);
                bankomat.BanknotsList = GetBankomatsBanknots(bankomat.Id);
                var konto = this._context.Kontos.Where(w => w.Id == transakcja.AccountId).FirstOrDefault();
                var portfel = this._context.Portfels.Where(w => w.OwnerId == konto.OwnerId).FirstOrDefault();
                portfel.BanknotsList = GetPortfelBanknots(portfel.Id);

                if (portfel.isEnough(transakcja.Value)) {
                    var banknotsOut = portfel.RemoveRange(transakcja.Value);
                    var banknotsIn = konto.DeposingOperation(banknotsOut); 
                    bool results = bankomat.getBanknotsIntoATM(banknotsIn);

                    if (results) {
                        transakcja.DateTime = DateTime.Now;
                        _context.Transakcjas.Add(transakcja);
                        _context.SaveChanges();
                        return Ok(); 
                    }
                    else return BadRequest();
                }
                else return NotFound();

            }
            else return BadRequest();
        }
        

        /////////////////////////
        [NonAction]
        public List<Banknot> GetBankomatsBanknots(int bankomatID) {
            return this._context.Banknots.Where(w => w.ATMId == bankomatID).ToList();
        }

        /////////////////////////
        [NonAction]
        public List<Banknot> GetPortfelBanknots(int portfelID)
        {
            return this._context.Banknots.Where(w => w.WalletId == portfelID).ToList();
        }
    }
}
