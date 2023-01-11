using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_Banknot
{
    public class KartaKredytowaTest
    {
        public Setup setup;

        [SetUp]
        public void Setup()
        {
            this.setup = new Setup();
        }

        [Test]
        public void checkPIN()
        { 
            var kartaKredytowa = this.setup.kartaKredytowas.First();

            bool result = kartaKredytowa.checkPIN("1234", this.setup.key);

            Assert.IsTrue(result == true);

            ////////////////
            ///
            result = kartaKredytowa.checkPIN("1256", this.setup.key);

            Assert.IsTrue(result == false);
        }

        [Test]
        public void requiredPIN() {

            var kartaKredytowa = this.setup.kartaKredytowas.First();

            float value = 99;

            bool result = kartaKredytowa.requiredPIN(value);

            Assert.IsTrue(result == false);

            ////////////////////
            ///
            value = 101;

            result = kartaKredytowa.requiredPIN(value);

            Assert.IsTrue(result == true);

        }
    }
}
