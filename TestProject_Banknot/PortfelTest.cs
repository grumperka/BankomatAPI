using BibliotekaKlas.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_Banknot
{
    public class PortfelTest
    {
        public Setup setup;

        [SetUp]
        public void Setup()
        {
            this.setup = new Setup();
        }

        [Test]
        public void isEnough() {

            var portfel = this.setup.portfels.First();

            double portfelSum = portfel.Sum;

            double portfelSum1 = portfel.Sum+1;

            Assert.IsTrue(portfel.isEnough(portfelSum) && !portfel.isEnough(portfelSum1));
        }

        [Test]
        public void addBanknot() {

            int nominal = 10;
            Banknot banknot = new Banknot(nominal);

            var portfel = this.setup.portfels.First();

            var portfelBefore = portfel.Sum;

            bool result = portfel.addBanknot(banknot);

            var portfelAfter = portfel.Sum;

            Assert.IsTrue(portfelBefore == portfelAfter - nominal && result);
        }

        [Test]
        public void removeBanknot()
        {
            var portfel = this.setup.portfels.First();

            var portfelBefore = portfel.Sum;

            var banknot = portfel.BanknotsList.ElementAt(1);

            int nominal = banknot.Value;

            var result = portfel.removeBanknot(banknot);

            var portfelAfter = portfel.Sum;

            Assert.IsTrue(portfelBefore == portfelAfter + nominal && result != null && result.Value == nominal);
        }

        [Test]
        public void AddRange() {

            List<Banknot> range = new List<Banknot>();

            for (int i = 0; i <= 5; i++) {
                range.Add(new Banknot(20));
            }

            var portfel = this.setup.portfels.First();
            var portfelBefore = portfel.Sum;

            var result = portfel.AddRange(range);
            var portfelAfter = portfel.Sum;

            Assert.IsTrue(portfelBefore == portfelAfter - range.Sum(s => s.Value));
        }

        [Test]
        public void getBanknotsCount()
        {
            int nominal = 10;

            var portfel = this.setup.portfels.First();

            int value = portfel.getBanknotsCount(nominal);
            int value0 = portfel.BanknotsList.Where(w => w.Value == nominal).ToList().Count;

            Assert.IsTrue(value == value0);
        }

        [Test]
        public void getMonetasCount()
        {
            int nominal = 5;

            var portfel = this.setup.portfels.First();

            int value = portfel.getMonetasCount(nominal);
            int value0 = portfel.MonetasList.Where(w => w.Value == nominal).ToList().Count;

            Assert.IsTrue(value == value0);
        }

        [Test]
        public void GetBanknots() {

            int value = 250;

            var portfel = this.setup.portfels.First();
            var result = portfel.GetBanknots(value);

            Assert.IsTrue(result.Sum(s => s.Value) == value);

            //////////////////////////////
            ///
            value = 600;
            result = portfel.GetBanknots(value);

            Assert.IsTrue(result == null);
        }

        [Test]
        public void RemoveRange()
        {
            int value = 250;

            var portfel = this.setup.portfels.First();
            var result = portfel.RemoveRange(value);

            Assert.IsTrue(result.Sum(s => s.Value) == value);
            //////////////////////////////
            ///
            result = portfel.RemoveRange(value);

            Assert.IsTrue(result == null);
        }
    }
}
