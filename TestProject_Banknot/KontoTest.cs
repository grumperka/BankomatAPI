using BibliotekaKlas.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_Banknot
{
    public class KontoTest
    {
        public Setup setup;

        [SetUp]
        public void Setup()
        {
            this.setup = new Setup();
        }


        [Test]
        public void DeposingOperation()
        {
            var portfel = this.setup.portfels.Where(w => w.Id == 1).FirstOrDefault();
            var portfelBanknots = portfel.BanknotsList.Take(3).ToList();
            var sum = portfelBanknots.Sum(s => s.Value);
            var konto = this.setup.kontos.Where(w => w.OwnerId == portfel.OwnerId).FirstOrDefault();
            var kontoBalanceBefore = konto.Balance;

            var results = konto.DeposingOperation(portfelBanknots);

            bool checkId = true;

            foreach (Banknot banknot in results) {
                if (banknot.WalletId != null) checkId = false;
            }

            var results0 = konto.DeposingOperation(null);
            var results00 = konto.DeposingOperation(new List<Banknot>());

            Assert.IsTrue(results != null && kontoBalanceBefore == konto.Balance - results.Sum(s => s.Value) && checkId && results0 == null && results00 == null);
        }

        [Test]
        public void isEnough() {

            var konto = this.setup.kontos.Where(w => w.OwnerId == 1).FirstOrDefault();

            bool isEnoughT = konto.isEnough(konto.Balance);
            
            bool isEnoughTT = konto.isEnough(konto.Balance -1);

            bool isEnoughF = konto.isEnough(konto.Balance+1);

            Assert.IsTrue(isEnoughT == true && isEnoughTT == true && isEnoughF != true);
        }


        [Test]
        public void WithdrawingOperation() {

            var konto = this.setup.kontos.Where(w => w.OwnerId == 1).FirstOrDefault();

            bool WithdrawingOperationT = konto.WithdrawingOperation(konto.Balance);

            bool WithdrawingOperationTT = konto.WithdrawingOperation(konto.Balance - 1);

            bool WithdrawingOperationF = konto.WithdrawingOperation(konto.Balance + 1);

            Assert.IsTrue(WithdrawingOperationT == true && WithdrawingOperationTT == true && WithdrawingOperationF != true);
        }

        [Test]
        public void TransferOperation()
        {

            var konto = this.setup.kontos.Where(w => w.OwnerId == 1).FirstOrDefault();

            double kontoBefore = konto.Balance;

            bool TransferOperationT = konto.TransferOperation(1);

            bool TransferOperationF = konto.TransferOperation(0);


            Assert.IsTrue(TransferOperationT == true && TransferOperationF == false && kontoBefore == konto.Balance - 1);
        }

    }
}
