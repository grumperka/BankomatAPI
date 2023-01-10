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
    }
}
