using BibliotekaKlas.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_Banknot
{
    public class MonetaTest
    {
        public Setup setup;

        [SetUp]
        public void Setup()
        {
            this.setup = new Setup();
        }

        [Test]
        public void isValue() {

            double value = 0.2;
            Moneta moneta = new Moneta(value);

            bool result = moneta.isValue(value);
            Assert.IsTrue(result);
            ///////////////////////

            value = 0.25;
            result = moneta.isValue(value);
            Assert.IsTrue(!result);
        }


    }
}
