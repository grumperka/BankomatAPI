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
        public List<Banknot> banknots = new List<Banknot>();
        public List<Moneta> monetas = new List<Moneta>();
        public List<Wlasciciel> wlasciciel = new List<Wlasciciel>();
        public List<Konto> kontos = new List<Konto>();
        public List<KartaKredytowa> kartaKredytowas = new List<KartaKredytowa>();
        public List<Portfel> portfels = new List<Portfel>();
        public List<Bankomat> bankomats = new List<Bankomat>();
        private string key;


        [SetUp]
        public void Setup()
        {
            this.key = "bankomatAplikacjaDotNetApiHash32";


            for (int i = 0; i < 5; i++)
            {
                this.banknots.Add(new Banknot(10));
                this.banknots.Add(new Banknot(20));
                this.banknots.Add(new Banknot(50));
                this.banknots.Add(new Banknot(100));
                this.banknots.Add(new Banknot(200));
                this.banknots.Add(new Banknot(500));
            }


            ///////////////////////////



            for (int i = 0; i < 5; i++)
            {
                this.monetas.Add(new Moneta(0.01));
                this.monetas.Add(new Moneta(0.02));
                this.monetas.Add(new Moneta(0.05));
                this.monetas.Add(new Moneta(0.1));
                this.monetas.Add(new Moneta(0.2));
                this.monetas.Add(new Moneta(0.5));
                this.monetas.Add(new Moneta(1));
                this.monetas.Add(new Moneta(2));
                this.monetas.Add(new Moneta(5));
                this.monetas.Add(new Moneta(5));

                this.monetas.Add(new Moneta(5));
                this.monetas.Add(new Moneta(5));
                this.monetas.Add(new Moneta(2));
                this.monetas.Add(new Moneta(1));
                this.monetas.Add(new Moneta(0.5));
                this.monetas.Add(new Moneta(0.2));
                this.monetas.Add(new Moneta(0.1));
                this.monetas.Add(new Moneta(0.05));
                this.monetas.Add(new Moneta(0.02));
                this.monetas.Add(new Moneta(0.01));
            }


            ////////////////////////////



            var names = new string[]{ "Anna", "Ewa", "Oliwia", "Kazimiera", "Genowefa",
                                            "Tomasz", "Andrzej", "Igor", "Janusz", "Olaf"};

            var surnames = new string[] { "Johnson", "McCormick", "Evans", "Liroy", "Fork", "Walles", "Lorenz", "Bregovic", "Fritz", "Cartman" };

            for (int i = 0; i < 10; i++)
            {
                this.wlasciciel.Add(new Wlasciciel { Id = i+1, Name = names[i], Surname = surnames[i] });
            }

            ////////////////////////////

            for (int i = 0; i < wlasciciel.Count; i++)
            {
                this.kontos.Add(new Konto { Id = i + 1, Balance = (i + 1) * 1500, Owner = wlasciciel.ElementAt(i), OwnerId = wlasciciel.ElementAt(i).Id });
            }

            ////////////////////////////

            var pins = new int[] { 1234, 4321, 2134, 1243, 4312, 5678, 8765, 8756, 6578, 8567 };
            List<string> new_pins = new List<string>();

            foreach (int pin in pins)
            {
                var encryptedString = AesOperation.EncryptString(this.key, pin.ToString());
                new_pins.Add(encryptedString);
            }


            for (int i = 0; i < wlasciciel.Count; i++)
            {
                this.kartaKredytowas.Add(new KartaKredytowa { Id = i + 1, PIN = new_pins.ElementAt(i), Account = kontos[i], AccountId = kontos[i].Id });
            }

            ////////////////////////////

            for (int i = 0; i < wlasciciel.Count; i++)
            {
                List<Banknot> banknoty = new List<Banknot>();
                banknoty.Add(banknots.ElementAt(i));
                banknoty.Add(banknots.ElementAt(i + 10));
                banknoty.Add(banknots.ElementAt(i + 20));

                foreach (Banknot banknot in banknoty) {
                    banknot.WalletId = i+1;
                }

                List<Moneta> monety = new List<Moneta>();
                monety.Add(monetas.ElementAt(i));
                monety.Add(monetas.ElementAt(i + 10));
                monety.Add(monetas.ElementAt(i + 20));
                monety.Add(monetas.ElementAt(i + 30));
                monety.Add(monetas.ElementAt(i + 40));
                monety.Add(monetas.ElementAt(i + 50));
                monety.Add(monetas.ElementAt(i + 60));
                monety.Add(monetas.ElementAt(i + 70));
                monety.Add(monetas.ElementAt(i + 80));
                monety.Add(monetas.ElementAt(i + 90));

                foreach (Moneta moneta in monety)
                {
                    moneta.WalletId = i + 1;
                }

                this.portfels.Add(new Portfel { Id = i + 1, Sum = banknoty.Sum(s => s.Value) + monety.Sum(s => s.Value), Owner = wlasciciel.ElementAt(i), OwnerId = wlasciciel.ElementAt(i).Id, BanknotsList = banknoty, MonetasList = monety });

            }

            for (int i = 0; i < 5; i++)
            {

                List<Banknot> banknotsBankomatowe = new List<Banknot>();

                for (int j = 0; j < 5; j++)
                {
                    banknotsBankomatowe.Add(new Banknot(10));
                    banknotsBankomatowe.Add(new Banknot(20));
                    banknotsBankomatowe.Add(new Banknot(50));
                    banknotsBankomatowe.Add(new Banknot(100));
                    banknotsBankomatowe.Add(new Banknot(200));
                    banknotsBankomatowe.Add(new Banknot(500));
                }

                this.bankomats.Add(new Bankomat { Id = i + 1, Name = "Bankomat nr. " + (i + 1).ToString(), BanknotsList = banknotsBankomatowe });
            }
        }


        [Test]
        public void DeposingOperation()
        {
            var portfel = this.portfels.Where(w => w.Id == 1).FirstOrDefault();
            var portfelBanknots = portfel.BanknotsList.Take(3).ToList();
            var sum = portfelBanknots.Sum(s => s.Value);
            var konto = this.kontos.Where(w => w.OwnerId == portfel.OwnerId).FirstOrDefault();
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

            var konto = this.kontos.Where(w => w.OwnerId == 1).FirstOrDefault();

            bool isEnoughT = konto.isEnough(konto.Balance);
            
            bool isEnoughTT = konto.isEnough(konto.Balance -1);

            bool isEnoughF = konto.isEnough(konto.Balance+1);

            Assert.IsTrue(isEnoughT == true && isEnoughTT == true && isEnoughF != true);
        }


        [Test]
        public void WithdrawingOperation() {

            var konto = this.kontos.Where(w => w.OwnerId == 1).FirstOrDefault();

            bool WithdrawingOperationT = konto.WithdrawingOperation(konto.Balance);

            bool WithdrawingOperationTT = konto.WithdrawingOperation(konto.Balance - 1);

            bool WithdrawingOperationF = konto.WithdrawingOperation(konto.Balance + 1);

            Assert.IsTrue(WithdrawingOperationT == true && WithdrawingOperationTT == true && WithdrawingOperationF != true);
        }

        [Test]
        public void TransferOperation()
        {

            var konto = this.kontos.Where(w => w.OwnerId == 1).FirstOrDefault();

            double kontoBefore = konto.Balance;

            bool TransferOperationT = konto.TransferOperation(1);

            bool TransferOperationF = konto.TransferOperation(0);


            Assert.IsTrue(TransferOperationT == true && TransferOperationF == false && kontoBefore == konto.Balance - 1);
        }

    }
}
