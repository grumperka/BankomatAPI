using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_Banknot
{
    public class BankomatTest
    {
        public Setup setup;

        [SetUp]
        public void Setup()
        {
            this.setup = new Setup();
        }

        [Test]
        public void getAllBanknotsSum() {
            
            var bankomat = this.setup.bankomats.Find(f => f.Id == 1);
            int sum = bankomat.getAllBanknotsSum();
            int sum0 = bankomat.BanknotsList.Sum(w => w.Value);

            Assert.IsTrue(sum == sum0);
        }

        [Test]
        public void getBanknotsCount() {

            int nominal = 10;
            var bankomat = this.setup.bankomats.Find(f => f.Id == 1);
            int count = bankomat.BanknotsList.Where(w => w.Value == nominal).ToList().Count();
            int count0 = bankomat.getBanknotsCount(nominal);

            Assert.IsTrue(count == count0);
        }

        [Test]
        public void withdrawMoneyFromATM() {

            int value = 260;

            var bankomat = this.setup.bankomats.Find(f => f.Id == 1);
            var moneyList = bankomat.withdrawMoneyFromATM(value);

            int sum = moneyList.Sum(w => w.Value);

            Assert.IsTrue(sum == value);

            ///////////////////////////////////////
            ///
            value = 4400; //kwota za duża - bankomat ma za mało banknotów

            moneyList = bankomat.withdrawMoneyFromATM(value);
            int count = bankomat.getAllBanknotsSum();

            Assert.IsTrue(moneyList == null || count < value);

        }

        [Test]
        public void getBanknotsIntoATM() {

            var konto = this.setup.kontos.Where(w => w.Id == 1).FirstOrDefault();
            var portfel = this.setup.portfels.Where(w => w.OwnerId == konto.OwnerId).FirstOrDefault();
            var bankomat = this.setup.bankomats.Find(f => f.Id == 1);

            int value = 260;
            var banknotsOut = portfel.RemoveRange(value);
            var banknotsIn = konto.DeposingOperation(banknotsOut);
            bool results = bankomat.getBanknotsIntoATM(banknotsIn);

            Assert.IsTrue(results == true || banknotsIn.Sum(s => s.Value) == value || banknotsOut.Sum(s => s.Value) == value);

            ///////////////////////////////////////
            /// w portfelu za mało banknotów, by wpłacić
            int portfelSum = (int)(portfel.Sum) + 10;

            if (portfelSum % 10 != 0) portfelSum -= portfelSum % 10;

            banknotsOut = portfel.RemoveRange(portfelSum);
            banknotsIn = konto.DeposingOperation(banknotsOut);
            results = bankomat.getBanknotsIntoATM(banknotsIn);

            Assert.IsTrue(banknotsOut == null || banknotsIn == null || results == false);

        }
    }
}
